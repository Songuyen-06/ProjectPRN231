using AutoMapper;
using EduCore.Domain;
using EduCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Services.Tests
{
    public class CategoryServiceTest
    {
        private static DbContextOptions<CoursesDbContext> options
            = new DbContextOptionsBuilder<CoursesDbContext>()
            .UseInMemoryDatabase(databaseName: "CoursesDB").Options;
        private CoursesDbContext context { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        private ICategoryService categoryService;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new CoursesDbContext(options);
            unitOfWork = new UnitOfWork(context);
            categoryService = new CategoryService(unitOfWork);

        }
        private void SeedDatabase()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}