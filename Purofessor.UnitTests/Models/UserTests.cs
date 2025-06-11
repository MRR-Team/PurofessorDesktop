using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class UserTests
    {
        [Fact]
        public void User_CanBeSetAndGetValues()
        {
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "test@example.com",
                IsAdmin = true,
                Token = "xyz",
                Password = "secret"
            };

            Assert.Equal(1, user.Id);
            Assert.True(user.IsAdmin);
            Assert.Equal("xyz", user.Token);
        }

    }
}
