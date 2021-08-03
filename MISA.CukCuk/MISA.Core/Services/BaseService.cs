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
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        
        public ServiceResult Add(MISAEntity entity)
        {
            _serviceResult.Success = true;
            return _serviceResult;
        }

        public ServiceResult Update(MISAEntity entity)
        {
            _serviceResult.Success = true;
            return _serviceResult;
        } 
    }
}
