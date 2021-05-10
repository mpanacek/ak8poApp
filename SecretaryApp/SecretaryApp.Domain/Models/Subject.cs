﻿using System.Collections.Generic;

namespace SecretaryApp.Domain.Models
{
    public enum WayOfCompletion
    {
        Záúpčet, Skúška
    }

    public class Subject : DomainObject
    {
        public string Shortcut { get; set; }
        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
        public int NumberOfWeeks { get; set; }
        public int HoursOfLectures { get; set; }
        public int HoursOfExcercises { get; set; }
        public int ClassSize { get; set; }
        public WayOfCompletion WayOfCompletion { get; set; }
        public Language Language { get; set; }
        public IEnumerable<WorkLabel> WorkLabels { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
