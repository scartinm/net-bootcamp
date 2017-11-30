

namespace InventoryDC
{

    using InventoryEntities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class UserDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();
      
        //selecciona los usuarios existentes
        public IEnumerable<User> SelectUser() {
            //InvetoryAppDBContext db = new InvetoryAppDBContext();
            return db.Users.ToList();
        }

        public List<UserIsAdminResult> UserValidationAsync(string userName, string password)
        {
            SqlParameter param1 = new SqlParameter("@UserName", userName);
            SqlParameter param2 = new SqlParameter("@Password", password);
           
            var sqlResult = db.Database.SqlQuery<UserIsAdminResult>("SP_UserValidation_Select @UserName, @Password", param1, param2).ToList();
            
            
            return sqlResult.ToList();
        }

        public void UserInsert(string username, string password, bool isadmin)
        {

            SqlParameter paramusername = new SqlParameter("@username", username);
            SqlParameter parampassword = new SqlParameter("@password", password);
            SqlParameter paramisadmin = new SqlParameter("@isadmin", isadmin);
            db.Database.ExecuteSqlCommand("sp_user_add @username, @password, @isadmin", paramusername, parampassword, paramisadmin);
            Console.WriteLine("Usuario agregado exitosamente.");
        }

        public void UserUpdate(int userId, string userName, string password, bool isAdmin) {
            SqlParameter paramUserId = new SqlParameter("@userId", userId);
            SqlParameter paramUserName = new SqlParameter("@userName", userName);
            SqlParameter paramPassword = new SqlParameter("@password", password);
            SqlParameter paramIsAdmin = new SqlParameter("@isAdmin", isAdmin);


        }
    }
}
