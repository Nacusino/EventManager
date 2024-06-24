namespace MVCApp.Models
{
    [Display(Name = "Заявка на мероприятие")]
    public class ApplicationForEvent
    {
        [Key]
        public int ApplicationId { get; set; }
        [Display(Name = "Описание помещения")]
        [Column(TypeName = "nvarchar")]
        public string SpaceDescription { get; set; }

        [Display(Name = "Желаемая дата начала")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DesiredStartDate { get; set; }

        [Display(Name = "Желаемая дата конца")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DesiredEndDate { get; set; }

        [Display(Name = "Желаемое время начала")]
        public TimeSpan DesiredStartTime { get; set; }

        [Display(Name = "Желаемое время конца")]
        public TimeSpan DesiredEndTime { get; set; }

        [Display(Name = "Описание услуги")]
        [Column(TypeName = "nvarchar")]
        public string? ServicesDescription { get; set; }

        [Display(Name = "Другие пожелания")]
        [Column(TypeName = "nvarchar")]
        public string? OtherRequests { get; set; }


        [Display(Name = "Идентификатор заказчика")]
        public int CustomerId { get; set; }
        [Display(Name = "Идентификатор типа мероприятия")]
        public int EventTypeId { get; set; }
        [Display(Name = "Заказчик")]
        public virtual Customer Customer { get; set; }
        [Display(Name = "Тип мероприятия")]
        public virtual EventType EventType { get; set; }

        public virtual ICollection<Event> Events { get; } = new List<Event>();
    }
}
