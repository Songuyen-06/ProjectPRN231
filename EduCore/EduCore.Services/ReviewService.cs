using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetListReviewByCourseId(int courseId)
        {
            return _mapper.Map<List<ReviewDTO>>(await _unitOfWork.ReviewRepository.GetListReviewByCourseId(courseId).ToListAsync());
        }
        public async Task<List<ReviewDTO>> GetListReviewByCourseIdAndFilterByDate(int courseId, bool isNewest)
        {
            return _mapper.Map<List<ReviewDTO>>(await _unitOfWork.ReviewRepository.GetListReviewByCourseIdAndFilterByDate(courseId, isNewest).ToListAsync());
        }
        public async Task<List<ReviewDTO>> GetListReviewByCourseIdAndFilterByRating(int courseId, int rating)
        {
            return _mapper.Map<List<ReviewDTO>>(await _unitOfWork.ReviewRepository.GetListReviewByCourseIdAndFilterByRating(courseId, rating).ToListAsync());
        }
        public async Task<List<ReviewDTO>> GetListReview()
        {
            return _mapper.Map<List<ReviewDTO>>(await _unitOfWork.ReviewRepository.GetListReviewByInclude().ToListAsync());
        }
        public async Task<List<ReviewDTO>> GetListReviewByCourseIdAndFilterByAll(int courseId, bool isNewest, int rating)
        {
            return _mapper.Map<List<ReviewDTO>>(await _unitOfWork.ReviewRepository.GetListReviewByCourseIdAndFilterByAll(courseId, isNewest, rating).ToListAsync());
        }
    }
}
