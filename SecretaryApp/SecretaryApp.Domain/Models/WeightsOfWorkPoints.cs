namespace SecretaryApp.Domain.Models
{
    public class WeightsOfWorkPoints : DomainObject
    {
        public double Lecture { get; set; }
        public double Excercise { get; set; }
        public double Seminar { get; set; }
        public double Lecture_Eng { get; set; }
        public double Excercise_Eng { get; set; }
        public double Seminar_Eng { get; set; }
        public double Credit { get; set; }
        public double ClassifiedCredit { get; set; }
        public double Exam { get; set; }
        public double Credit_Eng { get; set; }
        public double ClassifiedCredit_Eng { get; set; }
        public double Exam_Eng { get; set; }
    }
}
