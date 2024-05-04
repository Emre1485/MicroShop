using Dapper;
using MicroShop.Discount.Context;
using MicroShop.Discount.DTOs;

namespace MicroShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    async Task IDiscountService.CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        var paramaters = new DynamicParameters();
        paramaters.Add("@code", createCouponDTO.Code);
        paramaters.Add("@rate", createCouponDTO.Rate);
        paramaters.Add("@isActive", createCouponDTO.IsActive);
        paramaters.Add("@validDate", createCouponDTO.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, paramaters);
        }
    }

    async Task IDiscountService.DeleteDiscountCouponAsync(int id)
    {
        string query = "Delete From Coupons Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query,parameters);
        }
    }

    async Task<List<ResultDiscountCouponDTO>> IDiscountService.GetAllDiscountCouponAsync()
    {
        string query = "Select * From Coupons";
        using(var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultDiscountCouponDTO>(query);
            return values.ToList();
        }
    }

    async Task<GetByIdDiscountCouponDTO> IDiscountService.GetByIdDiscountCouponAsync(int id)
    {
        string query = "Select * From Coupons Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", id);
        using(var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDTO>(query, parameters);
            return value;
        }
    }

    async Task IDiscountService.UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO)
    {
        string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
        var paramaters = new DynamicParameters();
        paramaters.Add("@code", updateCouponDTO.Code);
        paramaters.Add("@rate", updateCouponDTO.Rate);
        paramaters.Add("@isActive", updateCouponDTO.IsActive);
        paramaters.Add("@validDate", updateCouponDTO.ValidDate);
        paramaters.Add("@couponId", updateCouponDTO.CouponId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, paramaters);
        }
    }
}
