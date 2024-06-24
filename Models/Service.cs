namespace MVCApp.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Display(Name = "Название")]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [Display(Name = "Номер телефона")]
        [Column(TypeName = "nvarchar")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Стоимость, руб")]
        public decimal Cost { get; set; }

        public virtual ICollection<ServicesList> ServicesLists { get; } = new List<ServicesList>();
    }
}
