using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        Task<List<User>> GetUsersAsync();
        User GetUserByUsername(string username);
        Task<User> GetUserByUsernameAsync(string username);
        void UpdatePassword(User _user, string password);
        void UpdateUserName(User _user, string username);
        void UpdateFirstName(User _user, string firstName);
        void UpdateLastName(User user, string lastName);
        void UpdatePhoneNumber(User user, string phoneNumber);
        void UpdateAddress(User user, string address);
        void UpdateRole(User user, string role);
        bool CreateUser(string username, string password, string role);
        bool DeleteUser(User user);
        string GetUsername(User user);
        string GetRole(User user);
    }
}
