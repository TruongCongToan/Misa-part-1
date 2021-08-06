using Dapper;
using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
   public class CustomerBL:BaseBL<Customer>
    {

        protected string _connectionString = "" +
        "Host = 47.241.69.179;" +
        "Port = 3306;" +
        "Database= 15B_MS259_CukCuk_TCTOAN;" +
        "User Id = nvmanh;" +
        "Password= 12345678";
        protected IDbConnection _dbConnection;
        protected override void Validate(Customer entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                CustomerDL customerDL = new CustomerDL();
                // Validate dữ liệu:
                // 1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                if (string.IsNullOrEmpty(customer.CustomerCode))
                {
                    throw new GuardException<Customer>("Mã khách hàng không được phép để trống.", customer);
                }
                // 2. Check mã khách hàng đã tồn tại hay chưa?
                var isExists = customerDL.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExists == true)
                {
                    throw new GuardException<Customer>("Mã khách hàng đã tồn tạo trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(customer.Email, emailTemplate))
                {
                    throw new GuardException<Customer>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }
            }
        }
        public IEnumerable<Customer> Search<Customer>(string m_input)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(Customer).Name;
                var param = new { m_input };
                var sqlCommand = "Proc_GetCustomerByName";
                var customers = _dbConnection.Query<Customer>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

    }
}
