namespace EvaluationMauiDiiage.Models
{
    public class MeetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsActive { get; set; }
    }
}
