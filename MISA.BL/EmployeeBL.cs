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
    public class EmployeeBL : BaseBL<Employee>
    {

        protected string _connectionString = "" +
        "Host = 47.241.69.179;" +
        "Port = 3306;" +
        "Database= 15B_MS259_CukCuk_TCTOAN;" +
        "User Id = nvmanh;" +
        "Password= 12345678";
        protected IDbConnection _dbConnection;
        protected override void Validate(Employee entity)
        {
            if (entity is Employee)
            {
                var employee = entity as Employee;
                EmployeeDL employeeDL = new EmployeeDL();
                // Validate dữ liệu:
                // 1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                if (string.IsNullOrEmpty(employee.EmployeeCode))
                {
                    throw new GuardException<Employee>("Mã khách hàng không được phép để trống.", employee);
                }
                // 2. Check mã khách hàng đã tồn tại hay chưa?
                var isExists = employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                if (isExists == true)
                {
                    throw new GuardException<Employee>("Mã khách hàng đã tồn tạo trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(employee.Email, emailTemplate))
                {
                    throw new GuardException<Employee>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }
            }
        }
        public IEnumerable<Employee> Search<Employee>(string m_input)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(Employee).Name;
                var param = new { m_input };
                var sqlCommand = "Proc_GetById";
                var customers = _dbConnection.Query<Employee>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

    }
}
