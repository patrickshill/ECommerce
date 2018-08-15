using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models {
    public class Order {
        [Key]
        public long id {get;set;}

        public int quantity {get;set;}
        
        public Product product {get;set;}

        [ForeignKey("product")]
        public long product_id {get;set;}

        public Customer customer {get;set;}

        [ForeignKey("customer")]
        public long customer_id {get;set;}
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at {get;set;}
        
    }
}