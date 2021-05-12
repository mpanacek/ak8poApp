using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    instance = new WorkLabelAlgorithm();
                }
                return instance;
            }
        }

        #endregion


        public List<WorkLabel> Algorithm(Subject subject, Group group)
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

            while (rest > 0)
            {
                foreach (var workLabel in workLabels)
                {
                    if (rest > 0)
                    {
                        workLabel.NumberOfStudents++;
                        rest--;
                    }
                    else break;
                }
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

            return workLabels;
           // SaveWorkLabels(workLabels);
        }

        public List<WorkLabel> RecalculationAlgorithm(Subject subject, int numberOfStudents, IEnumerable<WorkLabel> workLabelsRaw)
        {
           // IEnumerable<WorkLabel> workLabelsRaw = await _workLabelService.GetAll();

            List<WorkLabel> workLabels = workLabelsRaw.Where(w => w.Subject.Id == subject.Id).ToList();

            foreach (var worklLabel in workLabels)
            {
                if (worklLabel.LectureType == LectureType.Prednáška)
                {
                    workLabels.Remove(worklLabel);
                    break;
                }
            }

            int maximumClassSize = subject.ClassSize;

            double groupCount = Convert.ToDouble(numberOfStudents) / Convert.ToDouble(maximumClassSize);
            int roundedGroupCount = (int)Math.Ceiling(groupCount);

            int rest = numberOfStudents % roundedGroupCount;

            int numberOfStudentsPerWorkLabel = numberOfStudents / roundedGroupCount;

            if(workLabels.Count > roundedGroupCount)
            {
                for (int i = 0; i < workLabels.Count; i++)
                {
                    if (roundedGroupCount > i)
                    {
                        workLabels[i].NumberOfStudents = numberOfStudentsPerWorkLabel;
                    }
                    else
                    {
                        workLabels[i].NumberOfStudents = 0;
                    }
                }
            }
            else 
            {
                for (int i = 0; i < roundedGroupCount; i++)
                {
                    if(i >= workLabels.Count)
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
                    else
                    {
                        workLabels[i].NumberOfStudents = numberOfStudentsPerWorkLabel;
                    }
                }
            }

            //Rozdelenie zvysku studentov medzi pracovne stitky
            while(rest>0)
            {
                foreach (var workLabel in workLabels)
                {
                    if (rest > 0)
                    {
                        if (workLabel.NumberOfStudents != 0)
                        {
                            workLabel.NumberOfStudents++;
                            rest--;
                        }
                    }
                    else break;
                }
            }

            return workLabels;
            //UpdateWorkLabels(workLabels);
        }

        //private void UpdateWorkLabels(List<WorkLabel> workLabels)
        //{
        //    foreach (var workLabel in workLabels)
        //    {
        //        _workLabelService.Update(workLabel.Id, workLabel);
        //    }
        //}

        //private void SaveWorkLabels(List<WorkLabel> workLabels)
        //{
        //    foreach (var workLabel in workLabels)
        //    {
        //        _workLabelService.Create(workLabel);
        //    }
        //}
    }
}
