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
    /// <summary>
    /// Class that handles user management operations such as login, registration, password reset, and user details management. Uses the UserRepository for database operations.
    /// </summary>
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
        /// <summary>
        /// Function that resets the password for a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newpassword"></param>
        /// <param name="confirmpassword"></param>
        /// <param name="message"> returns message if register is successful or not </param>
        /// <returns></returns>
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
            message = "Password Changed Successfully";
            return true;
        }

        // function that logs in user. return true if successful, false otherwise.
        /// <summary>
        /// Function that logins user by verifying username and password. Returns the user object if successful, otherwise returns null and sets the message accordingly.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="message"> "Login Success" if successful.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Function that registers a new user. It checks if the username already exists, if the passwords match, and then creates the user with a hashed password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Function that deletes account by username. It retrieves the user by username, checks if the user exists, and then deletes the user account.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Helper function to retrieve username of a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Function that retrieves the list of users.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Function that retrieves the list of users asynchronously.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Function that retrieves the role of a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Function that changes the details of a user, including username, password, first name, last name, phone number, address, and role. Returns true if successful, false otherwise.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="username"> Old Username</param>
        /// <param name="newusername"> New Username</param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="role"> "Admin" or "User" </param>
        /// <returns></returns>
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

        /// <summary>
        /// Function that changes user details without needing a password. including username, first name, last name, phone number, address, and role. Returns true if successful, false otherwise.
        /// <param name="user"></param>
        /// <param name="username"> Old Username</param>
        /// <param name="newusername"> New Username</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="role"> "Admin" or "User" </param>
        /// <returns></returns>
        public bool ChangeDetailsNoPassword(User user, string username, string newusername, string firstName, string lastName, string phoneNumber, string address, string role)
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
                _unitOfWork.Users.UpdateRole(user, role);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception in updating the User's details in ChangeDetailsNoPassword", ex);
                return false;
            }
        }

        /// <summary>
        /// Function that retrieves user by the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves user by username asynchronously.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets password of user by username. It hashes the password and updates the user's password in the database. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>

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

        /// <summary>
        /// Retrieves password of user by username, returns string password.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Changes the password of a user by verifying the old password, checking if the new password matches the confirmation, and updating the user's password in the database. Returns true if successful, false otherwise.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newpassword"></param>
        /// <param name="confirmpassword"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Changes password of user without needing old password. Returns true if successful, false otherwise. Outputs string message.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newpassword"></param>
        /// <param name="confirmpassword"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets Permission of User by username. Returns true is successful, false otherwise. Outputs string message.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="perm"> String name of the permission to be changed. "Communications", "Network", "Manage", "MagnaTran" ,"Details" </param>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool setPerm(string username, string perm, bool value, out string message)
        {
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
            _unitOfWork.Users.UpdatePerm(user, perm, value);
            _unitOfWork.Save();
            message = "Permission changed successfully.";
            return true;
        }

        /// <summary>
        /// Retrieves permissions of a user by username. Returns a dictionary of permissions with their boolean values and outputs a message.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Dictionary<string, bool> getPerms(string username, out string message)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetPerm.", ex);
                message = "An error occurred when trying to get the user's permissions";
                return null;
            }
            if (user == null)
            {
                message = "User not found";
                return null;
            }
            message = "Permissions Retrieved";
            return _unitOfWork.Users.GetPerms(user);
        }
        /// <summary>
        /// Retrieves the first name of a user by username. Returns the first name as a string or null if the user is not found or an error occurs.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetFirstName(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetFirstName.", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
                return null;
            }
            return _unitOfWork.Users.GetFirstName(user);
        }
        /// <summary>
        /// Retrieves the last name of a user by username. Returns the last name as a string or null if the user is not found or an error occurs.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetLastName(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetLastName.", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
                return null;
            }
            return _unitOfWork.Users.GetLastName(user);
        }

        /// <summary>
        /// Retrieves the address of a user by username. Returns the address as a string or null if the user is not found or an error occurs.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetAddress(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetAddress.", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
                return null;
            }
            return _unitOfWork.Users.GetAddress(user);
        }
        /// <summary>
        /// Retrieves the phone number of a user by username. Returns the phone number as a string or null if the user is not found or an error occurs.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetPhoneNumber(string username)
        {
            User user;
            try
            {
                user = _unitOfWork.Users.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in retrieving User {username} when GetPhoneNumber.", ex);
                return null;
            }
            if (user == null)
            {
                log.Error("Cannot find User. User not found");
                return null;
            }
            return _unitOfWork.Users.GetPhoneNumber(user);
        }
    }
}
