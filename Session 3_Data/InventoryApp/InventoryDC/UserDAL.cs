

namespace InventoryDC
{

    using InventoryEntities;
    using System.Collections.Generic;
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

        public int userValidation( string userName, string password) {
            SqlParameter param1 = new SqlParameter("@UserName", userName);
            SqlParameter param2 = new SqlParameter("@Password", password);
            
           
            var sqlResult= db.Database.ExecuteSqlCommand("SPUserValidation @UserName, @Password", param1,param2);
            return sqlResult;
        }
    } 
}
