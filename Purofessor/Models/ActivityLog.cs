using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LogName { get; set; }
        public string Event { get; set; }
        public string SubjectType { get; set; }
        public int? SubjectId { get; set; }
        public string CauserType { get; set; }
        public int? CauserId { get; set; }
        public object Properties { get; set; } // Możesz to potem doprecyzować
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

