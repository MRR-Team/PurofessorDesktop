using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class ActivityLogTests
    {
        [Fact]
        public void ActivityLog_CanBeCreatedAndPopulated()
        {
            var log = new ActivityLog
            {
                Id = 1,
                Description = "Log test",
                LogName = "Log",
                Event = "Create",
                SubjectType = "User",
                SubjectId = 42,
                CauserType = "System",
                CauserId = 1,
                Properties = new { key = "value" },
                CreatedAt = "2023-01-01",
                UpdatedAt = "2023-01-02"
            };

            Assert.Equal(1, log.Id);
            Assert.Equal("User", log.SubjectType);
            Assert.Equal(42, log.SubjectId);
        }

    }
}
