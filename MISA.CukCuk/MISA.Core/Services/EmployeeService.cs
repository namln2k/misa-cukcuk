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
        /// Validate thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần validate</param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (29/07/2021)
        protected override ServiceResult CustomValidate(Employee employee)
        {

            var res = new ServiceResult();

            // 1. Check Email có đúng định dạng không
            if (!Regex.IsMatch(employee.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_EmailInvalid;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // 2. Check PhoneNumber có đúng định dạng không
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
