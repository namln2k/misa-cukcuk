using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : DbContext<Employee>, IEmployeeContext
    {
        //public int Add(Employee employee)
        //{
        //    // Khai báo thông tin nhân viên
        //    DynamicParameters parameters = new DynamicParameters();
        //    employee.EmployeeId = Guid.NewGuid();
        //    parameters.Add("@EmployeeId", employee.EmployeeId.ToString());
        //    parameters.Add("@EmployeeCode", employee.EmployeeCode);
        //    parameters.Add("@FullName", employee.FullName);
        //    parameters.Add("@Gender", employee.Gender);
        //    parameters.Add("DateOfBirth", employee.DateOfBirth);
        //    parameters.Add("PhoneNumber", employee.PhoneNumber);
        //    parameters.Add("Email", employee.Email);
        //    parameters.Add("Address", employee.Address);
        //    parameters.Add("IdentityNumber", employee.IdentityNumber);
        //    parameters.Add("IdentityDate", employee.IdentityDate);
        //    parameters.Add("IdentityPlace", employee.IdentityPlace);
        //    parameters.Add("JoinDate", employee.JoinDate);
        //    parameters.Add("DepartmentId", employee.DepartmentId);
        //    parameters.Add("PositionId", employee.PositionId);
        //    parameters.Add("WorkStatus", employee.WorkStatus);
        //    parameters.Add("Salary", employee.Salary);

        //    // Khai báo lệnh truy vấn thêm mới thông tin một nhân viên
        //    var sqlCommand = $"" +
        //        $"INSERT INTO Employee(" +
        //        $"EmployeeId, " +
        //        $"EmployeeCode, " +
        //        $"FullName, " +
        //        $"Gender, " +
        //        $"DateOfBirth, " +
        //        $"PhoneNumber, " +
        //        $"Email, " +
        //        $"Address, " +
        //        $"IdentityNumber, " +
        //        $"IdentityDate, " +
        //        $"IdentityPlace, " +
        //        $"JoinDate, " +
        //        $"DepartmentId, " +
        //        $"PositionId, " +
        //        $"WorkStatus, " +
        //        $"Salary) " +
        //        $"VALUE(" +
        //        $"@EmployeeId, " +
        //        $"@EmployeeCode, " +
        //        $"@FullName, " +
        //        $"@Gender, " +
        //        $"@DateOfBirth, " +
        //        $"@PhoneNumber, " +
        //        $"@Email, " +
        //        $"@Address, " +
        //        $"@IdentityNumber, " +
        //        $"@IdentityDate, " +
        //        $"@IdentityPlace, " +
        //        $"@JoinDate, " +
        //        $"@DepartmentId, " +
        //        $"@PositionId, " +
        //        $"@WorkStatus, " +
        //        $"@Salary)";

        //    // Thực hiện truy vấn thêm mới thông tin một nhân viên
        //    var res = DbConnection.Execute(sql: sqlCommand, param: parameters);
        //    return res;
        //}

        /// <summary>
        /// Sửa đổi thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần sửa đổi</param>
        /// <returns>Số bản ghi được thay đổi</returns>
        /// Created By LNNam (29/07/2021)
        //public int Update(Employee employee)
        //{
        //    // Khai báo thông tin nhân viên
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@EmployeeId", employee.EmployeeId.ToString());
        //    parameters.Add("@EmployeeCode", employee.EmployeeCode);
        //    parameters.Add("@FullName", employee.FullName);
        //    parameters.Add("@Gender", employee.Gender);
        //    parameters.Add("DateOfBirth", employee.DateOfBirth);
        //    parameters.Add("PhoneNumber", employee.PhoneNumber);
        //    parameters.Add("Email", employee.Email);
        //    parameters.Add("Address", employee.Address);
        //    parameters.Add("IdentityNumber", employee.IdentityNumber);
        //    parameters.Add("IdentityDate", employee.IdentityDate);
        //    parameters.Add("IdentityPlace", employee.IdentityPlace);
        //    parameters.Add("JoinDate", employee.JoinDate);
        //    parameters.Add("DepartmentId", employee.DepartmentId);
        //    parameters.Add("PositionId", employee.PositionId);
        //    parameters.Add("WorkStatus", employee.WorkStatus);
        //    parameters.Add("Salary", employee.Salary);

        //    // Khai báo lệnh truy vấn thêm mới thông tin một nhân viên
        //    var sqlCommand = $"" +
        //        $"UPDATE Employee SET " +
        //        $"EmployeeCode=@EmployeeCode, " +
        //        $"FullName=@FullName, " +
        //        $"Gender=@Gender, " +
        //        $"DateOfBirth=@DateOfBirth, " +
        //        $"PhoneNumber=@PhoneNumber, " +
        //        $"Email=@Email, " +
        //        $"Address=@Address, " +
        //        $"IdentityNumber=@IdentityNumber, " +
        //        $"IdentityDate=@IdentityDate, " +
        //        $"IdentityPlace=@IdentityPlace, " +
        //        $"JoinDate=@JoinDate, " +
        //        $"DepartmentId=@DepartmentId, " +
        //        $"PositionId=@PositionId, " +
        //        $"WorkStatus=@WorkStatus, " +
        //        $"Salary=@Salary " +
        //        $"WHERE EmployeeId=@EmployeeId";

        //    // Thực hiện truy vấn thêm mới thông tin một nhân viên
        //    var res = DbConnection.Execute(sql: sqlCommand, param: parameters);
        //    return res;
        //}
    }
}
