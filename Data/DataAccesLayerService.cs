using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataAccesLayerService : IDataAccesLayerService
    {
        #region seed
        public void Seed()
        {
            using var ctx = new StudentsDbContext();


            ctx.Add(new Student
            {
                Name = "Adrian Georgescu",
                Age = 31,
                Address = new Address

                {
                    City = "Giurgiu",
                    Street = "Morilor",
                    Number = 53
                }

            });


            ctx.Add(new Student
            {
                Name = "George Popescu",
                Age = 33,
                Address = new Address

                {
                    City = "Barlad",
                    Street = "Frunzelor",
                    Number = 4
                }

            });


            ctx.Add(new Student
            {
                Name = "Vasile Dumitrescu",
                Age = 43,
                Address = new Address

                {
                    City = "Hunedoara",
                    Street = "Viorelelor",
                    Number = 25
                }

            });


            ctx.Add(new Student
            {
                Name = "Florin Gheorghescu",
                Age = 27,
                Address = new Address

                {
                    City = "Constanta",
                    Street = "Soveja",
                    Number = 94
                }

            });


            ctx.Add(new Student
            {
                Name = "Alex Naumescu",
                Age = 22,
                Address = new Address

                {
                    City = "Timisoara",
                    Street = "Eroilor",
                    Number = 7
                }

            });

            ctx.SaveChanges();
        }
        #endregion


        public IEnumerable<Student> GetAllStudents()
        {
            using var ctx = new StudentsDbContext();
            return ctx.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            using var ctx = new StudentsDbContext();
            return ctx.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student CreateStudent(string name, int age)
        {
            using var ctx = new StudentsDbContext();
            var student = new Student { Name = name, Age = age };
            ctx.Add(student); ctx.SaveChanges();
            return student;
        }

        public Student CreateStudent(Student student)
        {
            using var ctx = new StudentsDbContext();

            if (ctx.Students.Any(s => s.Id == student.Id))
            {
                // todo throw exception
            }

            ctx.Add(student); ctx.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            using var ctx = new StudentsDbContext();

            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);

            if (student == null)
            {
                student = new Student();
                ctx.Add(student);
            }


            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();
            return student;
        }

        public void UpdateOrCreateStudentAddress(int studentId, Address newadress)
        {
            using var ctx = new StudentsDbContext();

            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                // throw exception
            }

            if (student.Address == null)
            {
                student.Address = new Address();
            }

            student.Address.Number = newadress.Number;
            student.Address.Street = newadress.Street;
            student.Address.City = newadress.City;

            ctx.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            StudentsDbContext ctx = null;
            try
            {
                ctx = new StudentsDbContext();
                var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

                if (student == null)
                {
                    throw new InvalidCastException($"student not found{studentId}");
                }
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
            finally
            {
                if (ctx != null)
                {
                    ctx.Dispose();
                }
            }
        }

        Student IDataAccesLayerService.DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
