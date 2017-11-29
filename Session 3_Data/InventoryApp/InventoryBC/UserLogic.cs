

namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogic
    {
        UserDAL dal = new UserDAL();

        //public  userValidation(string userName, string password)
        //{
        //    var validation = dal.userValidation(userName, password);
        //    return validation;
        //}
        public List<UserIsAdminResult> UserValidationBC(string userName, string password) {
            var UserResult = dal.userValidationAsync(userName, password);
            return UserResult;
        }

    }
}
