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
    /// Lớp Controller Base
    /// </summary>
    /// Created By LNNam(03/08/2021)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        public IBaseRepository<MISAEntity> _baseRepository;
        public IBaseService<MISAEntity> _baseService;
        public ServiceResult _serviceResult;

        #region Constructors
        public BaseEntityController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region
        /// <summary>
        /// Lấy thông tin tất cả bản ghi
        /// </summary>
        /// <returns>IActionResult</returns>
        /// Created By LNNam(03/08/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // Gọi hàm tương tác trực tiếp với database
                var entities = _baseRepository.GetAll();

                // Trả về kết quả
                if (entities.Count() > 0)
                {
                    // Nếu danh sách lấy về có phần tử
                    return Ok(entities);
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
        /// Lấy thông tin tất cả bản ghi
        /// </summary>
        /// <returns>IActionResult</returns>
        /// Created By LNNam(03/08/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetById(string entityId)
        {
            // Kiểm tra id có phải kiểu Guid không
            Guid entityIdGuid;
            var isGuid = Guid.TryParse(entityId, out entityIdGuid);

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
                var entity = _baseRepository.GetById(entityIdGuid);

                // Trả về kết quả
                if (entity != null)
                {
                    // Nếu danh sách lấy về có phần tử
                    return Ok(entity);
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
        /// Thêm mới bản ghi
        /// </summary>
        /// <returns>IActionResult</returns>
        /// Created By LNNam(03/08/2021)
        [HttpPost]
        public IActionResult Add([FromBody] MISAEntity entity)
        {
            try
            {
                // Gọi đến service để thực hiện các nghiệp vụ
                var res = _baseService.Add(entity);

                if (res.Success == false)
                {
                    return BadRequest(res);
                }

                // Gọi hàm tương tác trực tiếp với database
                var rowsAffected = _baseRepository.Add(entity);

                // Trả về kết quả
                if (rowsAffected > 0)
                {
                    // Nếu có bản ghi bị sửa đổi
                    return Ok(rowsAffected);
                }

                // Nếu không có bản ghi nào bị sửa đổi
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
        /// Sửa đổi bản ghi
        /// </summary>
        /// <returns>IActionResult</returns>
        /// Created By LNNam(04/08/2021)
        [HttpPut]
        public IActionResult Update([FromBody]MISAEntity entity)
        {
            try
            {
                // Gọi đến service để thực hiện các nghiệp vụ
                var res = _baseService.Update(entity);

                if (res.Success == false)
                {
                    return BadRequest(res);
                }

                // Gọi hàm tương tác trực tiếp với database
                var rowsAffected = _baseRepository.Update(entity);

                // Trả về kết quả
                if (rowsAffected > 0)
                {
                    // Nếu có bản ghi bị sửa đổi
                    return Ok(rowsAffected);
                }

                // Nếu không có bản ghi nào bị sửa đổi
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
        /// Xóa bản ghi
        /// </summary>
        /// <returns>IActionResult</returns>
        /// Created By LNNam(04/08/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(string entityId)
        {
            // Kiểm tra employeeId có phải kiểu Guid không
            Guid entityIdGuid;
            var isGuid = Guid.TryParse(entityId, out entityIdGuid);

            if (!isGuid)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Core.Properties.Resources.ValidationError_EmployeeIdInvalid;
                _serviceResult.MISACode = Core.Constants.MISAConst.MISACodeValidationError;
                return BadRequest(_serviceResult);
            }

            ServiceResult res = new ServiceResult();

            try
            {
                // Gọi hàm tương tác trực tiếp với database
                var rowsAffected = _baseRepository.Delete(entityIdGuid);

                // Trả về kết quả
                if (rowsAffected > 0)
                {
                    return Ok(rowsAffected);
                }

                // Nếu không có bản ghi nào bị xóa
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
        /// Lấy bản ghi theo trang
        /// </summary>
        /// <param name="pageNumber">Số thứ tự của trang</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <returns></returns>
        [HttpGet("paging")]
        public IActionResult GetPaging(int pageNumber, int pageSize)
        {
            return NoContent();
        }
        #endregion
    }
}
