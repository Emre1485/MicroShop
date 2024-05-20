using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.DTOLayer.DTOs.CargoDetailDTOs;
using MicroShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDTO dto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("The Cargo Detail Created");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("The Cargo Detail Deleted");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDTO dto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                CargoDetailId = dto.CargoDetailId,
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Cargo Detail Updated");
        }
    }
}
