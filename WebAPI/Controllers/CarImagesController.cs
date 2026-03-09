using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase {
        ICarImageService _carImageManager;

        public CarImagesController(ICarImageService carImageManager) {
            _carImageManager = carImageManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            return Ok(_carImageManager.GetAll());
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId) {
            var images = _carImageManager.GetByCarId(carId);
            if (images.Success) {
                return Ok(images);
            }
            return BadRequest(images);
        }


        [HttpPost("add")]
        [Consumes("multipart/form-data")]
        public IActionResult Add(IFormFile image, [FromForm] int carId) {
            var result = _carImageManager.Add(image, new CarImage { CarId = carId });
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
        [HttpPost("addmultiple")]
        [Consumes("multipart/form-data")]
        public IActionResult AddMultiple([FromForm] IFormFile[] images, [FromForm] int carId) {
            var result = _carImageManager.AddMultiple(images, new CarImage { CarId = carId });
            
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        [Consumes("multipart/form-data")]
        public IActionResult Update([FromForm] CarImageUpdateDto dto) {
            var carImage = new CarImage { Id = dto.Id, CarId = dto.CarId, ImagePath = dto.ImagePath };
            var result = _carImageManager.Update(dto.File, carImage);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage) {
            var result = _carImageManager.Delete(carImage);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
