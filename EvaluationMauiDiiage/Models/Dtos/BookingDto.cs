using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Models.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
