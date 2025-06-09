using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        // Właściwości ofensywne/defensywne
        public bool Attack_Damage { get; set; }
        public bool Magic_Damage { get; set; }
        public bool Shield { get; set; }
        public bool Heals { get; set; }
        public bool Tanky { get; set; }
        public bool Squishy { get; set; }
        public bool Has_Cc { get; set; }
        public bool Dash { get; set; }
        public bool Poke { get; set; }
        public bool Can_One_Shot { get; set; }
        public bool Late_Game { get; set; }

        // Wskaźniki kontr
        public int Is_Good_Against_Attack_Damage { get; set; }
        public int Is_Good_Against_Magic_Damage { get; set; }
        public int Is_Good_Against_Shield { get; set; }
        public int Is_Good_Against_Heals { get; set; }
        public int Is_Good_Against_Tanky { get; set; }
        public int Is_Good_Against_Squish { get; set; }
        public int Is_Good_Against_Has_Cc { get; set; }
        public int Is_Good_Against_Dash { get; set; }
        public int Is_Good_Against_Poke { get; set; }
        public int Is_Good_Against_Can_One_Shot { get; set; }
        public int Is_Good_Against_Late_Game { get; set; }

        public string Photo { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class ChampionSearchStats
    {
        public Champion Champion { get; set; }
        public int Total { get; set; }
    }
}