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
        public int WorkPoints { get; set; }
        public double WorkingTime { get; set; }
        public bool DoctoralStudent { get; set; }
        IEnumerable<WorkLabel> WorkLabels { get; set; }
    }
}
