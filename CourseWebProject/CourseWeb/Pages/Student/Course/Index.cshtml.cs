﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CourseDomain;
using CourseDomain.DTOs;
using CourseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CourseWeb.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public List<CourseDetailDTO> Courses { get; set; }

        //[BindProperty]
        //public List<SubCategoryDTO> SubCategories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICourseService courseService, ICategoryService categoryService)
        {
            _logger = logger;
            _courseService = courseService;
            _categoryService = categoryService;
        }

        public async Task OnGetAsync(int cateId, int? subCateId)
        {
            try
            {
                          
                Courses = subCateId!=null?await _courseService.GetListCoursesBySubCategoryId(subCateId): await _courseService.GetListCoursesByCategoryId(cateId);



                ViewData["NumberPage"] =  _courseService.GetNumberPageCourse(Courses.Count);

                ViewData["CateId"] = cateId;
                ViewData["SubCateId"] = subCateId;
                ViewData["Categories"] = await _categoryService.GetListCategory();

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error fetching data from API: {ex.Message}");
            }
        }
    
    }
}