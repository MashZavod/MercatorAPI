using Microsoft.EntityFrameworkCore;

namespace MercatorAPI.Modules.Interface
{
    public interface ICarHolder
    {
        CarHolder Create(CarHolder model);
        CarHolder Update(CarHolder model);
        CarHolder GetCar(int id);
        DbSet<CarHolder> GetCar();
        void Delete(int id);
    }
}
