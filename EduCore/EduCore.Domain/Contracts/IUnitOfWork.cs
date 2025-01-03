
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

        ICommentRepository CommentRepository { get; }

        IStudentRepository StudentRepository { get; }

        ICompletionStatusRepository CompletionStatusRepository { get; }

        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();


    }
}
