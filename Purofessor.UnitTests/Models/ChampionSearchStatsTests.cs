using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class ChampionSearchStatsTests
    {
        [Fact]
        public void ChampionSearchStats_HoldsChampionAndTotal()
        {
            var champ = new Champion { Name = "Yasuo" };
            var stats = new ChampionSearchStats
            {
                Champion = champ,
                Total = 1337
            };

            Assert.Equal("Yasuo", stats.Champion.Name);
            Assert.Equal(1337, stats.Total);
        }

    }
}
