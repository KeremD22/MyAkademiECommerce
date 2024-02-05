using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademiECommerceDiscount.Dtos;
using MyAkademiECommerceDiscount.Services;

namespace MyAkademiECommerceDiscount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public CouponsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]   
        public async Task <IActionResult> CouponList()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);  
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponDto(createCouponDto);
            return Ok("Kupon Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponDto(id);
            return Ok("Kupon Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon(int id)
        {
           var values =  await _discountService.GetCouponById(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
           await _discountService.UpdateCouponDto(updateCouponDto);
            return Ok("Güncelleme Yapıldı");
        }

    }
}
