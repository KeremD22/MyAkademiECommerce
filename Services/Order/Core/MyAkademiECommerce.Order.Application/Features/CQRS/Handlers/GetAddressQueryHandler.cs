using MyAkademiECommerce.Order.Application.Features.CQRS.Results;
using MyAkademiECommerce.Order.Application.Features.Interfaces;
using MyAkademiECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademiECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsnyc();
            return values.Select(x => new GetAddressByIdQueryResult
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserID = x.UserID,


            }).ToList();
        }
    }
   
}
