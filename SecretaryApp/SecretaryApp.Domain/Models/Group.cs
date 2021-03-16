namespace SecretaryApp.Domain.Models
{
    public enum Semester
    {
        ZS, LS
    }

    public enum StudyForm 
    {
        P, K
    }

    public enum StudyType
    {
        Bc, Mgr
    }

    public enum Language
    {
        cz, en
    }

    public class Group : DomainObject
    {
        public Subject Subject { get; set; }
        public string Shortcut { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int NumberOfStudents { get; set; }
        public Semester Semester { get; set; }
        public StudyForm StudyForm { get; set; }
        public StudyType StudyType { get; set; }
        public Language Language { get; set; }
    }
}
