using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrowDo1st
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Column("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("Date of registration")]
        public DateTime DateOfRegister { get; set; }
        public string Location { get; set; }
        [Column("Card number")]
        [Required(AllowEmptyStrings = false)]
        public long CardNumber { get; set; }
        //public List<ProjectProfilePage> Projects { get; set; }
        public List<ProjectProfilePage> CreatedProjects { get; set; }
        public List<UserProject> UserProject { get; set; }

        public User()
        {
            CreatedProjects = new List<ProjectProfilePage>();
            UserProject = new List<UserProject>();
        }
    }
}
