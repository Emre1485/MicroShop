using MicroShop.Discount.DTOs;

namespace MicroShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDTO>> GetAllDiscountCouponAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetByIdDiscountCouponDTO> GetByIdDiscountCouponAsync(int id);
}
