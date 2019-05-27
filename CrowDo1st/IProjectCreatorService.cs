using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IProjectCreatorService
    {
        ProjectProfilePage ProjectCreation(string email, string title, string description, Category category, int scope);
        ProjectProfilePage ProjectEdit(string currenttitle, string title, string description, int timeScope);
        ////Package CreateFundPackages();
        //Updates CreateUpdates();
    }
}
