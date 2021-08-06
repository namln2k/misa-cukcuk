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

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Các nghiệp vụ về thêm bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần thêm</param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (04/08/2021)
        public ServiceResult Add(MISAEntity entity)
        {
            // Validate chung
            var res = GeneralValidate(entity, false);

            // Validate riêng
            if (res.Success == true)
            {
                res = AddValidate(entity);
            }

            // Trả về kết quả
            return res;
        }

        /// <summary>
        /// Các nghiệp vụ về sửa đổi bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần sửa đổi</param>
        /// <returns>ServiceResult</returns>
        /// Created By LNNam (04/08/2021)
        public ServiceResult Update(MISAEntity entity)
        {
            var res = new ServiceResult();

            // Validate chung
            res = GeneralValidate(entity, true);

            // Validate riêng
            if (res.Success)
            {
                res = CustomValidate(entity);
            }

            // Trả về kết quả
            return res;
        }

        /// <summary>
        /// Các nghiệp vụ validate chung cho tất cả các loại đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần validate</param>
        /// <returns>true: thông tin hợp lệ; false: thông tin không hợp lệ (Mặc định trả về true)</returns>
        /// Created By LNNam (04/08/2021)
        private ServiceResult GeneralValidate(MISAEntity entity, bool isUpdate)
        {
            var res = new ServiceResult();

            // Các properties của đối tượng
            var properties = entity.GetType().GetProperties();

            // Id của đối tượng
            var entityId = Guid.Parse(properties[0].GetValue(entity).ToString());

            // Lấy tên class của đối tượng
            var className = entity.GetType().Name;


            if (isUpdate)
            {
                if (_baseRepository.GetById(entityId) == null)
                {
                    // Nếu id không tồn tại trong database
                    var propsDisplayName = properties[0].GetCustomAttributes(typeof(MISADisplayName), true);

                    var displayName = string.Empty;

                    if (propsDisplayName.Length > 0)
                    {
                        displayName = (propsDisplayName[0] as MISADisplayName).PropertyName;
                    }

                    res.Success = false;
                    res.UserMsg = displayName + Properties.Resources.ValidationError_EntityIdInexistent;
                    return res;
                }
            }

            // Duyệt qua tất cả các trường thuộc tình của đối tượng
            foreach (var prop in properties)
            {
                // Nếu là trường bắt buộc nhập
                var propsRequired = prop.GetCustomAttributes(typeof(MISARequired), true);

                // Nếu là trường khóa chính
                var propsPrimaryKey = prop.GetCustomAttributes(typeof(MISAPrimaryKey), true);

                // Lấy displayName của trường
                var propsDisplayName = prop.GetCustomAttributes(typeof(MISADisplayName), true);
                var displayName = string.Empty;

                // Check trường bắt buộc nhập
                if (propsRequired.Length > 0)
                {
                    var propValue = prop.GetValue(entity);

                    if (propsDisplayName.Length > 0)
                    {
                        displayName = (propsDisplayName[0] as MISADisplayName).PropertyName;
                    }

                    if (string.IsNullOrEmpty(propValue.ToString()))
                    {
                        res.Success = false;
                        res.UserMsg = displayName + Properties.Resources.ValidationError_EntityFieldEmpty;
                        return res;
                    }
                }

                // Check trường khóa chính (Chỉ trường Code)
                if (propsPrimaryKey.Length > 0)
                {
                    // Lấy Code mà người dùng cung cấp
                    var newCode = prop.GetValue(entity).ToString();

                    // Lấy đối tượng trên database hiện đang có Code như vậy (Nếu không có thì trả về null)
                    var entityByCode = _baseRepository.GetByCode(newCode);

                    // Nếu yêu cầu là sửa đổi bản ghi
                    if (isUpdate)
                    {
                        // Lấy đối tượng có Id tương ứng cần sửa thông tin
                        var entityById = _baseRepository.GetById(entityId);

                        // Lấy tất cả các trường của đối tượng hiện đang lưu trên database
                        var updateProperties = entityById.GetType().GetProperties();

                        // Duyệt qua các prop để tìm trường Code (Code hiện tại trong database)
                        foreach (var p in updateProperties)
                        {
                            if (p.Name.ToLower() == $"{className}Code".ToLower())
                            {
                                // Lấy giá trị của trường Code
                                var currentCode = p.GetValue(entityById).ToString();

                                // Nếu code hiện tại khác Code mà người dùng cung cấp
                                // Nghĩa là người dùng có nhu cầu thay đổi Code
                                // Thì kiểm tra xem Code mới đã tồn tại trong database chưa
                                if ((!string.Equals(currentCode, newCode)) && (entityByCode != null))
                                {
                                    res.Success = false;
                                    res.UserMsg = displayName + Properties.Resources.ValidationError_EntityCodeDuplicated;
                                }

                                return res;
                            }
                        }
                    }

                    // Nếu yêu cầu là thêm mới bản ghi
                    if (entityByCode != null)
                    {
                        res.Success = false;
                        res.UserMsg = displayName + Properties.Resources.ValidationError_EntityCodeDuplicated;
                        return res;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Các nghiệp vụ validate riêng (Có thể override)
        /// </summary>
        /// <param name="entity">Đối tượng thông tin cần validate</param>
        /// <returns>true: thông tin hợp lệ; false: thông tin không hợp lệ (Mặc định trả về true)</returns>
        /// Created By LNNam (04/08/2021)
        protected virtual ServiceResult CustomValidate(MISAEntity entity)
        {
            var res = new ServiceResult();
            return res;
        }
        #endregion
    }
}
