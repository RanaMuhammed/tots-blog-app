using Microsoft.AspNetCore.Identity;

namespace tots.Models
{
    public enum EducationLevel
    {
        Freshman,
        Junior,
        Semaphore,
        Senior,
        Graduate
    }

    public class User : IdentityUser
    {
        public string? Nickname { set; get; }
        public EducationLevel level { set; get; }
        public string University { set; get; }
        public string Track { set; get; }
        public string Bio { get; set; }
        public int YearOfBirth { set; get; }

    }
}
