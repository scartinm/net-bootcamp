

namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System.Collections.Generic;

    public class UserLogic
    {
        UserDAL dal = new UserDAL();

        //Valida el usuario
        public List<UserIsAdminResult> UserValidationBC(string userName, string password) {
            var UserResult = dal.UserValidationAsync(userName, password);
            return UserResult;
        }

        //Agrega un usuario
        public void UserAddBC(string userName, string password, bool isAdmin)
        {
            dal.UserInsert(userName, password, isAdmin);
        }

    }
}
