using AutoMapper;
using MediatR;
using ProductApp.Application.Dtos;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            private readonly IMapper mapper;
            private readonly IProductRepository productRepository;

            public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
            {
                this.mapper = mapper;
                this.productRepository = productRepository;
            }
            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(request.Id);
                var viewModel = mapper.Map<ProductViewDto>(product);

                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
