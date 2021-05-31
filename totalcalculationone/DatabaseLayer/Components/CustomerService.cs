using DatabaseLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using DataObjects;
using DataObjects.AdoNet;

namespace DatabaseLayer.Components
{
    public class CustomerService : BaseDAComponent, ICustomerService
    {
        public List<Customer> GetCustomers()
        {
            string sql = GetFullName("spDMSGetcustomerlist");
            return Db.ReadList(sql, MakeCustomers, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, Customer> MakeCustomers = reader =>
         new Customer
         {
             Customer_Id = reader["Customer_Id"].AsInt(),
             intCustomerId = reader["intCustomerId"].AsInt(),
             date = reader["date"].AsDateTime(),
             caf_nominated = reader["caf_nominated"].AsString(),
             gstin = reader["gstin"].AsString(),
             credit_limit = reader["credit_limit"].AsString(),
             sales_pic = reader["sales_pic"].AsString(),
             payment_term = reader["payment_term"].AsString(),
             customer_name = reader["customer_name"].AsString(),
             industry_code = reader["industry_code"].AsString(),
             role = reader["role"].AsString(),
             port_terminal_company = reader["port_terminal_company"].AsString(),
             address_line_1 = reader["address_line_1"].AsString(),
             address_line_2 = reader["address_line_2"].AsString(),
             address_line_3 = reader["address_line_3"].AsString(),
             city = reader["city"].AsString(),
             province = reader["province"].AsString(),
             postcode = reader["postcode"].AsString(),
             country = reader["country"].AsString(),
         };
    }
}
