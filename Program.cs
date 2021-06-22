using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GPA_Calculator
{
    class Program
    {
        // Calculate Quality Point for each subject
        public static List<double> QualityPoint(List<double> courseUnitList, List<double> courseGradeUnitList)
        {
            List<double> qualityPointList = new List<double>();
            
            for (int i = 0; i < courseUnitList.Count; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    double qualityPoint = courseUnitList[i] * courseGradeUnitList[j];
                    qualityPointList.Add(qualityPoint);
                }
            }
            return qualityPointList; 
        }

        // Calculate Total Quality Point for all subjects
        public static double TotalQualityPoint(List<double> qualityPointList)
        {
            double qualityPointSummation = 0;
            for (int i = 0; i < qualityPointList.Count; i++)
            {
                qualityPointSummation += qualityPointList[i];
            }
            return qualityPointSummation;
        }

        // Calculate Total Grade Unit
        public static double TotalGradeUnit(List<double> qualityGradeUnitList)
        {
            double qualityGradeUnitSummation = 0;
            for (int i = 0; i < qualityGradeUnitList.Count; i++)
            {
                qualityGradeUnitSummation += qualityGradeUnitList[i];
            }
            return qualityGradeUnitSummation;
        }

        // Calculate Student's GPA
        public static double GPA(double totalQualityPoint, double totalGradeUnit)
        {
            double gpa = Math.Round(totalQualityPoint / totalGradeUnit, 2, MidpointRounding.AwayFromZero);
            return gpa;
        }
        static void Main(string[] args)
        {
            CourseName_Code_Input();
        }
        public static void CourseName_Code_Input()
        {
            List<string> courseNameList = new List<string>();
            List<double> courseUnitList = new List<double>();
            List<int> courseScoreList = new List<int>();
            List<char> courseGradeList = new List<char>();
            List<double> courseGradeUnitList = new List<double>();

            // Collecting Student's course details and storing them in designated list
            bool finished = true;
            while (finished)
            {
                Console.WriteLine("Please enter your course details below\n");
                Console.Write("Enter course name and code:\t");
                string userResponseName = Console.ReadLine();
                while (!UserResponseValidation.CourseNameCodeValidation(userResponseName))
                {
                    Console.Write("Please enter a valid course code (eg: ABC 123):\t");
                    userResponseName = Console.ReadLine();
                }

                Console.Write("\n");

                Console.Write("Enter course unit:\t");
                string userResponseUnit = Console.ReadLine();
                while (!UserResponseValidation.CourseUnitValidation(userResponseUnit))
                {
                    Console.Write("Course unit should be between 1 and 9:\t");
                    userResponseUnit = Console.ReadLine();
                }
                double convertUserResponseUnit = double.Parse(userResponseUnit);
                Console.Write("\n");

                Console.Write("Enter course score:\t");
                string userResponseScore = Console.ReadLine();
                while (!UserResponseValidation.CourseScoreValidation(userResponseScore))
                {
                    Console.Write("Course score should be between 0 and 100:\t");
                    userResponseScore = Console.ReadLine();
                }
                int convertUserResponseScore = int.Parse(userResponseScore);
             
                char userGrade = GetGrade(convertUserResponseScore);
                int userGradeUnit = GetGradeUnit(GetGrade(convertUserResponseScore));

                courseNameList.Add(userResponseName);
                courseUnitList.Add(convertUserResponseUnit);
                courseScoreList.Add(convertUserResponseScore);
                courseGradeList.Add(userGrade);
                courseGradeUnitList.Add(userGradeUnit);

                Console.Write("Do you want to input another course? Type 'Yes' or 'No'    ");
                string inputAnotherCourse = Console.ReadLine().ToUpper();
                if (inputAnotherCourse == "YES")
                {
                    finished = true;
                }
                else
                {
                    finished = false;
                }
            }

            // Display Student's result in a tabular format
            Console.Clear();

            Console.WriteLine("|---------------|----------------|----------------|----------------|");
            Console.WriteLine("| COURSE & CODE |   COURSE UNIT  |      GRADE     |    GRADE-UNIT  |");
            Console.WriteLine("|---------------|----------------|----------------|----------------|");
            for (int i = 0; i < courseNameList.Count; i++)
            {
                if ((courseNameList[i].Length) <= 6)
                {
                    Console.Write("| " + courseNameList[i] + "\t" + "| ");
                }
                else
                {
                    Console.Write("| " + courseNameList[i] + " " + "\t" + "| ");
                }

                for (int j = i; j <= i; j++)
                {
                    Console.Write("     " + courseUnitList[j] + "\t" + " | ");
                }

                for (int k = i; k <= i; k++)
                {
                    Console.Write("     " + courseGradeList[k] + "\t" + "  | ");
                }

                for (int l = i; l <= i; l++)
                {
                    Console.Write("     " + courseGradeUnitList[l] + "\t" + "   | ");
                }

                Console.Write("\n");
            }
            Console.WriteLine("|------------------------------------------------------------------|");
            Console.WriteLine("");

            List<double> QP = QualityPoint(courseUnitList, courseGradeUnitList);
            double TQP = TotalQualityPoint(QP);
            double TGU = TotalGradeUnit(courseGradeUnitList);
            double gpa = GPA(TQP, TGU);

            Console.WriteLine("Your GPA is  {0} to 2 decimal places.", gpa);
        }

        // Using Student's score to get the Grade
        public static char GetGrade(int student_scores)
        {
            char grade = 'A';
            switch (student_scores)
            {
                case int n when (n >= 70 && n <= 100):
                    grade = 'A';
                    break;

                case int n when (n >= 60 && n <= 69):
                    grade = 'B';
                    break;

                case int n when (n >= 50 && n <= 59):
                    grade = 'C';
                    break;

                case int n when (n >= 45 && n <= 49):
                    grade = 'D';
                    break;

                case int n when (n >= 40 && n <= 44):
                    grade = 'E';
                    break;

                case int n when (n >= 0 && n <= 39):
                    grade = 'F';
                    break;
            }
            return grade;
        }

        // Using Student's Grade to get the Grade Unit
        public static int GetGradeUnit(char GetGrade)
        {
            int gradeUnit = 0;
            switch (GetGrade)
            {
                case 'A':
                    gradeUnit = 5;
                    break;

                case 'B':
                    gradeUnit = 4;
                    break;

                case 'C':
                    gradeUnit = 3;
                    break;

                case 'D':
                    gradeUnit = 2;
                    break;

                case 'E':
                    gradeUnit = 1;
                    break;

                case 'F':
                    gradeUnit = 0;
                    break;
            }
            return gradeUnit;
        }
      
    }

    // Validating Student's inputs
    public static class UserResponseValidation
    {
        public static bool CourseNameCodeValidation(string courseNameCodeValidate)
        {
            string coursenamePattern = @"^[a-zA-Z]{1,4}#?\s[0-9]{3}$";
            return Regex.IsMatch(courseNameCodeValidate, coursenamePattern);
        }
        public static bool CourseUnitValidation(string courseUnitValidate)
        {
            string courseUnitPattern = @"^[1-9]$";
            return Regex.IsMatch(courseUnitValidate, courseUnitPattern);
        }
        public static bool CourseScoreValidation(string courseScoreValidate)
        {
            string courseScorePattern = @"^1?[0-9]?[0-9]$";
            return Regex.IsMatch(courseScoreValidate, courseScorePattern);
        }
    }
}

