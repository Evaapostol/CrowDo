using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public class UserProject 
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int ProjectId { get; set; }
        public ProjectProfilePage Project { get; set; }
        
        public UserProject()
        {

        }
    }

}
