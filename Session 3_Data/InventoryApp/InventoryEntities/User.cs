

namespace InventoryEntities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        
    }

    public class UserIsAdminResult {
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
