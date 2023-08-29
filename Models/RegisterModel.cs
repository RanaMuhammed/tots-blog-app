using System.ComponentModel.DataAnnotations;

namespace tots.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { set; get; }
        public EducationLevel level { set; get; }
        public string University { set; get; }
        public string Track { set; get; }
        public string Bio { get; set; }
        public int YearOfBirth { set; get; }
    }
}
