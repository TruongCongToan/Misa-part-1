using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySqlConnector;
using System.Linq;

namespace MISA.DL
{
    public class EmployeeDL:BaseDL
    { 
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckEmployeeCodeExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_EmployeeCode", employeeCode);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
