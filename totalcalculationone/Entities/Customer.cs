using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public int intCustomerId { get; set; }
        public int Customer_Id { get; set; }
        public DateTime date { get; set; }
        public string caf_nominated { get; set; }
        public string gstin { get; set; }
        public string credit_limit { get; set; }
        public string sales_pic { get; set; }
        public string payment_term { get; set; }
        public string customer_name { get; set; }
        public string industry_code { get; set; }
        public string role { get; set; }
        public string port_terminal_company { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string address_line_3 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }
}
