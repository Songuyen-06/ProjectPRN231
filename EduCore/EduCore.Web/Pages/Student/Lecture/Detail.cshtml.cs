using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace EduCore.Web.Pages.Student.Lecture
{
    public class DetailModel : PageModel
    {
        public int CourseId { get; set; }
        public string CourseTitle {  get; set; }
        public List<SectionDTO> Sections { get; set; }

        public LectureDetailDTO? Lecture { get; set; }

        [BindProperty]
    public AddedCommentDTO AddedComment { get; set; } = new AddedCommentDTO();

        public CommentDTO? RepliedComment { get; set; }

        public string Action { get; set; }

        public ExerciseDTO? EssayExercise { get; set; }

        public UserDTO? User {  get; set; } 

        public ILectureService _lectureService { get; set; }
        public ICommentService _commentService { get; set; }
        public  ICourseService _courseService { get; set; }
        public CourseDetailDTO CourseDetail { get; set; }

        public IAIService _AIService { get; set; }

        public DetailModel( ILectureService lectureService, ICommentService commentService, IAIService _AIService, ICourseService courseService)
        {
            _lectureService = lectureService;
            _commentService = commentService;
            this._AIService = _AIService;
            _courseService = courseService;
        }
        public async Task OnGet(string? exercise, int? repliedCommentId, int? courseId,string? courseTitle, int? lectureId)
        {

            if (exercise != null)
            {
                EssayExercise = JsonConvert.DeserializeObject<ExerciseDTO>(exercise);
            }

            if (courseId != null)
            {

                TempData["CourseId"] = courseId;
            }
            if(courseTitle != null)
            {
                TempData["CourseTitle"] = courseTitle;

            }
            if (lectureId != null)
            {

                TempData["LectureId"] = lectureId;
            }

            CourseId = (int)TempData.Peek("CourseId");
            CourseTitle = (string)TempData.Peek("CourseTitle");

            string userJson = HttpContext.Request.Cookies["User"] ??
                      HttpContext?.Session?.GetString("User");
            if (userJson != null)
            {
                User = JsonConvert.DeserializeObject<UserDTO>(userJson);
            }
            CourseDetail = await _courseService.GetStatusCourseDetailByStudentIdAndCourseId(CourseId,User.UserId);


            Lecture = _lectureService.GetLectureDetailById((int)TempData.Peek("LectureId")).Result;
            RepliedComment = repliedCommentId != null ? _commentService.GetCommentById(repliedCommentId).Result : null;

            if (TempData["AddedComment"] != null)
            {
                var json = TempData["AddedComment"] as string;
                AddedComment = JsonConvert.DeserializeObject<AddedCommentDTO>(json);
            }



        }
        public async Task<IActionResult> OnPostAddComment()
        {
            if (ModelState.IsValid)
            {
                _commentService.AddComment(AddedComment);
                TempData["AddedComment"] = JsonConvert.SerializeObject(AddedComment);


            }
            return RedirectToPage();

        }



        public IActionResult OnPostCheckAnswerEssay([FromBody] ExerciseDTO exercise)
        {
            // Process the received data
            _AIService.EvaluateAnswer();
            var response = new { result = "Data received successfully" };
            return new JsonResult(response);
        }


    }
}
