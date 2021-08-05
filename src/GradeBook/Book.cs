using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{



	public delegate void GradeAddedDelegate(object sender, EventArgs args);
	
	public class DiskBook : Book
    {
		public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
			using (var writer = File.AppendText($"{Name}.txt"))
            {
				writer.WriteLine(grade);
                if (GradeAdded != null)
                {
					GradeAdded(this, new EventArgs());
                }
            }
				

			
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }


	public class NamedObject
    {
		public NamedObject(string name)
        {
			Name = name;
        }

		public string Name
        {
			get;
			set;
        }
    }
	
	public interface IBook
    {
		void AddGrade(double grade);
		Statistics GetStatistics();
		string Name { get; }
		event GradeAddedDelegate GradeAdded;
    }


	public abstract class Book : NamedObject, IBook
	{
        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

		public abstract Statistics GetStatistics();
        

        public Book(string name) : base(name)
        {

        }
		
        
    }



	public class InMemoryBook : Book
	{

		public InMemoryBook(string name) : base(name)
        {
			grades = new List<double>();
			Name = name;
        }

		public void AddGrade(char letter)
        {
			switch(letter)
            {
				case 'A':
					AddGrade(90);
					break;

				case 'B':
					AddGrade(80);
					break;

				case 'C':
					AddGrade(70);
					break;

				default:
					AddGrade(0);
					break;
			}
        }

		public override void AddGrade(double grade)
		{
			if(grade <= 100 && grade >=0)
            {
				grades.Add(grade);
				Console.WriteLine($"Grade added to the list.\n");
                if (GradeAdded != null)
                {
					GradeAdded(this, new EventArgs());
                }
			}
            else
            {

				throw new ArgumentException($"Invalid grade, {nameof(grade)} was not added to the list\n");
			}

		}

		public override event GradeAddedDelegate GradeAdded;


		public override Statistics GetStatistics() 
		{
		
			var result = new Statistics();
			


			for(var i = 0; i < grades.Count; i += 1)
			{
               
				result.add(grades[i]);
				
				
				

			} 
	

			
			return result;
		}

		private List<double> grades;
		
		
		
		/* {
			 get 
			 {
				 return name;
			 }
			 set
			 {
				 if (!string.IsNullOrEmpty(value))
				 {
					 name = value;
				 }



			 }
		 }*/

		public const string CATEGORY = "Science"; 

		
	}
}