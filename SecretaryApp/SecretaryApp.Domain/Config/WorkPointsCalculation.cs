namespace SecretaryApp.Domain.Config
{
    public class WorkPointsCalculation
    {
        #region Singleton

        private static WorkPointsCalculation instance;

        public static WorkPointsCalculation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkPointsCalculation();
                }
                return instance;
            }
        }

        #endregion

        public double Lecture { get; private set; } = 1.8;
        public double Excercise { get; private set; } = 1.2;
        public double Seminar { get; private set; } = 1.2;
        public double Lecture_Eng { get; private set; } = 2.4;
        public double Excercise_Eng { get; private set; } = 1.8;
        public double Seminar_Eng { get; private set; } = 1.8;
        public double Credit { get; private set; } = 0.2;
        public double ClassifiedCredit { get; private set; } = 0.3;
        public double Exam { get; private set; } = 0.4;
        public double Credit_Eng { get; private set; } = 0.2;
        public double ClassifiedCredit_Eng { get; private set; } = 0.3;
        public double Exam_Eng { get; private set; } = 0.4;
    }
}
