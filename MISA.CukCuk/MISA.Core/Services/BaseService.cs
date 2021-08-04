using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    /// <summary>
    /// Lớp Service Base
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng cần tham chiếu</typeparam>
    /// Created By LNNam (04/08/2021)
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Các nghiệp vụ về thêm bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần thêm</param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (04/08/2021)
        public virtual ServiceResult Add(MISAEntity entity)
        {
            // Validate chung
            _serviceResult = GeneralValidate(entity);

            // Validate riêng
            if (_serviceResult.Success == true)
            {
                _serviceResult = AddValidate(entity);
            }

            // Trả về kết quả
            return _serviceResult;
        }

        /// <summary>
        /// Các nghiệp vụ về sửa đổi bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần sửa đổi</param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (04/08/2021)
        public virtual ServiceResult Update(MISAEntity entity)
        {
            // Id của đối tượng
            var entityId = Guid.Parse(entity.GetType().GetProperties()[0].ToString());

            if (_baseRepository.GetById(entityId) == null)
            {
                // Nếu id không tồn tại trong database
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_EntityIdInexistent;
                return _serviceResult;
            }

            // Validate chung
            _serviceResult = GeneralValidate(entity);

            // Validate riêng
            if (_serviceResult.Success)
            {
                _serviceResult = UpdateValidate(entity);
            }

            // Trả về kết quả
            return _serviceResult;
        }

        /// <summary>
        /// Các nghiệp vụ validate chung cho tất cả các loại đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần validate</param>
        /// <returns>true: thông tin hợp lệ; false: thông tin không hợp lệ (Mặc định trả về true)</returns>
        /// Created By LNNam (04/08/2021)
        private ServiceResult GeneralValidate(MISAEntity entity)
        {
            var res = new ServiceResult();
            return res;
        }

        /// <summary>
        /// Các nghiệp vụ validate cho việc thêm mới bản ghi (Có thể override)
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần validate</param>
        /// <returns>true: thông tin hợp lệ; false: thông tin không hợp lệ (Mặc định trả về true)</returns>
        /// Created By LNNam (04/08/2021)
        public virtual ServiceResult AddValidate(MISAEntity entity)
        {
            var res = new ServiceResult();
            return res;
        }

        /// <summary>
        /// Các nghiệp vụ validate cho việc sửa đổi bản ghi (Có thể override)
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần validate</param>
        /// <returns>true: thông tin hợp lệ; false: thông tin không hợp lệ (Mặc định trả về true)</returns>
        /// Created By LNNam (04/08/2021)
        public virtual ServiceResult UpdateValidate(MISAEntity entity)
        {
            var res = new ServiceResult();
            return res;
        }
        #endregion
    }
}
