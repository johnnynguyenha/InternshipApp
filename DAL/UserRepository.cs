﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "DataContext cannot be null");
            }
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username), "Username cannot be null");
            }
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username), "Username cannot be null");
            }
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public void UpdatePassword(User _user, string password)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.Password = password;
        }
        public void UpdateUserName(User _user, string username)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.UserName = username;
        }
        public void UpdateFirstName(User _user, string firstName)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.FirstName = firstName;
        }
        public void UpdateLastName(User _user, string lastName)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.LastName = lastName;
        }
        public void UpdatePhoneNumber(User _user, string phoneNumber)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.PhoneNumber = phoneNumber;
        }
        public void UpdateAddress(User _user, string address)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.Address = address;
        }
        public void UpdateRole (User _user, string role)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null");
            }
            _user.Role = role;
        }
        /// <summary>
        /// Updates a specific permission for a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="perm"> permission to be updated. "Communications", "Network, "MagnaTran", "Manage", "Details"</param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void UpdatePerm(User user, string perm, bool value)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if (string.IsNullOrWhiteSpace(perm))
            {
                throw new ArgumentNullException(nameof(perm), "Permission cannot be null or empty");
            }
            switch (perm.ToLower())
            {
                case "communications":
                    user.commPerm = value;
                    break;
                case "network":
                    user.networkPerm = value;
                    break;
                case "magnatran":
                    user.magnaPerm = value;
                    break;
                case "manage":
                    user.managePerm = value;
                    break;
                case "details":
                    user.detailsPerm = value;
                    break;
                default:
                    throw new ArgumentException("Invalid permission type", nameof(perm));
            }
        }
        /// <summary>
        /// Creates user with default full permissions. Mainly used to create admin user, then set perms afterwards.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"> "Admin" or "User"</param>
        /// <returns></returns>
        public bool CreateUser(string username, string password, string role)
        {
            var newUser = new User()
            {
                UserName = username,
                Password = password,
                Role = role,
                commPerm = true,
                networkPerm = true,
                magnaPerm = true,
                managePerm = true,
                detailsPerm = true
            };
            _context.Users.Add(newUser);
            return true;
        }
        public bool DeleteUser(User user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }
        public string GetUsername(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
                return user.UserName;
        }
        public string GetRole(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            return user.Role;
        }
        /// <summary>
        /// Returns dictionary of User perms.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Dictionary<string, bool> GetPerms(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            Dictionary<string, bool> perms = new Dictionary<string, bool>
            {
                { "Communications", user.commPerm },
                { "Network", user.networkPerm },
                { "MagnaTran", user.magnaPerm },
                { "Manage", user.managePerm },
                { "Details", user.detailsPerm }
            };
            return perms;
        }
        public string GetFirstName(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            return user.FirstName;
        }
        public string GetLastName(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            return user.LastName;
        }
        public string GetAddress(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            return user.Address;
        }
        public string GetPhoneNumber(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User canno tbe null");
            }
            return user.PhoneNumber;
        }
    }
}
