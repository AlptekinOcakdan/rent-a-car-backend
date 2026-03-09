using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class CarImageUpdateDto : IDto
    {
        public IFormFile File { get; set; }
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}

