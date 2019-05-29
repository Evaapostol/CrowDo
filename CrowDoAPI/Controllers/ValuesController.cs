using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowDo1st;
using Microsoft.AspNetCore.Mvc;

namespace CrowDo1stAPI.Controllers
{
    public struct User
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string location { get; set; }
        public string projectName { get; set; }
        public long cardNumber { get; set; }
    }

    [ApiController]
    public class UserValuesController : ControllerBase
    {
        private IUserService user1 = new UserService();

        //POST CreateAccount
        [HttpPost("createaccount/{user}")]
        public void Post([FromBody] User user)
        {
            user1.CreateAccount(user.name, user.email, user.dateOfBirth, user.location, user.cardNumber);
        }

        // DELETE api/values/5
        //[HttpDelete("account/{id}")]                    //????????????????????????????????????????????????????
        //public void Delete(int id)
        //{
        //    user1.DeleteAccount(string name, string email);

        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


    }
    public struct Creator
    {
        public string email { get; set; }
        public ProjectProfilePage project { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string dateOfCreation { get; set; }
        public string category { get; set; }
        public string datetime { get; set; }
        public string projectName { get; set; }
        public string videoName { get; set; }
        public string photoName { get; set; }
        public decimal lowerBound { get; set; }
        public string reward { get; set; }
        public string projectTitle { get; set; }
        public Package package { get; set; }
        public string categoryKeywords { get; set; }
    }

    [ApiController]
    public class ProjectCreatorController : ControllerBase
    {
        private IProjectCreatorService projectCreator = new ProjectCreatorService();

        //POST AddProject
        [HttpPost("addproject/{project}")]
        public void Post([FromBody] Creator user)
        {
            projectCreator.AddProject(user.email, user.project);
        }

        //POST ProjectCreation
        [HttpPost("projectcreation/{project}")]
        public void Post1([FromBody] Creator user)
        {
            projectCreator.ProjectCreation(user.email, user.title, user.description, user.dateOfCreation, user.category, user.datetime);
        }

        //POST AddVideo
        [HttpPost("project/addvideo/{project}")]
        public void Post2([FromBody] Creator user)
        {
            projectCreator.AddVideo(user.projectName, user.videoName);
        }

        //POST AddPhoto
        [HttpPost("project/addphoto/{project}")]
        public void Post3([FromBody] Creator user)
        {
            projectCreator.AddPhoto(user.projectName, user.photoName);
        }

        //POST CreateFundPackages
        [HttpPost("project/create/fund/packages/{project}")]
        public void Post4([FromBody] Creator user)
        {
            projectCreator.CreateFundPackages(user.title, user.description, user.lowerBound, user.reward, user.projectTitle);
        }

        //POST AddPackage
        [HttpPost("project/add/fund/packages/{project}")]
        public void Post5([FromBody] Creator user)
        {
            projectCreator.AddPackage(user.projectTitle, user.package);
        }

        //POST CreateCategory
        [HttpPost("project/create/category/{project}")]
        public void Post6([FromBody] Creator user)
        {
            projectCreator.CreateCategory(user.categoryKeywords);
        }
    }

    public struct Backer
    {
        public string email { get; set; }
        public string projectName { get; set; }
        public decimal amount { get; set; }
        public string titleOfPackage { get; set; }
    }

    [ApiController]
    public class BackerCreatorController : ControllerBase
    {
        private IBackerService backer = new BackerService();

        //POST FundProject
        [HttpPost("fundproject/{user}")]
        public void Post([FromBody] Backer user)
        {
            backer.FundProject(user.email, user.projectName, user.amount, user.titleOfPackage);
        }

        // GET ViewPendingProjects   
        [HttpGet("projects/pendingprojects")]
        public ActionResult<List<string>> Get()
        {
            return backer.ViewPendingProjects();
        }

        // GET ViewProjects  
        [HttpGet("projects")]
        public ActionResult<List<string>> Get2()
        {
            return backer.ViewProjects();
        }

        // GET FundedProjects
        [HttpGet("projects/email/{email}")]
        public ActionResult<List<ProjectProfilePage>> Get3(string email)
        {
            return backer.FundedProjects(email);
        }

        // GET ViewByCategory
        [HttpGet("projects/category/{category}")]
        public ActionResult<List<string>> Get4(string category)
        {
            return backer.ViewByCategory(category);
        }

        // GET ViewByText
        [HttpGet("projects/search/{text}")]
        public ActionResult<List<string>> Get5(string text)
        {
            return backer.ViewByText(text);
        }

        // GET ViewByCreator
        [HttpGet("projects/name/{name}")]
        public ActionResult<List<string>> Get6(string name)
        {
            return backer.ViewByCreator(name);
        }

        // GET ViewByCreator
        [HttpGet("projects/year/{year}")]
        public ActionResult<List<string>> Get7(int year)
        {
            return backer.ViewByYear(year);
        }

        // GET ViewDetailsProject
        [HttpGet("projects/details/{title}")]
        public ActionResult<List<string>> Get8(string title)
        {
            return backer.ViewDetailsOfProject(title);
        }
    }
}

