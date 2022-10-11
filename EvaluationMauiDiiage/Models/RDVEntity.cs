using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationMauiDiiage.Models
{
    public class RDVEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsActive { get; set; }
    }
}
