using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int gradeThreshold = Students.Count / 5; // 20% is threshold for each grade
            List<double> sortedAverageGrades = new List<double>();
            Students.ForEach(student => sortedAverageGrades.Add(student.AverageGrade));
            sortedAverageGrades.Sort();
            sortedAverageGrades.Reverse();


            if(averageGrade >= sortedAverageGrades[gradeThreshold - 1])
            {
                return 'A';
            }
            else if(averageGrade >= sortedAverageGrades[gradeThreshold*2 - 1])
            {
                return 'B';
            }
            else if (averageGrade >= sortedAverageGrades[gradeThreshold * 3 - 1])
            {
                return 'C';
            }
            else if (averageGrade >= sortedAverageGrades[gradeThreshold * 4 - 1])
            {
                return 'D';
            }
            //else if (averageGrade >= sortedAverageGrades[gradeThreshold * 5])
            //{
            //    return 'e';
            //}

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else
            {
                base.CalculateStatistics();
            }
            
        }

        public override void CalculateStudentStatistics(string name)
        {
           
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
