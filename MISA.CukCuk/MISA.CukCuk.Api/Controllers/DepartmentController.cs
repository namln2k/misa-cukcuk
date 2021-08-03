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
    /// Lớp Controller các hoạt động liên quan đến Department
    /// </summary>
    [Route("api/v1/departments")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        //IBaseRepository<Department> _baseRepository;
        //IDepartmentService _departmentService;
        //ServiceResult _serviceResult;

        #region Constructors
        public DepartmentController(IBaseRepository<Department> baseRepository, IDepartmentService departmentService) : base(baseRepository, departmentService)
        {
            //_baseRepository = baseRepository;
            //_baseService = departmentService;
            //_serviceResult = new ServiceResult();
        }
        #endregion

        //#region Methods
        ///// <summary>
        ///// Lấy thông tin tất cả phòng ban
        ///// </summary>
        ///// <returns>IActionResult</returns>
        ///// Created By LNNam (01/08/2021)
        //[HttpGet]
        //public IActionResult GetAllDepartments()
        //{
        //    try
        //    {
        //        // Gọi hàm tương tác trực tiếp với database
        //        var departments = _baseRepository.GetAll();

        //        // Trả về kết quả
        //        if (departments.Count() > 0)
        //        {
        //            // Nếu danh sách lấy về có phần tử
        //            return Ok(departments);
        //        }
        //        // Nếu danh sách lấy về rỗng
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _serviceResult.Success = false;
        //        _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
        //        _serviceResult.DevMsg = ex.Message;
        //        _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
        //        return BadRequest(_serviceResult);
        //    }
        //}

        ///// <summary>
        ///// Lấy thông tin phòng ban theo Id
        ///// </summary>
        ///// <param name="departmentId">Id phòng ban cần lấy thông tin</param>
        ///// <returns>IActionResult</returns>
        //[HttpGet("{departmentId}")]
        //public IActionResult GetDepartmentById(string departmentId)
        //{
        //    // Kiểm tra departmentId có phải kiểu Guid không
        //    Guid departmentGuid;
        //    var isGuid = Guid.TryParse(departmentId, out departmentGuid);

        //    if (!isGuid)
        //    {
        //        _serviceResult.Success = false;
        //        _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_DepartmentIdInvalid;
        //        _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
        //        return BadRequest(_serviceResult);
        //    }

        //    try
        //    {
        //        // Gọi hàm tương tác trực tiếp với database
        //        var department = _baseRepository.GetById(departmentGuid);

        //        // Trả về kết quả
        //        if (department != null)
        //        {
        //            // Nếu có phòng ban với Id cần tìm
        //            return Ok(department);
        //        }

        //        // Nếu không có phòng ban nào như vậy
        //        _serviceResult.Success = false;
        //        _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_DepartmentIdInexistent;
        //        _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
        //        return BadRequest(_serviceResult);
        //    }
        //    catch (Exception ex)
        //    {

        //        _serviceResult.Success = false;
        //        _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
        //        _serviceResult.DevMsg = ex.Message;
        //        _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
        //        return BadRequest(_serviceResult);
        //    }
        //}

        ///// <summary>
        ///// Thêm mới thông tin phòng ban
        ///// </summary>
        ///// <param name="department">Đối tượng thông tin phòng ban cần thêm</param>
        ///// <returns>IActionResult</returns>
        //[HttpPost]
        //public IActionResult AddNewDepartment([FromBody] Department department)
        //{
        //    try
        //    {
        //        // Gọi đến service thêm mới thông tin nhân viên
        //        _serviceResult = _departmentService.Add(department);

        //        // Trả về kết quả
        //        if (_serviceResult.Success == false)
        //        {
        //            return BadRequest(_serviceResult);
        //        }

        //        return StatusCode(201, _serviceResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        _serviceResult.Success = false;
        //        _serviceResult.UserMsg = Core.Properties.Resources.ExceptionError;
        //        _serviceResult.DevMsg = ex.Message;
        //        _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeExceptionError;
        //        return BadRequest(_serviceResult);
        //    }
        //}
        //#endregion
    }
}
