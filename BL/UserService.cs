using DAL;
using DevOne.Security.Cryptography.BCrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BCrypt.Net;
using Utilities;

namespace BL
{
    // class that handles the business logic and talks to the data access layer (DAL) for user management.
    public class UserService
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // FUNCTIONS //

        // function that resets password for user. return true if successful, false otherwise.
        public bool ResetPassword(string username, string newpassword, string confirmpassword, out string message)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(confirmpassword))
            {
                message = "Empty Field";
                return false;
            }
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} in ResetPassword", ex);
                message = "An error occurred when trying to retrieve the user";
                return false;
            }
            if (user == null)
                {
                    message = "Username does not exist";
                    return false;
                }
            if (newpassword != confirmpassword)
            {
                message = "Passwords do not match";
                return false;
            }
            if (PasswordHelper.VerifyPassword(newpassword, user.Password))
            {
                message = "New password is the same as the old password";
                return false;
            }
            string hashedPassword = PasswordHelper.HashPassword(newpassword);
            try
            {
                _unitOfWork.Users.UpdatePassword(user, hashedPassword);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                log.Error($"Exception in ResetPassword for user {username} in ResetPassword", ex);
                message = "An error occurred while resetting the password";
                return false;
            }
            message = "Password Changed Succesfully";
            return true;
        }

        // function that logs in user. return true if successful, false otherwise.
        public User Login(string username, string password, out string message)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    message = "Empty Field";
                    return null;
                }
                User user;
                try
                {
                    user = _unitOfWork.Users.GetUserByUsername(username);
                }
                catch (Exception ex)
                {
                    log.Error($"Exception in retrieving User {username} in Login", ex);
                    message = "An error occurred when trying to retrieve the user";
                    return null;
                }
                if (user == null)
                {
                    message = "Username does not exist";
                    return null;
                }
                if (!PasswordHelper.VerifyPassword(password, user.Password))
                {
                    message = "Username and Password do not match";
                    return null;
                }
                message = "Login Success";
                return user;
            }
            catch (Exception ex)
            {
                log.Error($"Exception in Login for user {username} in Login", ex);
                message = "An error occurred while logging in";
                return null;
            }
        }

        // function that registers a new user. return true if successful, false otherwise.
        public bool Register(string username, string password, string confirmPassword, out string message)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                message = "Field Empty";
                return false;
            }
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} in Register", ex);
                message = "An error occurred when trying to retrieve the user";
                return false;
            }
            if (user != null)
            {
                message = "Username Already Exists";
                return false;
            }
            if (password != confirmPassword)
            {
                message = "Could not Register. Passwords do not match";
                return false;
            }
            string hashedPassword = PasswordHelper.HashPassword(password);
            try
            {
                _unitOfWork.Users.CreateUser(username, hashedPassword, "User");
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                log.Error($"Exception in Registering for user {username} in Register", ex);
                message = "Error occurred when trying to register.";
                return false;
            }
            message = "Register was Successful";
            return true;
        }

        // function that deletes a user account. return true if successful, false otherwise.
        public bool DeleteAccount(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} in DelteAccount", ex);
                return false;
            }
            if (user == null)
            {
                throw new ArgumentException("Cannot Delete Account. User not found");
            }
            try
            {
                if (_unitOfWork.Users.DeleteUser(user))
                {
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Exception in deleting User {username} in DeleteAccount", ex);
                return false;
            }
        }

        // function that gets the username of a user. return the username as a string.
        public string GetUserName(User user)
        {
            try
            {
                if (user == null)
                {
                    return null;
                }
                return _unitOfWork.Users.GetUsername(user);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving the username in GetUserName", ex);
                return null;
            }
        }

        // function that gets a userlist. returns a list of users.
        public List<User> GetUserList()
        {
            try
            {
                return _unitOfWork.Users.GetUsers();
            }
            catch (Exception ex)
            {
                log.Error("Exception in retrieving user list in GetUserList", ex);
                return null;
            }
        }

        // function that gets the userlist asynchronously. returns a list of users.
        public async Task<List<User>> GetUserListAsync()
        {
            try
            {
                return await _unitOfWork.Users.GetUsersAsync();
            }
            catch (Exception ex)
            {
                log.Error("Exception in retrieving user list in GetUserListAsync", ex);
                return null;
            }
        }

        // function that gets the role of a user. returns the role as a string.
        public string GetRole(User user)
        {
            try
            {
                return _unitOfWork.Users.GetRole(user);
            }
            catch (Exception ex)
            {
                log.Error("Exception in retrieving User's role in GetRole", ex);
                return null;
            }
        }

        // function that changes user details. returns true if successful, false otherwise.
        public bool ChangeDetails(User user, string username, string newusername, string password, string firstName, string lastName, string phoneNumber, string address, string role)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);
            if (user == null)
            {
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdateUserName(user, newusername);
                _unitOfWork.Users.UpdatePassword(user, hashedPassword);
                _unitOfWork.Users.UpdateFirstName(user, firstName);
                _unitOfWork.Users.UpdateLastName(user, lastName);
                _unitOfWork.Users.UpdatePhoneNumber(user, phoneNumber);
                _unitOfWork.Users.UpdateAddress(user, address);
                _unitOfWork.Users.UpdateRole(user, role);
                _unitOfWork.Save();
                return true;
            } catch (Exception ex)
            {
                log.Error($"Exception in updating the details of user {username} in ChangeDetails.", ex);
;               return false;
            }
        }

        // function that changes user details without changing password. returns true if successful, false otherwise.
        public bool ChangeDetailsNoPassword(User user, string username, string newusername, string firstName, string lastName, string phoneNumber, string address)
        {
            if (user == null)
            {
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdateUserName(user, newusername);
                _unitOfWork.Users.UpdateFirstName(user, firstName);
                _unitOfWork.Users.UpdateLastName(user, lastName);
                _unitOfWork.Users.UpdatePhoneNumber(user, phoneNumber);
                _unitOfWork.Users.UpdateAddress(user, address);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception in updating the User's details in ChangeDetailsNoPassword", ex);
                return false;
            }
        }

        // function that gets a user by username. returns the user object.
        public User GetUserByUsername(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} in GetUserByUsername", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
            }
            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            User user;
            try
            {
                user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} in GetUserByUsernameAsync", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
            }
            return user;
        }

        // function that sets password of user by username. 

        public void SetPassword(string username, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when Setting Password.", ex);
                return;
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                log.Error("Username and password cannot be empty");
            }
            if (user == null)
            {
                log.Error("Cannot Set Password. User not found");
            }
            try
            {
                _unitOfWork.Users.UpdatePassword(user, hashedPassword);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                log.Error($"Exception in updating User {username} password when in SetPassword", ex);
                return;
            }
        }

        // function that gets password of user by username. returns the password as a string.
        public string GetPassword(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetPassword.", ex);
                return null;
            }
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user.Password;
        }

        // function that changes password of user. returns true if successful, false otherwise.
        public bool ChangePassword(string username, string oldpassword, string newpassword, string confirmpassword, out string message)
        {
            string hashedPassword = PasswordHelper.HashPassword(newpassword);
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when ChangePassword.", ex);
                message = "An error occurred when trying to change the password";
                return false;
            }
            if (user == null)
            {
                message = "User not found";
                return false;
            }
            if (!PasswordHelper.VerifyPassword(oldpassword, user.Password))
            {
                message = "Old password is incorrect";
                return false;
            }
            if  (newpassword != confirmpassword)
            {
                message = "New passwords do not match";
                return  false;
            }
            if (PasswordHelper.VerifyPassword(newpassword, user.Password))
            {
                message = "New password cannot be the same as the old password";
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdatePassword(user, hashedPassword);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                log.Error($"Exception in changing the User {username} password in ChangePassword", ex);
                message = "An error occurred when trying to change the password";
            }
            message = "Password changed successfully";
            return true;
        }

        // function to change password without requiring old password (admin)
        public bool ChangePasswordNoOld(string username, string newpassword, string confirmpassword, out string message)
        {
            string hashedPassword = PasswordHelper.HashPassword(newpassword);
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when ChangePassword.", ex);
                message = "An error occurred when trying to change the password";
                return false;
            }
            if (user == null)
            {
                message = "User not found";
                return false;
            }
            if (newpassword != confirmpassword)
            {
                message = "New passwords do not match";
                return false;
            }
            if (PasswordHelper.VerifyPassword(newpassword, user.Password))
            {
                message = "New password cannot be the same as the old password";
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdatePassword(user, hashedPassword);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                log.Error($"Exception in changing the User {username} password in ChangePassword", ex);
                message = "An error occurred when trying to change the password";
            }
            message = "Password changed successfully";
            return true;
        }
    }
}
