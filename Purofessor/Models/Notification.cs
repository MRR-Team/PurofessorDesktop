using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    public class Notification
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? NotifiableType { get; set; }
        public int? NotifiableId { get; set; }
        public NotificationData? Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }

    public class NotificationData
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? Type { get; set; }
    }
}