namespace MVCApp.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }

        [Display(Name = "Название")]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Display(Name = "Наценка за организацию")]
        public double ExtraCharge { get; set; }

        public virtual ICollection<ApplicationForEvent> ApplicationsForEvent { get; } = new List<ApplicationForEvent>();
    }
}
