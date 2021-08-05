using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    

    


    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("George's grade book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            book.GetStatistics();

            var stats = book.GetStatistics();
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average is {stats.Average:N3}. \nThe highest grade is {stats.High}. \nThe lowest grade is {stats.Low}.");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            static bool typeCheckInt(string input)
            {
                double number = 0.0;
                return double.TryParse(input, out number);
            }

            static void EnterGrades(IBook book)
            {

                while (true)
                {
                    Console.WriteLine($"Please enter a grade, or the word exit, to exit.\n");
                    var input = Console.ReadLine();
                    if (input == "exit")
                    {
                        break;

                    }
                    if (typeCheckInt(input) == false)
                    {
                        Console.WriteLine($"Invalid input, please enter a valid input.\n");
                        continue;
                    }

                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }

                }
            }

            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            //grades.Add(56.1);
            //var length = grades.Count;


            //Console.WriteLine(length);     

            //var result = 0.0;
            //var highGrade = double.MinValue;
            //var lowGrade = double.MaxValue;


            //foreach (double number in grades) 
            //{
            //    highGrade = Math.Max(number, highGrade);
            //    lowGrade = Math.Min(number, lowGrade);
            //    result += number;

            //}
            //var average = result / length;
            //Console.WriteLine(result);
            //Console.WriteLine($"The average is {average:N3}. \nThe highest grade is {highGrade}. \nThe lowest grade is {lowGrade}.");



            //if (args.Length > 0)
            //{ 

            //    Console.WriteLine("Hello " + args[0] + "!");
            //}
            //else 
            //{ 
            //    Console.WriteLine("Hello there.");
            //}



        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
    
}
