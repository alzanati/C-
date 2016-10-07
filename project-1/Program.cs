using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Course math = new Course("Math", 302);
            Course physics = new Course("Physics2", 403);
            Course chemsitry = new Course("Chemsitry", 106);
            Course biology = new Course("biology", 102);
            Course english = new Course("english", 304);

            Courses myCourses = new Courses();
            myCourses[0] = math;
            myCourses[1] = physics;
            myCourses[2] = chemsitry;
            myCourses[3] = biology;
            myCourses[4] = english;

            while(myCourses.HasNext())
            {
                Console.WriteLine(myCourses.Next().name);
            }
        }
    }

    public class Course
    {
        public string name {set; get;}
        public int id {set; get;}

        public Course()
        {

        }

        public Course(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public virtual void Print()
        {
            Console.WriteLine("Only one Course");
        }
    }

    public interface ICourse
    {
        bool HasNext();

        void Reset();

        Course Next();
    }

    public class Courses : Course, ICourse
    {
        Course[] _courses;
        int count = 0;
        int index = -1;

        public Courses() 
        {
            _courses = new Course[1];
        }

        public Course this[int index]
        {
            get
            {
                return _courses[index];
            }
            set
            {
                _courses[index] = value;
                Array.Resize<Course>(ref _courses, _courses.Length + 1);
                count += 1;
                index = count + 1;
            }
        }

        public bool HasNext()
        {
            bool temp;
            if (count != 0)
            {
                temp = true;
                count -= 1;
                index = count;
            }
            else
            {
                temp = false;
            }
            return temp;
        }

        public void Reset()
        {
            count = 0;
            _courses = new Course[1];
            index = -1;
        }

        public Course Next()
        {
            return _courses[index];
        }

        public override void Print()
        {
            Console.WriteLine("Many Courses");
        }
    }
    

    public class Student
    {
        public string name { set; get; }
        public int id { set; get; }
        public Courses courses{get;}

        public Student(Courses sCourses)
        {
            this.courses = sCourses;
        }
    }
}
