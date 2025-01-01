using MediatR;
using SeninApi.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeninApi.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandQueryRequest : IRequest<IList<GetAllBrandQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 5;
    }
}
