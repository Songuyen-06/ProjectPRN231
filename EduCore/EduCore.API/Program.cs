using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Infrastructure;
using EduCore.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ReviewDTO>("Review");
modelBuilder.EntitySet<CourseDTO>("Course");
modelBuilder.EntitySet<SectionDTO>("Section");
modelBuilder.EntitySet<CategoryDTO>("Category");
modelBuilder.EntitySet<InstructorDTO>("Instructor");
modelBuilder.EntitySet<CertificateDTO>("Certificate");
<<<<<<< HEAD:EduCore/EduCore.API/Program.cs
modelBuilder.EntitySet<CheckoutDTO>("Checkout");
modelBuilder.EntitySet<EnrollmentDetailDTO>("Enrollment");
modelBuilder.EntitySet<StudentDTO>("Student");

var provider=builder.Services.BuildServiceProvider();
var config=provider. GetService<IConfiguration>();
=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseAPI/Program.cs


modelBuilder.EntitySet<UserDTO>("User");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(config.GetValue<string>("Frontend_url"))
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddOData(opt => opt.Select().Filter().SetMaxTop(100).Expand().OrderBy().Count().AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.Services.AddDbContext<CoursesDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
<<<<<<< HEAD:EduCore/EduCore.API/Program.cs
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
=======

>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseAPI/Program.cs



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
