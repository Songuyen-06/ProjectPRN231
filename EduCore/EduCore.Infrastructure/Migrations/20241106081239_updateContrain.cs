using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateContrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

           

           
           

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionExcerciseQuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CourseID",
                table: "Certificates",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CourseID",
                table: "Checkouts",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_StudentID",
                table: "Checkouts",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LectureId",
                table: "Comments",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyId",
                table: "Comments",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletionStatuses_CourseId",
                table: "CompletionStatuses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletionStatuses_LectureId",
                table: "CompletionStatuses",
                column: "LectureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletionStatuses_LectureId1",
                table: "CompletionStatuses",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletionStatuses_SectionId",
                table: "CompletionStatuses",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorID",
                table: "Courses",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubCategoryId",
                table: "Courses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CourseID",
                table: "Documents",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_LectureId",
                table: "Exercises",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_SectionID",
                table: "Lectures",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExerciseId",
                table: "Questions",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseID",
                table: "Reviews",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentID",
                table: "Reviews",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseID",
                table: "Sections",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCertificates_CertificateId",
                table: "StudentCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_UserID",
                table: "SystemSettings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CompletionStatuses");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "StudentCertificates");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
