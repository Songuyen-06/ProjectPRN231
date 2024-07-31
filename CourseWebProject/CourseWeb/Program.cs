using CourseWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();

// Configure session services
builder.Services.AddDistributedMemoryCache(); // Provides distributed memory cache for session storage

 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout period
    options.Cookie.HttpOnly = true; // Session cookie can only be accessed via HTTP
    options.Cookie.IsEssential = true; // Session cookie is essential for the application
});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("Home.html");

app.UseDefaultFiles(options);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ensure session middleware is added before authorization and other middlewares
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
