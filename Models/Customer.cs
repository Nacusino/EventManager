
namespace MVCApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Фамилия")]
        [Column(TypeName = "nvarchar")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [Column(TypeName = "nvarchar")]
        public string Firstname { get; set; }

        [Display(Name = "Отчество")]
        [Column(TypeName = "nvarchar")]
        public string Patronymic { get; set; }

        [Display(Name = "Имя организации")]
        [Column(TypeName = "nvarchar")]
        public string? NameOfOrganization { get; set; }

        [Display(Name = "Номер телефона")]
        [Column(TypeName = "nvarchar")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<ApplicationForEvent> ApplicationsForEvent { get; } = new List<ApplicationForEvent>();
    }

}
