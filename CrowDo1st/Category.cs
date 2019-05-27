using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProjectCategory> ProjectCategory { get; set; }

        public Category()
        {
            ProjectCategory = new List<ProjectCategory>();
        }
    }
}
