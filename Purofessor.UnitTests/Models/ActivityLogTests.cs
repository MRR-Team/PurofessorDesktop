using Purofessor.Models;
using System;
using System.Text.Json;
using Xunit;

namespace Purofessor.UnitTests.Models
{
    public class ActivityLogTests
    {
        [Fact]
        public void ActivityLog_CanBeCreatedAndPopulated()
        {
            var json = JsonSerializer.SerializeToElement(new { key = "value" });

            var log = new ActivityLog
            {
                Id = 1,
                Description = "Log test",
                LogName = "Log",
                SubjectType = "User",
                SubjectId = 42,
                CauserType = "System",
                CauserId = 1,
                Properties = json,
                CreatedAt = new DateTime(2023, 1, 1)
            };

            Assert.Equal(1, log.Id);
            Assert.Equal("User", log.SubjectType);
            Assert.Equal(42, log.SubjectId);
        }
    }
}
