
using EduCore.Domain.Contracts;

namespace EduCore.Domain
{
    public interface IUnitOfWork
    {     
        IUserRepository UserRepository { get; }
        ICourseRepository CourseRepository { get; }
        IReviewRepository ReviewRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        ICheckoutRepository CheckoutRepository { get; }

        IStudentCourseRepository StudentCourseRepository { get; }

        ILectureRepository LectureRepository { get; }

        IEnrollmentRepository EnrollmentRepository { get; }

        ISectionRepository SectionRepository { get; }

        ISubCategoryRepository SubCategoryRepository {  get; }

        IInstructorRepository  InstructorRepository { get; }

         ICertificateRepositoty CertificateRepositoty {  get; }
<<<<<<< HEAD:EduCore/EduCore.Domain/Contracts/IUnitOfWork.cs

        ICommentRepository CommentRepository { get; }
        IStudentRepository StudentRepository { get; }

        ICompletionStatusRepository CompletionStatusRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();

=======
        Task Commit();
        Task Rollback();
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/Contracts/IUnitOfWork.cs
    }
}
