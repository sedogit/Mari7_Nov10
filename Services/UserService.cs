using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mari7.Models;
using Mari7.Entities;
using Mari7.Helpers;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

namespace Mari7.Services
{
    public interface IUserService
    {
        MariUser Authenticate(string username, string password);
        IEnumerable<MariUser> GetAll();
        MariUser GetById(int id);
        MariUser Create(MariUser user, string password);
        void Update(MariUser user, string password = null);
        void Delete(int id);
        bool AddRole(long userId, int roleId);
        IEnumerable<UserRole> GetUserRoles(long userId);
        bool CheckUserStepAuth(long userId, int stepId);
}


    public class UserService : IUserService
    {
        private readonly MariContext _context;

        private readonly AppSettings _appSettings;

        private readonly ILogger<UserService> _logger;

        public UserService(IOptions<AppSettings> appSettings, MariContext context, ILogger<UserService> logger)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _logger = logger;
        }

        public MariUser Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.MariUsers.SingleOrDefault(x => x.Username == username);

            // return null if user not found
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<MariUser> GetAll()
        {
            return _context.MariUsers;
        }

        public MariUser GetById(int id)
        {
            return _context.MariUsers.FirstOrDefault(x => x.ID == id);
        }

        public MariUser Create(MariUser user, string password)
        {


            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            // .WriteTo.Console()
             //.WriteTo.Console(new RenderedCompactJsonFormatter())
             .WriteTo.File(new RenderedCompactJsonFormatter(), "../logs/log.ndjson")
            .CreateLogger();
            Log.Information("Start User Service Controller");

            //_logger.Information("Start user service Create");
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.MariUsers.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;            


            //_logger.Information("before EF savechanges in user service Create");
            _context.MariUsers.Add(user);
                  _context.SaveChanges();



            return user;
        }
        public void Update(MariUser userParam, string password = null)
        {
            var user = _context.MariUsers.Find(userParam.ID);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.MariUsers.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            
            _context.MariUsers.Update(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.MariUsers.Find(id);
            if (user != null)
            {
                _context.MariUsers.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        public bool AddRole(long userId, int roleId)
        {
            var user = _context.MariUsers.Find(userId);

            if (user == null)
                throw new AppException("User not found");

            UserRole role = new UserRole();
            role.RoleID = roleId;
            role.UserID = userId;
            
            _context.UserRoles.Add(role);
            _context.SaveChanges();


            return true;
        }
        public IEnumerable<UserRole> GetUserRoles(long userId)
        {
            var roles = _context.UserRoles.Where(x=>x.UserID==userId);
            return roles;
        }
        public bool CheckUserStepAuth(long userId, int stepId)
        {
            try{
                    /* Kullanıcının o step için yetkisi kontrol edilir. */
                    var userRoles = _context.UserRoles.Where(x=>x.UserID==userId);
                    var stepRoles = _context.StepRoles.Where(x=>x.StepID==userId);
                    if(userRoles != null && stepRoles!=null)
                    {
                                    if(userRoles.ToList().ConvertAll<int>(x=>x.RoleID).Any(stepRoles.ToList().ConvertAll<int>(x=>x.RoleID).Contains))
                                    return true;
                    }
                    return false;                    
            }
            catch(Exception e)
            {
                /* todo loglanacak!!! */
                    return false;
            }
        }
    }
}