using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IBackerService
    {
        bool FundProject(string email, string projectName, decimal amount);
        

    }
    


    public class BackerService : IBackerService
    {
        public bool FundProject(string email, string projectName, decimal amount) //string titleOfPackage)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if (project==null)
            {
                return false;
            }
            var user = context.Set<User>().SingleOrDefault(u => u.Email == email);
            if (user==null)
            {
                return false;
            }
            if (!user.Activity)
            {
                user.Activity = true;
            }
            var fp = new UserProject();
            user.UserProject.Add(fp);
            project.UserProject.Add(fp);
            project.Balance += amount;
            if (project.Balance >= project.Demandedfunds)
            {
                project.Active = false;
                context.SaveChanges();
            }
            context.SaveChanges();
            return true;
        }

        public List<ProjectProfilePage> BackersFundedProjects(string email)
        {
            var context = new CrowDoDbContext();
            var fundedProjects = new List<ProjectProfilePage>();
            var user = context.Set<User>().SingleOrDefault(e => e.Email == email);
            int id = user.UserId;
            var proj = context.Set<UserProject>().Where(u => u.UserId == id);
            foreach (var f in proj)
            {
                var fp = context.Set<ProjectProfilePage>().Where(pid => pid.ProjectProfilePageId == f.ProjectProfilePageId);
                foreach (var item in fp)
                {
                    fundedProjects.Add(item);
                    Console.WriteLine($"{item.Title},{item.Balance}");
                }
            }
            return fundedProjects;

        }



    }
}


