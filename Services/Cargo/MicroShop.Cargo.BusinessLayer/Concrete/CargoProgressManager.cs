using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.DataAccessLayer.Abstract;
using MicroShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.BusinessLayer.Concrete
{
    public class CargoProgressManager : ICargoProgressService
    {
        private readonly ICargoProgressDal _cargoProgressDal;

        public CargoProgressManager(ICargoProgressDal cargoProgressDal)
        {
            _cargoProgressDal = cargoProgressDal;
        }

        //public void Delete(int id)
        //{
        //    _cargoProgressDal.Delete(id);
        //}

        //public List<CargoProgress> GetAll()
        //{
        //    return _cargoProgressDal.GetAll();
        //}

        //public CargoProgress GetById(int id)
        //{
        //    return _cargoProgressDal.GetById(id);
        //}

        //public void Insert(CargoProgress entity)
        //{
        //    _cargoProgressDal.Insert(entity);
        //}

        public void TDelete(int id)
        {
            _cargoProgressDal.Delete(id);
        }

        public List<CargoProgress> TGetAll()
        {
            return _cargoProgressDal.GetAll();
        }

        public CargoProgress TGetById(int id)
        {
            return _cargoProgressDal.GetById(id);
        }

        public void TInsert(CargoProgress entity)
        {
            _cargoProgressDal.Insert(entity);
        }

        public void TUpdate(CargoProgress entity)
        {
            _cargoProgressDal.Update(entity);
        }

        //public void Update(CargoProgress entity)
        //{
        //    _cargoProgressDal.Update(entity);
        //}
    }
}
