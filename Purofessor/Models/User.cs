using System.Text.Json.Serialization;
using Purofessor.Helpers;

namespace Purofessor.Models
{
    public class User : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        private bool _isAdmin;

        [JsonPropertyName("is_admin")] // <- Mapowanie JSON -> właściwość
        public bool IsAdmin
        {
            get => _isAdmin;
            set => SetField(ref _isAdmin, value);
        }

        private string _token;
        public string Token
        {
            get => _token;
            set => SetField(ref _token, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetField(ref _password, value);
        }
    }
}
