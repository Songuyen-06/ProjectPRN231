using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        private readonly IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO cDTO)
        {
            var category = _mapper.Map<Category>(cDTO);
            _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteCategory(int categoryId)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryByCateId(categoryId);
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Remove(category);
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task<IEnumerable<CategoryDTO>> GetListCategory()
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>(await _unitOfWork.CategoryRepository.GetAllCategory().ToListAsync());
        }
        public async Task<CategoryDTO> GetCategoryByCateId(int cateId)
        {
            return _mapper.Map<CategoryDTO>(await _unitOfWork.CategoryRepository.GetCategoryByCateId(cateId));
        }

    }
}
