using System.Collections.Generic;
namespace ECommerce.Models
{
    public class ModelBundle
    {
        public Customer CustomerModel { get; set; }
        public List<Product> ProductModels { get; set; }
    }
}