using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using WebsiteKernel.Mapping;
using WebsiteKernel;

namespace Service.Mappers
{
    public class DataTransferObjectsMapper : Service.Mappers.IDataTransferObjectsMapper
    {
        private readonly IMapper mapper;
        public DataTransferObjectsMapper(IMapper mapper)
        {
            Guard.IsNotNull(() => mapper);
            this.mapper = mapper;
        }

      
    }
}
