using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrowDo1st
{
   public class ProjectCreatorService : IProjectCreatorService
    {
        public bool AddProject(string email, ProjectProfilePage project)
        {
            var context = new CrowDoDbContext();
            var projectExists = context.Set<ProjectProfilePage>().Where(p => p.Title == project.Title).Any();
            if (projectExists)
            {
                return false;
            }
            var user = context.Set<User>().Where(c => c.Email == email).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            var categoryExists = context.Set<Category>().Where(c => c.Name == project.Category).SingleOrDefault(); ;
            if (categoryExists == null)
            {
                var newCategory = new Category
                {
                    Name = project.Category
                };
                newCategory.Projects.Add(project);
                context.Add(newCategory);
            }
            else
            {
                categoryExists.Projects.Add(project);
                context.Update(categoryExists);
            }
            project.Creator = user;
            user.CreatedProjects.Add(project);
            context.Update(user);
            context.Add(project);
            context.SaveChanges();
            return true;

        }

        public ProjectProfilePage ProjectCreation(string email, string title, string description, DateTime dateOfCreation,
            string category, DateTime deadline)
        {
            var project = new ProjectProfilePage
            {
                Title = title,
                Description = description,
                Category = category,
                Balance = 0,
                DateOfCreation = dateOfCreation,
                DeadLine = deadline,
                
            };

            if (DateTime.Compare(DateTime.Now, project.DeadLine) < 0)
            {
                project.Active = false;
            }
            project.Active = true;

            if (AddProject(email, project))
            {
                return project;
            }
            return null;
        }

        public ProjectProfilePage ProjectEdit(string currenttitle, string title, string description, DateTime deadline)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(c => c.Title == currenttitle);
            if (project != null)
            {
                project.Title = title;
                project.Description = description;
                project.DeadLine = deadline;
                context.SaveChanges();
            }
            return project;
        }

        public Videos AddVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var newVideo = new Videos
            {
                Name = videoName
            };
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if (project != null)
            {
                project.Videos.Add(newVideo);
                context.SaveChanges();
                return newVideo;
            }
            return null;
        }
        public bool DeleteVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var video = context.Set<Videos>().SingleOrDefault(l => l.Name == videoName);
            context.Remove(video);
            context.SaveChanges();
            return true;
        }
        

        public Photos AddPhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var newPhoto = new Photos
            {
                Name = photoName
            };
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if(project==null)
            {
                return null;
            }
            project.Photos.Add(newPhoto);
            context.SaveChanges();
            return newPhoto;
        }

        public bool DeletePhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var photo = context.Set<Photos>().SingleOrDefault(l => l.Name == photoName);
            context.Remove(photo);
            context.SaveChanges();
            return true;
        }
        //public Package CreateFundPackages(string title, string description, decimal lowerBound, string reward, string projectTitle)
        //{

        //    var context = new CrowDoDbContext();
        //    var package = new Package
        //    {
        //        Title = title,
        //        Description = description,
        //        LowerBound = lowerBound,
        //        Reward = reward
        //    };
        //    context.Add(package);
        //    context.SaveChanges();
        //    if(AddPackage(projectTitle, package))
        //    {
        //        return package;
        //    }
        //    return null;
        //}

        //public bool AddPackage(string projectTitle, Package package)
        //{
        //    var context = new CrowDoDbContext();
        //    var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectTitle);
        //    foreach (var p in project.Packages)
        //    {
        //        if (package.Title == p.Title)
        //        {
        //            return false;
        //        }
        //    }
        //    if (project != null)
        //    {
        //        project.Packages.Add(package);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        


    }


}




