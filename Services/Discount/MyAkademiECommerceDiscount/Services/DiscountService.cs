using AutoMapper;
using Dapper;
using MyAkademiECommerceDiscount.Context;
using MyAkademiECommerceDiscount.Dtos;
using MyAkademiECommerceDiscount.Models;

namespace MyAkademiECommerceDiscount.Services
{
    public class DiscountService:IDiscountService
    {
        private readonly DapperContext _context;
      

        public DiscountService(DapperContext context)
        {
            _context = context;
          
        }

        public async Task CreateCouponDto(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", true);
            parameters.Add("@validDate", DateTime.Now.AddDays(10));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponDto(int id)
        {
            string query = "Delete from Coupons where CouponID=@couponID";
            var parameters=new DynamicParameters();
            parameters.Add("@couponID", id);
            using(var  connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "Select * From Coupons";
            using(var connection = _context.CreateConnection()) 
            { 
                var values=await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultCouponDto> GetCouponById(int id)
        {
            string query = "Select * From Coupons where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using(var connection = _context.CreateConnection())
            {
               var values=await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdateCouponDto(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponID", updateCouponDto.CouponID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
