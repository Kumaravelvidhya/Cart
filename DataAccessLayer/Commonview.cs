using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Commonview
    {
        [Required]
        public BillingAddressess BillingCreate { get; set; }
        [Required]

        public ShippingAddress ShippingCreate { get; set; }
        [Required]

        public AddProduct AddProduct { get; set; }
        public List<AddProduct> Cart { get; set; }

        public List<Total> Total { get; set; }
        public List<Dropdownmodels> Type { get; set; }
    }
}
