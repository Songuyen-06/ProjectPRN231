using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;
using static System.Collections.Specialized.BitVector32;

namespace EduCore.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCourse(CourseDTO cDTO)
        {
            try
            {
                var c = _mapper.Map<Course>(cDTO);

                if (!await _unitOfWork.SubCategoryRepository.IsExistingSubCategory(cDTO.SubCategoryId) && cDTO.SubCategoryId != null)
                {
                    var newSubCategory = new SubCategory { Name = $"SubCategory{cDTO.SubCategoryId}" };
                    _unitOfWork.SubCategoryRepository.Add(newSubCategory);
                    c.SubCategory = newSubCategory;
                }

                if (await _unitOfWork.UserRepository.Get(u => u.UserId == cDTO.InstructorId) == null && cDTO.InstructorId != null)
                {
                    var newInstructor = new User { Email = $"user{cDTO.InstructorId}@gmail.com", Password = "123" };
                    _unitOfWork.UserRepository.Add(newInstructor);
                    c.Instructor = newInstructor;
                }

                _unitOfWork.CourseRepository.Add(c);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Failed to add course.", ex);
            }
        }

        public async Task UpdateCourse(CourseDTO cDTO, int courseId)
        {

            try
            {
                if (await _unitOfWork.CourseRepository.IsExistingCourse(courseId))
                {

                    var c = _mapper.Map<Course>(cDTO);
                    c.CourseId = courseId;

                    if (!await _unitOfWork.SubCategoryRepository.IsExistingSubCategory(cDTO.SubCategoryId) && cDTO.SubCategoryId != null)
                    {
                        var newSubCategory = new SubCategory { Name = $"SubCategory{cDTO.SubCategoryId}" };
                        _unitOfWork.SubCategoryRepository.Add(newSubCategory);
                        c.SubCategory = newSubCategory;
                    }

                    if (await _unitOfWork.UserRepository.Get(u => u.UserId == cDTO.InstructorId) == null && cDTO.InstructorId != null)
                    {
                        var newInstructor = new User { Email = $"user{cDTO.InstructorId}@gmail.com", Password = "123" };
                        _unitOfWork.UserRepository.Add(newInstructor);
                        c.Instructor = newInstructor;
                    }
                    _unitOfWork.CourseRepository.Update(c);
                    _unitOfWork.Commit();
                }
            }

            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Failed to update course.", ex);
            }

        }

        public async Task DeleteCourse(Course course)
        {
            _unitOfWork.CourseRepository.Remove(course);
            _unitOfWork.Commit();
        }



        public async Task<List<CourseDTO>> GetListCourseByStudentId(int stdId, bool isInCart)
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetListCourseByStudentId(stdId, isInCart));
        }


        public async Task<List<CourseDTO>> GetListCourse()
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetListCourseByInclude().ToListAsync());
        }





        public async Task AddStudentCourse(StudentCourseDTO scDTO)
        {
            var sc = _mapper.Map<StudentCourse>(scDTO);
            if (await _unitOfWork.StudentCourseRepository.Get(sc => sc.UserId == scDTO.UserId && sc.CourseId == scDTO.CourseId) == null)
            {
                _unitOfWork.StudentCourseRepository.Add(sc);
                _unitOfWork.Commit();

            }
        }



        public async Task<List<CourseDTO>> GetTopSellingCourses()
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetTopSellingCourses().ToListAsync());
        }

        public async Task<List<CourseDTO>> GetTopSellingCoursesByCateId(int cateId)
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetTopSellingCoursesByCateId(cateId));
        }


        public async Task<List<CourseDTO>> GetTopSellingCoursesBySubCateId(int subCateId)
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetTopSellingCoursesBySubCateId(subCateId));
        }

        public async Task<List<CourseDTO>> GetListCourseByInstructorId(int instructorId)
        {
            return _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetListCourseByInstructorId(instructorId));
        }



        public async Task<CourseDetailDTO> GetCourseDetailByCourseId(int cId)
        {
            return _mapper.Map<CourseDetailDTO>(await _unitOfWork.CourseRepository.GetCourseDetailByCourseId(cId));
        }


        public async Task<CourseDetailDTO> GetStatusCourseDetailByStudentIdAndCourseId(int courseId, int stdId)
        {
            var courseDetail = await GetCourseDetailByCourseId(courseId);

            courseDetail.IsCompleted = await IsCourseCompleted(courseId, stdId);
            foreach (var section in courseDetail.Sections)
            {
                section.IsCompleted = await IsSectionCompleted(section.SectionId, stdId);
                var lectureStatuses = await _unitOfWork.CompletionStatusRepository.GetAll(cs => cs.UserId == stdId && cs.CourseId == courseId && cs.SectionId == section.SectionId);
                foreach (var lecture in section.Lectures)
                {

                    lecture.IsCompleted = lectureStatuses.Any(cs => cs.LectureId == lecture.LectureId);
                }
            }



            return courseDetail;

        }

        public async Task<bool> IsSectionCompleted(int sectionId, int stdId)
        {
            var lecturesInSection = _unitOfWork.LectureRepository.GetAll(l => l.SectionId == sectionId).Result;
            var completedLectures = _unitOfWork.CompletionStatusRepository.GetAll(cs => lecturesInSection.Select(l => l.LectureId).Contains(cs.LectureId) && cs.UserId == stdId).Result;

            return lecturesInSection.Count() == completedLectures.Count();
        }

        public async Task<bool> IsCourseCompleted(int courseId, int stdId)
        {
            var sectionsInCourse = await _unitOfWork.SectionRepository.GetAll(s => s.CourseId == courseId);
            foreach (var section in sectionsInCourse)
            {
                if (!IsSectionCompleted(section.SectionId, stdId).Result)
                {
                    return false;
                }
            }

            return true;
        }
        public async Task<List<CourseDTO>> GetEnrolledCourseListByStudentId(int stdId)
        {

            var enrolledCourses = _mapper.Map<List<CourseDTO>>(await _unitOfWork.CourseRepository.GetEnrolledCourseListByStudentId(stdId));
            foreach (var course in enrolledCourses)
            {
                course.IsCompleted = await IsCourseCompleted(course.CourseId, stdId);


            }
            return enrolledCourses;

        }
       
    }
}
