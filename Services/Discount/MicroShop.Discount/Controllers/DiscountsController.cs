using MicroShop.Discount.DTOs;
using MicroShop.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetDiscountCouponById(int id)
        {
            var value = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDTO createCouponDTO)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDTO);
            return Ok("Coupon Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Coupon Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDTO);
            return Ok("Coupon Updated");
        }

    }
}
