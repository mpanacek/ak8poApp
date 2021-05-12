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
        public int WorkPoints_NoEng { get; set; }
      //  public int WorkPoints { get; set; }
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

        public double GetWorkPoints()
        {
            double workPoints = 0;
            foreach (var workLabel in WorkLabels)
            {
                workPoints += workLabel.NumberOfPoints();
            }

            return workPoints;
        }
    }
}
