using MicroShop.Cargo.DataAccessLayer.Abstract;
using MicroShop.Cargo.DataAccessLayer.Concrete;
using MicroShop.Cargo.DataAccessLayer.Repositories;
using MicroShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EFCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
