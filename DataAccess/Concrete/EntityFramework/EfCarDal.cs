using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentDbContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(int carId)
        {
            using (CarRentDbContext context = new CarRentDbContext()) {
                var result = from car in context.Cars
                             where car.Id == carId
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Model = car.Model,
                                 Images = context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                             };
                var carDetail = result.First();
                if (carDetail.Images.Count == 0)
                {
                    carDetail.Images = new List<CarImage>
                    {
                        new CarImage
                        {
                            CarId = carDetail.Id,
                            ImagePath = "images/default.jpg"
                        }
                    };
                }
                return carDetail;                
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Model = car.Model,
                                 Images = context.CarImages.Count(ci => ci.CarId == car.Id) != 0
                                 ? context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                                 : new List<CarImage> { new CarImage {
                                        CarId = car.Id,
                                        ImagePath = "images/default.jpg"
                                    } }

                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public CarStatsDto GetCarStats(int id)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                int totalIncome = 0;
                var result = from rent in context.Rentals
                             where rent.CarId == id
                             select rent;
                foreach (var rent in result)
                {
                    totalIncome += rent.TotalPrice;
                }
                return new CarStatsDto
                {
                    Id = id,
                    TotalIncome = totalIncome,
                    TotalRentals = result.Count()
                };
            }
        }
    }
}
