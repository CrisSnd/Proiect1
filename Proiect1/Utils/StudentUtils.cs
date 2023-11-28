using Data.Models;
using Proiect1.Dtos;


namespace Proiect1.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto( this Student student)

        {
            if (student == null)
            {
                return null;
            }


           return new StudentToGetDto
                  {
                    Id = student.Id,
                   Name = student.Name,
                   Age = student.Age
                  };
        }

    public static Student ToEntity(this StudentToCreateDto student)
        {
            if(student == null)
            {
                return null;
            }


            return new Student
            {
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }


            return new Student
            {
                Id=student.Id,  
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Address ToEntity (this AdressToUpdateDto adressToUpdate)
        {
            if(adressToUpdate == null)
            {
                return null;
            }

            return new Address
            {
                Number = adressToUpdate.Number,
                City = adressToUpdate.City,
                Street = adressToUpdate.Street
            };

        }

    }
}
