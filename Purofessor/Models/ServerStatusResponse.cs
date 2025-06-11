using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    public class ServerStatusResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<string>? Locales { get; set; }
        public List<object>? Maintenances { get; set; }
        public List<object>? Incidents { get; set; }
    }
}
