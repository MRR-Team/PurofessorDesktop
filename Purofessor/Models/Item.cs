using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace Purofessor.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool AttackDamage { get; set; }
        public bool MagicDamage { get; set; }
        public bool Shield { get; set; }
        public bool Heals { get; set; }
        public bool Tanky { get; set; }
        public bool Squishy { get; set; }
        public bool HasCC { get; set; }
        public bool Dash { get; set; }
        public bool Poke { get; set; }
        public bool CanOneShot { get; set; }
        public bool LateGame { get; set; }
        public bool IsGoodAgainstAttackDamage { get; set; }
        public bool IsGoodAgainstMagicDamage { get; set; }
        public bool IsGoodAgainstShield { get; set; }
        public bool IsGoodAgainstHeals { get; set; }
        public bool IsGoodAgainstTanky { get; set; }
        public bool IsGoodAgainstSquish { get; set; }
        public bool IsGoodAgainstHasCC { get; set; }
        public bool IsGoodAgainstDash { get; set; }
        public bool IsGoodAgainstPoke { get; set; }
        public bool IsGoodAgainstCanOneShot { get; set; }
        public bool IsGoodAgainstLateGame { get; set; }
    }
}
