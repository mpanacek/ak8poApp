using System.Collections.Generic;

namespace SecretaryApp.Domain.Models
{
    public class Employee : DomainObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string WorkEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string WorkPhone { get; set; }
        public string PersonalPhone { get; set; }
        public double WorkingTime { get; set; }
        public bool DoctoralStudent { get; set; }
        public IEnumerable<WorkLabel> WorkLabels { get; set; }

        public double WorkPoints 
        { 
            get 
            {
                return GetWorkPoints(); 
            }
        }

        public double WorkPoints_NoEng 
        { 
            get
            {
                return GetWorkPoints() - GetEngWorkPoints();
            }
        }

        private double GetWorkPoints()
        {
            double workPoints = 0;
            if(WorkLabels != null)
            {
                foreach (var workLabel in WorkLabels)
                {
                    workPoints += workLabel.NumberOfPoints;
                }
            }
            

            return workPoints;
        }

        private double GetEngWorkPoints()
        {
            double workPoints = 0;

            if (WorkLabels != null)
            {
                foreach (var workLabel in WorkLabels)
                {
                    if (workLabel.Language == Language.en)
                        workPoints += workLabel.NumberOfPoints;
                }
            }
            return workPoints;
        }
    }
}
