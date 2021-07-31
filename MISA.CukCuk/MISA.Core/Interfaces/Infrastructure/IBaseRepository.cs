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
        List<MISAEntity> GetAll();

        /// <summary>
        /// Hàm lấy theo Id
        /// </summary>
        /// <param name="EntityId">Id của đối tượng cần tìm</param>
        /// <returns>Đối tượng có Id cần tìm</returns>
        MISAEntity GetById(Guid EntityId);

        /// <summary>
        /// Hàm lấy theo Code
        /// </summary>
        /// <param name="EntityCode">Code của đối tượng cần tìm</param>
        /// <returns>Đối tượng có Code cần tìm</returns>
        MISAEntity GetByCode(string EntityCode);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="EntityId">Id của đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị xóa</returns>
        int Delete(Guid EntityId);
    }
}
