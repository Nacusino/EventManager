namespace MVCApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Имя")]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Display(Name = "Дата начала")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата конца")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Время начала")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Время конца")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Отзыв после мероприятия")]
        [Column(TypeName = "nvarchar")]
        public string? ReviewAfterEvent { get; set; }

        [Display(Name = "Оценка после мероприятия")]
        public int? GradeAfterEvent { get; set; }

        [Display(Name = "Идентификатор заявки")]
        public int ApplicationId { get; set; }

        [Display(Name = "Идентификатор помещения")]
        public int SpaceId { get; set; }

        [Display(Name = "Идентификатор организатора")]
        public int? HostId { get; set; }

        [Display(Name = "Идентификатор ведущего")]
        public int EmployeeId { get; set; }

        [Display(Name = "Заявка")]
        public virtual ApplicationForEvent Application { get; set; }

        [Display(Name = "Ведущий")]
        public virtual Employee? Employee { get; set; }

        [Display(Name = "Организатор")]
        public virtual Employee Host { get; set; }

        public virtual ICollection<ServicesList> ServicesLists { get; } = new List<ServicesList>();

        [Display(Name = "Помещение")]
        public virtual Space Space { get; set; }
    }
}
