namespace MVCApp.Models
{
    public class Space
    {
        [Key]
        public int SpaceId { get; set; }

        [Display(Name = "Стоимость аренды за день, руб")]
        public decimal RentCostPerDay { get; set; }

        [Display(Name = "Фото")]
        [Column(TypeName = "nvarchar")]
        public string? Photo { get; set; }

        [Display(Name = "Страна")]
        [Column(TypeName = "nvarchar")]
        public string Country { get; set; }

        [Display(Name = "Субъект")]
        [Column(TypeName = "nvarchar")]
        public string CountrySubject { get; set; }

        [Display(Name = "Город")]
        [Column(TypeName = "nvarchar")]
        public string City { get; set; }

        [Display(Name = "Улица")]
        [Column(TypeName = "nvarchar")]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        public int House { get; set; }

        [Display(Name = "Квартира")]
        public int? Apartment { get; set; }

        [Display(Name = "Корпус")]
        [Column(TypeName = "nvarchar")]
        public string? Corpus { get; set; }

        [Display(Name = "Номер телефона")]
        [Column(TypeName = "nvarchar")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Event> Events { get; } = new List<Event>();
    }
}
