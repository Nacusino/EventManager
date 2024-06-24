namespace MVCApp.Models
{
    public class ServicesList
    {
        [Key]
        public int ServiceListId { get; set; }

        [Display(Name = "Идентификатор события")]
        public int EventId { get; set; }

        [Display(Name = "Идентификатор услуги")]
        public int ServiceId { get; set; }

        [Display(Name = "Событие")]
        public virtual Event Event { get; set; }

        [Display(Name = "Услуга")]
        public virtual Service Service { get; set; }
    }
}
