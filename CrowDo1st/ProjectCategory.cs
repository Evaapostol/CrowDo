using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public class ProjectCategory
    {
        public int ProjectId { get; set; }
        public ProjectProfilePage Project { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProjectCategory()
        {
        }
    }
}
