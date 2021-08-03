using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    /// <summary>
    /// Interface các nghiệp vụ
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng tham chiếu đến</typeparam>
    /// Created By LNNam (01/08/2021)
    public interface IBaseService<MISAEntity>
    {
        // Thêm mới bản ghi
        public ServiceResult Add(MISAEntity entity);

        // Sửa đổi bản ghi
        public ServiceResult Update(MISAEntity entity);
    }
}
