using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IUserService
    {
        bool CreateAccount(string name, string email, DateTime dateOfBirth, string location, string cardNumber);
       // bool DeleteAccount(string name, string email);
        bool EditAccount(string name, string email, DateTime dateOfBirth, string location, string cardNumber);
       
    }
}
