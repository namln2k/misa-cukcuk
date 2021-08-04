using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    /// <summary>
    /// Lớp service thực thi Interface Employee
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IBaseRepository<Employee> _employeeRepository;

        #region Constructors
        public EmployeeService(IBaseRepository<Employee> employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Nghiệp vụ về thêm nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (04/08/2021)
        public override ServiceResult AddValidate(Employee employee)
        {
            var res = new ServiceResult();

            // Check EmployeeCode có trùng lặp không
            if (_employeeRepository.GetByCode(employee.EmployeeCode) != null)
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_EmployeeCodeDuplicated;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // Validate thông tin nhân viên
            res = validateEmployee(employee);

            // Trả về kết quả
            return res;
        }

        /// <summary>
        /// Sửa đổi thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần sửa đổi</param>
        /// <returns>ServiceResult.Data: Số bản ghi được sửa đổi</returns>
        /// Created By LNNam (29/07/2021)
        public override ServiceResult Update(Employee employee)
        {
            var employeeById = _employeeRepository.GetById(employee.EmployeeId);
            var res = new ServiceResult();

            // Check xem khách hàng có yêu cầu thay đổi EmployeeCode không
            if (!String.Equals(employee.EmployeeCode, employeeById.EmployeeCode))
            {
                // Nếu có yêu cầu thay đổi EmployeeCode thì check xem EmployeeCode có bị trùng lặp không
                var employeeByCode = _employeeRepository.GetByCode(employee.EmployeeCode);

                if (employeeByCode != null)
                {
                    res.Success = false;
                    res.UserMsg = Properties.Resources.ValidationError_EmployeeCodeDuplicated;
                    res.MISACode = Constants.MISAConst.MISACodeValidationError;
                    return res;
                }
            }

            // Validate thông tin nhân viên
            res = validateEmployee(employee);

            // Trả về kết quả
            return res;
        }

        /// <summary>
        /// Validate thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên</param>
        /// <returns></returns>
        /// Created By LNNam (29/07/2021)
        private ServiceResult validateEmployee(Employee employee)
        {
            var res = new ServiceResult();

            // 1. Check EmployeeCode có trống không
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_EmployeeCodeEmpty;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // 2. Check Email có đúng định dạng không
            if (!Regex.IsMatch(employee.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_EmailInvalid;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // 3. Check IdentityNumber có trống hay không
            if (string.IsNullOrEmpty(employee.IdentityNumber))
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_IdentityNumberEmpty;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // 4. Check PhoneNumber có đúng định dạng không
            if (!Regex.IsMatch(employee.PhoneNumber, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase))
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_PhoneNumberInvalid;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // Nếu thông tin nhân viên đúng định dạng
            return res;
        }
        #endregion
    }
}
