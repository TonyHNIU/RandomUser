using AutoMapper;
using RandomUser.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.DataAccess.Services
{
    public class UserService : DataAccessService
    {
        public async Task<List<UserModel>> GetUsers(string firstName, string lastName, int limit = 0)
        {
            if (firstName == null)
            {
                firstName = "";
            }
            if (lastName == null)
            {
                lastName = "";
            }
            var userQuery = DbContext.Users.Where(x => x.FirstName.Contains(firstName) && x.LastName.Contains(lastName));
            if (limit > 0)
            {
                userQuery = userQuery.Take(limit);
            }
            var users = await userQuery.ToListAsync();
            return Mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var userEntity = await DbContext.Users.FirstAsync(x => x.ID == userId);
            return Mapper.Map<UserModel>(userEntity);
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            User userEntity = Mapper.Map<User>(user);
            if (userEntity.ID > 0)
            {
                DbContext.Users.Attach(userEntity);
                DbContext.Entry(userEntity).State = EntityState.Modified;
            }
            else
            {
                DbContext.Users.Add(userEntity);
            }

            if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
            {
                var createdImagePath = Path.Combine(Environment.CurrentDirectory, @"UserImages\", Path.GetRandomFileName());
                //File.WriteAllBytes(createdImagePath, user.ProfilePicture.);
                userEntity.ProfilePicturePath = createdImagePath;
            }

            await DbContext.SaveChangesAsync();
            return Mapper.Map<UserModel>(userEntity);
        }

        public async Task DeleteUser(int userId)
        {
            var userEntity = await DbContext.Users.FirstAsync(x => x.ID == userId);
            DbContext.Users.Remove(userEntity);
            await DbContext.SaveChangesAsync();
        }
    }
}
