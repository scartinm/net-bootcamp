

namespace InventoryBC
{
    using InventoryDC;

    public class UserLogic
    {
        UserDAL dal = new UserDAL();

        public int userValidation(string userName, string password) {
            var validation = dal.userValidation(userName, password);
            return validation;
        }
        
        
    }
}
