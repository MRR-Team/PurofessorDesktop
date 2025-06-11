using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class ChampionTests
    {
        [Fact]
        public void Champion_CanBeCreatedAndPopulated()
        {
            var champ = new Champion
            {
                Id = 10,
                Name = "Ahri",
                Role = "Mage",
                Attack_Damage = false,
                Magic_Damage = true,
                Has_Cc = true,
                Is_Good_Against_Poke = 3,
                Created_At = DateTime.Now,
                IsAvailable = true
            };

            Assert.Equal("Ahri", champ.Name);
            Assert.True(champ.Magic_Damage);
            Assert.True(champ.Has_Cc);
            Assert.Equal(3, champ.Is_Good_Against_Poke);
        }

    }
}
