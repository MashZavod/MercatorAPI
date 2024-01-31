using MercatorAPI.Data;
using MercatorAPI.Modules.Interface;
using MercatorAPI.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MercatorAPI.Services
{
    public class CarHolderService(CarDataContext dataContext) : ICarHolder
    {
        private readonly CarDataContext _dataContext = dataContext;

        public CarHolder Create(CarHolder model)
        {
            _dataContext.carholder.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public CarHolder Update(CarHolder model)
        {
            var modelToUpdate = _dataContext.carholder.FirstOrDefault(x => x.id == model.id);

            if (modelToUpdate == null)
            {
                throw new Exception($"Failed to update {modelToUpdate}");
            }
            modelToUpdate.title = model.title;
            modelToUpdate.description = model.description;
            _dataContext.SaveChanges();
           
            return modelToUpdate;
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContext.carholder.OrderBy(x => x.id == id).LastOrDefault();
            if (modelToDelete == null)
                Console.WriteLine("ERROR WHILE DELETE!\n");
            else
            {
                _dataContext.carholder.Remove(modelToDelete);
                _dataContext.SaveChanges();
            }
        }

        public CarHolder GetCar(int id)
        {
            var car = _dataContext.carholder.FirstOrDefault(x => x.id == id);

            return car ?? throw new Exception($"No car found with id {id}");
        }

        public DbSet<CarHolder> GetCar()
        {
            return _dataContext.carholder;
        }
    }
}
