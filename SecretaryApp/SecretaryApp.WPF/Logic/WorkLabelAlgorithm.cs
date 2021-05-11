using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System;
using System.Collections.Generic;

namespace SecretaryApp.WPF.Logic
{
    public class WorkLabelAlgorithm
    {
        #region Singleton

        private static WorkLabelAlgorithm instance;
       
        public static WorkLabelAlgorithm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkLabelAlgorithm(new SecretaryAppDbContextFactory());
                }
                return instance;
            }
        }

        #endregion

        private IDataService<WorkLabel> _workLabelService { get; set; }

        public WorkLabelAlgorithm(SecretaryAppDbContextFactory _context)
        {
            _workLabelService = new WorkLabelDataService(_context, new GenericDataService<WorkLabel>(_context));
        }


        public void Algorithm(Subject subject, Group group)
        {
            int numberOfStudents = group.NumberOfStudents;
            int maximumClassSize = subject.ClassSize;

            List<WorkLabel> workLabels = new List<WorkLabel>();

            double groupCount = Convert.ToDouble(numberOfStudents) / Convert.ToDouble(maximumClassSize);
            int roundedGroupCount = (int)Math.Ceiling(groupCount);

            int rest = numberOfStudents % roundedGroupCount;

            int numberOfStudentsPerWorkLabel = numberOfStudents / roundedGroupCount;

            //Tvorba pracovnych stitkov a priradzovanie zakladneho poctu studentov
            for (int i = 0; i < roundedGroupCount; i++)
            {
                WorkLabel workLabel = new WorkLabel();
                workLabel.NumberOfStudents = numberOfStudentsPerWorkLabel;
                workLabel.LectureType = LectureType.Cvičenie;
                workLabel.Language = subject.Language;
                workLabel.NumberOfHours = subject.HoursOfExcercises;
                workLabel.NumberOfWeeks = subject.NumberOfWeeks;
                workLabel.Subject = subject;
                workLabels.Add(workLabel);
            }

            //Rozdelenie zvysku studentov medzi pracovne stitky
            foreach (var workLabel in workLabels)
            {
                if (rest > 0)
                {
                    workLabel.NumberOfStudents++;
                    rest--;
                }
                else break;
            }

            //Vygeneruj workLabel s prednaskou
            WorkLabel presentationWorkLabel = new WorkLabel();
            presentationWorkLabel.LectureType = LectureType.Prednáška;
            presentationWorkLabel.NumberOfStudents = numberOfStudents;
            presentationWorkLabel.Language = subject.Language;
            presentationWorkLabel.NumberOfHours = subject.HoursOfLectures;
            presentationWorkLabel.NumberOfWeeks = subject.NumberOfWeeks;
            presentationWorkLabel.Subject = subject;
            workLabels.Add(presentationWorkLabel);

            SaveWorkLabels(workLabels);
        }

        private void SaveWorkLabels(List<WorkLabel> workLabels)
        {
            foreach (var workLabel in workLabels)
            {
                _workLabelService.Create(workLabel);
            }
        }
    }
}
