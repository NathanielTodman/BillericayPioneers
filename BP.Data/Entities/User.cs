using BP.Data;
using System.ComponentModel.DataAnnotations;

namespace BP.Data
{
    public class User
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public Role Access { get; set; } = Role.BasicUser;

        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }



    }
    public enum Role {
        [Display(Name = "BasicUser")]
        BasicUser = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "Manager")]
        Manager = 4 }
}
