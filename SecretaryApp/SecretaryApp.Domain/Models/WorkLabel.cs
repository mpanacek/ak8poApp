using SecretaryApp.Domain.Config;

namespace SecretaryApp.Domain.Models
{
    public enum LectureType
    {
        Prednáška, Cvičenie, Seminár, Zápočet, KlasifikovanýZápočetSkúška
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

        public double NumberOfPoints()
        {
            switch (LectureType)
            {
                case LectureType.Prednáška:
                    return WorkPointsCalculation.Instance.Lecture * NumberOfHours;
                case LectureType.Cvičenie:
                    return WorkPointsCalculation.Instance.Excercise * NumberOfHours;
                case LectureType.Seminár:
                    return WorkPointsCalculation.Instance.Seminar * NumberOfHours;
                case LectureType.Zápočet:
                    return 0;
                case LectureType.KlasifikovanýZápočetSkúška:
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
