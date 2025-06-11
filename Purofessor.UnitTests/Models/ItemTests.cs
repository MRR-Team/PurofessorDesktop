using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purofessor.Models;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class ItemTests
    {
        [Fact]
        public void Item_CanBeCreatedWithValues()
        {
            var item = new Item
            {
                Id = 7,
                Name = "Luden's Tempest",
                Role = "Mage",
                MagicDamage = true,
                IsGoodAgainstTanky = true
            };

            Assert.Equal("Luden's Tempest", item.Name);
            Assert.True(item.MagicDamage);
            Assert.True(item.IsGoodAgainstTanky);
        }

    }
}
