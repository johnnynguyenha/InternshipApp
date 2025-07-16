using System;
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
        public bool CreateUser(string username, string password, string role)
        {
            var newUser = new User()
            {
                UserName = username,
                Password = password,
                Role = role
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
    }
}
