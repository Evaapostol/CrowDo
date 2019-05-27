using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IBackerService
    {
        bool FundProject(string email, string projectName, decimal amount, string titleOfPackage);
        List<String> ViewPendingProjects();
        List<String> ViewProjects();
        List<ProjectProfilePage> FundedProjects(string email);
        List<String> ViewByCategory(ProjectCategoryId category);
        List<String> ViewByText(string text);

    }
}
