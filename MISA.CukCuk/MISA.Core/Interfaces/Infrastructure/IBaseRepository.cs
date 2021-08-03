using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface giao tiếp với Database
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng tham chiếu đến</typeparam>
    /// Created By LNNam (31/07/2021)
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>List tất cả bản ghi</returns>
        /// Created By LNNam (31/07/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Hàm lấy theo Id
        /// </summary>
        /// <param name="EntityId">Id của đối tượng cần tìm</param>
        /// <returns>Đối tượng có Id cần tìm</returns>
        /// Created By LNNam (31/07/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Hàm lấy theo Code
        /// </summary>
        /// <param name="entityCode">Code của đối tượng cần tìm</param>
        /// <returns>Đối tượng có Code cần tìm</returns>
        /// Created By LNNam (31/07/2021)
        MISAEntity GetByCode(string entityCode);

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng bản ghi cần thêm</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// Created By LNNam (03/08/2021)
        int Add(MISAEntity entity);

        /// <summary>
        /// Sửa đổi bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng bản ghi cần sửa đổi</param>
        /// <returns>Số bản ghi bị sửa đổi</returns>
        /// Created By LNNam (03/08/2021)
        int Update(MISAEntity entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// Created By LNNam (31/07/2021)
        int Delete(Guid entityId);
    }
}
