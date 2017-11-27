﻿

namespace InventoryEntities
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}