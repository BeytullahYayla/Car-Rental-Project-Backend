using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car() {CarID=1,BrandID=1,ColorID=2,ModelYear="2014",DailyPrice=150,Description="Çicek Gibi Araba" },
                new Car() {CarID=2,BrandID=3,ColorID=1,ModelYear="2020",DailyPrice=300,Description="Param Olsaaaaa daaaaa ben binsemmmm" },
                new Car() {CarID=3,BrandID=4,ColorID=4,ModelYear="2021",DailyPrice=350,Description="Doktordan temiz" },
                new Car() {CarID=4,BrandID=2,ColorID=3,ModelYear="2013",DailyPrice=120,Description="Programcıdan Hafif Kırık" }
            };
            Console.WriteLine("Sistem InMemory Alternatifine Geçti... SOLİD BEBEK GİBİ ÇALIŞIYOR YANİ HEEE");
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(item => item.CarID == car.CarID);
            _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(item => item.CarID == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;

            carToUpdate = _cars.SingleOrDefault(item => item.CarID == car.CarID);

            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
