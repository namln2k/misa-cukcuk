using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp Controller các hoạt động liên quan đến Employee
    /// </summary>
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        IBaseRepository<Employee> _baseRepository;
        IEmployeeService _employeeService;
        ServiceResult _serviceResult;

        #region Constructors
        public EmployeeControllers(IBaseRepository<Employee> baseRepository, IEmployeeService employeeService)
        {
            _baseRepository = baseRepository;
            _employeeService = employeeService;
            _serviceResult = new ServiceResult();
        }
        #endregion

        /// <summary>
        /// Lấy thông tin tất cả nhân viên
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                // Gọi hàm tương tác trực tiếp với database
                var employees = _baseRepository.GetAll();

                // Trả về kết quả
                if (employees.Count() > 0)
                {
                    // Nếu danh sách lấy về có phần tử
                    return Ok(employees);
                }

                // Nếu danh sách lấy về trống
                return NoContent();
            }
            catch (Exception ex)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
                _serviceResult.DevMsg = ex.Message;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
                return BadRequest(_serviceResult);
            }
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Mã nhân viên cần lấy thông tin</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(string employeeId)
        {
            // Kiểm tra employeeId có phải kiểu Guid không
            Guid employeeGuid;
            var isGuid = Guid.TryParse(employeeId, out employeeGuid);

            if (!isGuid)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_EmployeeIdInvalid;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
                return BadRequest(_serviceResult);
            }

            try
            {
                // Gọi hàm tương tác trực tiếp với database
                var employee = _baseRepository.GetById(employeeGuid);

                // Trả về kết quả
                if (employee != null)
                {
                    // Nếu có nhân viên với mã cần tìm
                    return Ok(employee);
                }
                // Nếu không có nhân viên như vậy
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_EmployeeIdInexistent;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
                return BadRequest(_serviceResult);
            }
            catch (Exception ex)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
                _serviceResult.DevMsg = ex.Message;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
                return BadRequest(_serviceResult);
            }
        }

        /// <summary>
        /// Thêm mới thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần thêm</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult AddNewEmployee([FromBody] Employee employee)
        {
            try
            {
                // Gọi đến service thêm mới thông tin nhân viên
                _serviceResult = _employeeService.Add(employee);

                // Trả về kết quả
                if (_serviceResult.Success == false)
                {
                    return BadRequest(_serviceResult);
                }

                return StatusCode(201, _serviceResult);
            }
            catch (Exception ex)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
                _serviceResult.DevMsg = ex.Message;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
                return BadRequest(_serviceResult);
            }
        }

        /// <summary>
        /// Sửa đổi thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng thông tin nhân viên cần sửa đổi</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                // Gọi đến service sửa đổi thông tin nhân viên
                _serviceResult = _employeeService.Update(employee);
                if (_serviceResult.Success == false)
                {
                    return BadRequest(_serviceResult);
                }
                else
                {
                    return StatusCode(200, _serviceResult);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
                _serviceResult.DevMsg = ex.Message;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
                return BadRequest(_serviceResult);
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Mã nhân viên cần xóa</param>
        /// <returns></returns>
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(string employeeId)
        {
            // Kiểm tra employeeId có phải kiểu Guid không
            Guid employeeGuid;
            var isGuid = Guid.TryParse(employeeId, out employeeGuid);

            if (!isGuid)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_EmployeeIdInvalid;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
                return BadRequest(_serviceResult);
            }
            try
            {
                var res = _baseRepository.Delete(employeeGuid);

                // Trả về kết quả
                if (res > 0)
                {
                    _serviceResult.Success = true;
                    _serviceResult.UserMsg = Core.Properties.Resources.DeleteEmployeeSuccess;
                    return Ok(_serviceResult);
                }
                else
                {
                    _serviceResult.Success = false;
                    _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_EmployeeIdInexistent;
                    return BadRequest(_serviceResult);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
                _serviceResult.DevMsg = ex.Message;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
                return BadRequest(_serviceResult);
            }
        }
    }
}
