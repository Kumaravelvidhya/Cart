using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AddProduct
    {
        public AddProduct()
        {
            Type = new List<Dropdownmodels>();
        }
        public int No { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Unitprice { get; set; }
        public int Subtotal { get; set; }

        public int Total { get; set; }
        public List<Dropdownmodels> Type { get; set; }
    }
}
