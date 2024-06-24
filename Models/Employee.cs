namespace MVCApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Фамилия")]
        [Column(TypeName = "nvarchar")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [Column(TypeName = "nvarchar")]
        public string Firstname { get; set; }

        [Display(Name = "Отчество")]
        [Column(TypeName = "nvarchar")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Номер телефона")]
        [Column(TypeName = "nvarchar")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Серия паспорта")]
        [Column(TypeName = "nvarchar")]
        public string PassportSeries { get; set; }

        [Display(Name = "Номер паспорта")]
        [Column(TypeName = "nvarchar")]
        public string PassportNumber { get; set; }

        [Display(Name = "Кем выдан паспорт")]
        [Column(TypeName = "nvarchar")]
        public string PassportIssuedBy { get; set; }

        [Display(Name = "Когда выдан паспорт")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PassportDateOfIssue { get; set; }

        [Display(Name = "Фото")]
        [Column(TypeName = "nvarchar")]
        public string? Photo { get; set; }

        [Display(Name = "Стоимость проведения мероприятия, руб")]
        public decimal? EventCarryingCost { get; set; }
        [Display(Name = "Иденификатор должности")]
        public int PostId { get; set; }


        public virtual ICollection<Event> Employees { get; } = new List<Event>();
        public virtual ICollection<Event> Hosts { get; } = new List<Event>();

        [Display(Name = "Должность")]
        public virtual Post Post { get; set; }
    }

}
