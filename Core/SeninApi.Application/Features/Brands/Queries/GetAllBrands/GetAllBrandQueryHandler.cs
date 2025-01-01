using MediatR;
using Microsoft.AspNetCore.Http;
using SeninApi.Application.Bases;
using SeninApi.Application.Interfaces.AutoMapper;
using SeninApi.Application.Interfaces.UnitOfWorks;
using SeninApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeninApi.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandQueryHandler : BaseHandler, IRequestHandler<GetAllBrandQueryRequest, IList<GetAllBrandQueryResponse>>
    {
        public GetAllBrandQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandQueryResponse>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return mapper.Map<GetAllBrandQueryResponse, Brand>(brands);
        }
    }
}
