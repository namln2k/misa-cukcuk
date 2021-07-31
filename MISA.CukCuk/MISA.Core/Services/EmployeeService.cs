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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeContext _employeeContext;
        IBaseRepository<Employee> _baseRepository;
        ServiceResult _serviceResult = new ServiceResult();

        #region Constructors
        public EmployeeService(IEmployeeContext employeeContext, IBaseRepository<Employee> baseRepository)
        {
            _employeeContext = employeeContext;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        public ServiceResult Add(Employee employee)
        {
            // Check EmployeeCode có trùng lặp không
            if (_baseRepository.GetByCode(employee.EmployeeCode) != null)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_EmployeeCodeDuplicated;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // Validate thông tin nhân viên
            _serviceResult = validateEmployee(employee);
            if (_serviceResult.Success == false)
            {
                return _serviceResult;
            }

            // Số bản ghi được thêm
            var res = _employeeContext.Add(employee);

            if (res > 0)
            {
                // Nếu thêm thành công
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                return _serviceResult;
            }

            // Nếu thêm thất bại
            _serviceResult.Success = false;
            _serviceResult.UserMsg = Properties.Resources.ExceptionError;
            _serviceResult.MISACode = Constants.MISAConst.MISACodeExceptionError;
            return _serviceResult;
        }

        /// <summary>
        /// Sửa đổi thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần sửa đổi</param>
        /// <returns>ServiceResult.Data: Số bản ghi được sửa đổi</returns>
        /// Created By LNNam (29/07/2021)
        public ServiceResult Update(Employee employee)
        {
            var employeeById = _baseRepository.GetById(employee.EmployeeId);

            // Check EmployeeId có tồn tại trong database không
            if (employeeById == null)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_EmployeeIdInexistent;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // Check khách hàng có yêu cầu thay đổi EmployeeCode không
            if (!String.Equals(employee.EmployeeCode, employeeById.EmployeeCode))
            {
                // Nếu có yêu cầu thay đổi EmployeeCode thì check xem EmployeeCode có bị trùng lặp không
                var employeeByCode = _baseRepository.GetByCode(employee.EmployeeCode);

                if (employeeByCode != null)
                {
                    _serviceResult.Success = false;
                    _serviceResult.UserMsg = Properties.Resources.ValidationError_EmployeeCodeDuplicated;
                    _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                    return _serviceResult;
                }
            }

            // Validate thông tin nhân viên
            _serviceResult = validateEmployee(employee);
            if (_serviceResult.Success == false)
            {
                return _serviceResult;
            }

            // Số bản ghi được sửa đổi
            var res = _employeeContext.Update(employee);

            if (res > 0)
            {
                // Nếu sửa đổi thành công
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                _serviceResult.UserMsg = Properties.Resources.UpdateEmployeeSuccess;
                return _serviceResult;
            }

            // Nếu sửa đổi thất bại
            _serviceResult.Success = false;
            _serviceResult.UserMsg = Properties.Resources.ExceptionError;
            _serviceResult.MISACode = Constants.MISAConst.MISACodeExceptionError;
            return _serviceResult;
        }

        /// <summary>
        /// Validate thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên</param>
        /// <returns></returns>
        /// Created By LNNam (29/07/2021)
        ServiceResult validateEmployee(Employee employee)
        {
            // 1. Check EmployeeCode có trống không
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_EmployeeCodeEmpty;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // 2. Check Email có đúng định dạng không
            if (!Regex.IsMatch(employee.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_EmailInvalid;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // 3. Check IdentityNumber có trống hay không
            if (string.IsNullOrEmpty(employee.IdentityNumber))
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_IdentityNumberEmpty;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // 4. Check PhoneNumber có đúng định dạng không
            if (!Regex.IsMatch(employee.PhoneNumber, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase))
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_PhoneNumberInvalid;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // Nếu thông tin nhân viên đúng định dạng
            _serviceResult.Success = true;
            return _serviceResult;
        }

        #endregion
    }
}
