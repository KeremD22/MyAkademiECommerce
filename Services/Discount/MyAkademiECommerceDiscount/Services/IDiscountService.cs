using MyAkademiECommerceDiscount.Dtos;

namespace MyAkademiECommerceDiscount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task CreateCouponDto (CreateCouponDto createCouponDto);
        Task UpdateCouponDto (UpdateCouponDto updateCouponDto);
        Task DeleteCouponDto (int id);

        Task<ResultCouponDto> GetCouponById(int id);
    }
}
