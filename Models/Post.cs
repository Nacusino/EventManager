namespace MVCApp.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Display(Name = "Название")]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
