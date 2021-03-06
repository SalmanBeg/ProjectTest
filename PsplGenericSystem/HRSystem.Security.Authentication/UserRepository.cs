﻿using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace HRSystem.Security.Authentication
{
    public class UserRepository<T> where T : PsplIdentityUser
    {
        private readonly IdentityHREntities _databaseContext;

        public UserRepository(IdentityHREntities databaseContext)
        {
            _databaseContext = databaseContext;
        }

        internal T GeTByName(string userName)
        {
            var user = _databaseContext.Users.SingleOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                T result = (T)Activator.CreateInstance(typeof(T));
                result.Id = user.Id;
                result.UserName = user.UserName;
                result.PasswordHash = user.PasswordHash;
                result.SecurityStamp = user.SecurityStamp;
                result.Email = result.Email;
                return result;
            }
            return null;
        }

        internal T GeTByEmail(string email)
        {
            //var user = _databaseContext.Users.SingleOrDefault(u => u.Email == email);
            //if (user != null)
            //{
            //    T result = (T)Activator.CreateInstance(typeof(T));

            //    result.Id = user.Id;
            //    result.UserName = user.UserName;
            //    result.PasswordHash = user.PasswordHash;
            //    result.SecurityStamp = user.SecurityStamp;
            //    result.Email = result.Email;
            //    result.EmailConfirmed = user.EmailConfirmed;
            //    result.PhoneNumber = user.PhoneNumber;
            //    result.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            //    result.LockoutEnabled = user.LockoutEnabled;
            //    result.LockoutEndDateUtc = user.LockoutEndDateUtc;
            //    result.AccessFailedCount = user.AccessFailedCount;
            //    return result;
            //}
            return null;
        }

        internal int Insert(T user)
        {

            try
            {
                _databaseContext.Users.Add(new User
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                Discriminator="1"
            });

                return _databaseContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns an T given the user's id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public T GeTById(string userId)
        {
            var user = _databaseContext.Users.Find(userId);
            if (user != null)
            {
                T result = (T)Activator.CreateInstance(typeof(T));

                result.Id = user.Id;
                result.UserName = user.UserName;
                result.PasswordHash = user.PasswordHash;
                result.SecurityStamp = user.SecurityStamp;
                result.Email = result.Email;
                return result;
            }
            return null;
        }

        /// <summary>
        /// Return the user's password hash
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public string GetPasswordHash(string userId)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Id == userId);
            var passHash = user != null ? user.PasswordHash : null;
            return passHash;
        }

        /// <summary>
        /// Updates a user in the Users table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(T user)
        {
            var result = _databaseContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (result != null)
            {
                result.UserName = user.UserName;
                result.PasswordHash = user.PasswordHash;
                result.SecurityStamp = user.SecurityStamp;
            }
            return 0;
        }

        public T CheckPasswordAsync(string userName, string Password)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.UserName == userName && u.PasswordHash == Password);
            if (user != null)
            {
                T result = (T)Activator.CreateInstance(typeof(T));

                result.Id = user.Id;
                result.UserName = user.UserName;
                result.PasswordHash = user.PasswordHash;
                result.SecurityStamp = user.SecurityStamp;
                result.Email = result.Email;
                return result;
            }
            return null;
        }
    }
}