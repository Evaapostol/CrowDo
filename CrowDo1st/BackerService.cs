using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrowDo1st
{
    class BackerService : IBackerService
    {
        public bool FundProject(string email, string projectName, decimal amount, string titleOfPackage)
        {
            var context = new CrowDoDbContext();
            var proj = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var user = context.Set<User>().SingleOrDefault(u => u.Email == email);
            var fp = new UserProject();
            user.UserProject.Add(fp);
            proj.UserProject.Add(fp);
            proj.Balance += amount;
            if (proj.Balance >= proj.Goal)
            {
                proj.Active = false;
                context.SaveChanges();
            }
            context.SaveChanges();
            return true;
        }
        public List<String> ViewPendingProjects()
        {
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>();
            var pendingProjects = new List<String>();
            foreach(var p in projects)
            {
                if(p.Active == true)
                {
                    pendingProjects.Add(p.Title);
                }
            }
            return pendingProjects;
        }

        public List<String> ViewProjects()
        {
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>();
            var allProjects = new List<String>();
            foreach (var p in projects)
            {

                allProjects.Add(p.Title);
                
            }
            return allProjects;
        }

        public List<ProjectProfilePage> FundedProjects(string email)
        {
            var context = new CrowDoDbContext();
            var fundedProjects = new List<ProjectProfilePage>();
            var user = context.Set<User>().SingleOrDefault(e => e.Email == email);
            int id = user.UserId;
            var proj = context.Set<UserProject>().Where(u => u.UserId == id);
            foreach (var f in proj)
            {
                var fp = context.Set<ProjectProfilePage>().Where(pid => pid.ProjectId == f.ProjectId);
                foreach (var item in fp)
                {
                    fundedProjects.Add(item);
                }
            }
            return fundedProjects;

        }

        public List<String> ViewByCategory(string category)
        {
            var context = new CrowDoDbContext();
            var items = context.Set<ProjectProfilePage>().Where(c => c.Category == category);
            var projectsByCategory = new List<String>();
            foreach (var p in items)
            {
                projectsByCategory.Add(p.Title);
            }
            return projectsByCategory;
        }

        public List<String> ViewByText(string text)
        {
            var context = new CrowDoDbContext();
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuation));
            var projects = context.Set<ProjectProfilePage>();
            foreach(var item in words)
                foreach(var item1 in projects)
                {
                    var array = item1.Title.Split(' ');
                    foreach(var it in array)
                    {
                        if(item == it)
                        {
                            projects.Add(item1);
                        }
                    }
                }
            var results = new List<String>();
            foreach(var r in projects)
            {
                results.Add(r.Title);
            }
            return results;
        }
    }
}
