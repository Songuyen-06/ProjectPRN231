using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Infrastructure.Repositories;

namespace EduCore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoursesDbContext _dbContext;

        private IUserRepository _userRepository;
        private ICourseRepository _courseRepository;
        private IReviewRepository _reviewRepository;
        private IEnrollmentRepository _enrollmentRepository;
        private ICheckoutRepository _checkoutRepository;
        private ICategoryRepository _categoryRepository;
        private ISectionRepository _sectionRepository;

        private  ILectureRepository _lectureRepository;

        private ISubCategoryRepository _subCategoryRepository;

        private IInstructorRepository _instructorRepository;

        private IStudentCourseRepository _studentCourseRepository;
        private IStudentRepository _studentRepository;
        private ICommentRepository _commentRepository;

        private ICertificateRepositoty _certificateRepositoty;
<<<<<<< HEAD:EduCore/EduCore.Infrastructure/UnitOfWork/UnitOfWork.cs

        private ICompletionStatusRepository _completionStatusRepository;
=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseInfrastructures/UnitOfWork/UnitOfWork.cs
        public UnitOfWork(CoursesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }
<<<<<<< HEAD:EduCore/EduCore.Infrastructure/UnitOfWork/UnitOfWork.cs

        public ILectureRepository LectureRepository=>_lectureRepository?? new LectureRepository(_dbContext);
=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseInfrastructures/UnitOfWork/UnitOfWork.cs
        public ICertificateRepositoty CertificateRepositoty => _certificateRepositoty ?? new CertificateRepository(_dbContext);
        public IInstructorRepository InstructorRepository => _instructorRepository ?? new InstructorRepository(_dbContext);
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository ?? new SubCategoryRepository(_dbContext);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_dbContext);

        public ICourseRepository CourseRepository => _courseRepository ?? new CourseRepository(_dbContext);


        public IReviewRepository ReviewRepository => _reviewRepository ?? new ReviewRepository(_dbContext);


        public ICheckoutRepository CheckoutRepository => _checkoutRepository ?? new CheckoutRepository(_dbContext);


        public IEnrollmentRepository EnrollmentRepository => _enrollmentRepository ?? new EnrollmentRepository(_dbContext);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dbContext);

        public ISectionRepository SectionRepository => _sectionRepository ?? new SectionRepository(_dbContext);

        public IStudentCourseRepository StudentCourseRepository => _studentCourseRepository ?? new StudentCourseRepository(_dbContext);
        public IStudentRepository StudentRepository => _studentRepository ?? new StudentRepository(_dbContext);

        public ICommentRepository CommentRepository =>  _commentRepository??new CommentRepository(_dbContext);
        public ICompletionStatusRepository CompletionStatusRepository =>  _completionStatusRepository??new CompletionStatusRepository(_dbContext);

        public void Commit()  => _dbContext.SaveChanges();


        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.Dispose();


        public async Task RollbackAsync()   => await _dbContext.DisposeAsync();


    }
}
