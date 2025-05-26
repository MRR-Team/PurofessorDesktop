using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string emailverifiedat { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public bool is_admin { get; set; }
    }

}