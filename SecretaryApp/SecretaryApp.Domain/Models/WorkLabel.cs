namespace SecretaryApp.Domain.Models
{
    public enum LectureType
    {
        Lecture, Seminar, Excercise, Credit, ClassifiedCredit, Exam 
    }

    public class WorkLabel : DomainObject
    {
        public Employee Employee { get; set; }
        public Subject Subject { get; set; }
        public LectureType LectureType { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfHours { get; set; }
        public int NumberOfWeeks { get; set; }
        public Language Language { get; set; }
    }
}
