using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.DTOLayer.DTOs.CargoProgressDTOs;
using MicroShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoProgressesController : ControllerBase
    {
        private readonly ICargoProgressService _cargoProgresService;

        public CargoProgressesController(ICargoProgressService cargoProgresService)
        {
            _cargoProgresService = cargoProgresService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoProgresService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoProgressById(int id)
        {
            var value = _cargoProgresService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoProgress(CreateCargoProgressDTO dto)
        {
            CargoProgress cargoProgress = new CargoProgress
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _cargoProgresService.TInsert(cargoProgress);
            return Ok("Cargo Progress Created.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoProgress(int id)
        {
            _cargoProgresService.TDelete(id);
            return Ok("Cargo Progress Deleted.");
        }

        [HttpPut]
        public IActionResult UpdateCargoProgress(UpdateCargoProgressDTO dto)
        {
            CargoProgress cargoProgress = new CargoProgress
            {
                CargoProgressId = dto.CargoProgressId,
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _cargoProgresService.TUpdate(cargoProgress);
            return Ok("Cargo Progress Updated.");
        }
    }
}
