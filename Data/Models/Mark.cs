namespace Data.Models
{
    public class Mark
    {
        public int Id { get; set; }

        public int Valoare { get; set; }
        public DateTime OraAcordarii { get; set; }

        public int? CourseId { get; set; }   
        public Course Course { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
