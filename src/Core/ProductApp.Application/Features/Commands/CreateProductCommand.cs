using AutoMapper;
using MediatR;
using ProductApp.Application.Dtos;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using ProductApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductApp.Application.Features.Commands
{
    public class CreateProductCommand : IRequest<ServiceResponse< Guid>>
    {

        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public class CreateProductQueryHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
           
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public CreateProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }


            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                product.Id = Guid.NewGuid();
                await productRepository.AddAsync(product);
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
