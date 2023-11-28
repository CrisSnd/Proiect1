namespace Data.Models
{
    public class Course
    {
     public int Id { get; set; }
     public string Name {  get; set; }   

     public List<Student> Students { get; set; } = new List<Student>();
    
    public List <Course> Courses { get; set; } =new List<Course>();
    }
}