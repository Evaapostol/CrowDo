using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IProjectCreatorService
    {
        ProjectProfilePage ProjectCreation(string email, string title, string description, DateTime dateOfCreation, string category, DateTime deadline);
        bool AddProject(string email, ProjectProfilePage project);
        ProjectProfilePage ProjectEdit(string currenttitle, string title, string description, DateTime datetime);
        Videos AddVideo(string projectName, string videoName);
        bool DeleteVideo(string projectName, string videoName);
        Photos AddPhoto(string projectName, string photoName);
        bool DeletePhoto(string projectName, string photoName);
       
       
    }
}
