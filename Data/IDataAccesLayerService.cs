using Data.Models;

namespace Data
{
    public interface IDataAccesLayerService
    {
        Student CreateStudent(string name, int age);
        Student CreateStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        void UpdateOrCreateStudentAddress(int studentId, Address newadress);
        Student UpdateStudent(Student studentToUpdate);

        Student DeleteStudent(int studentId);

    }
}