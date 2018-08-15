using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models {
    public class Customer {
        [Key]
        public long id {get;set;}

        [Required]
        [MinLength(3,ErrorMessage="Name must contain at least 3 characters")]
        public string name {get;set;}
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at {get;set;}
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at {get;set;}

        public List<Order> orders {get;set;}
        public Customer() {
            orders = new List<Order>();
        }
    }
}