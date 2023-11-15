using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_Service.Service.GarnitureService
{
    public class GarnitureManager : IGarnitureService
    {
        private readonly IGarnitureDal _garnitureDal;

        public GarnitureManager(IGarnitureDal garnitureDal)
        {
            _garnitureDal = garnitureDal;
        }
        public void Create(Garniture entity)
        {
            _garnitureDal.Create(entity);
        }
        public IEnumerable<Garniture> GetAll()
        {
            return _garnitureDal.GetAll();
        }
        public Garniture GetById(int id)
        {
            return _garnitureDal.GetById(id);
        }
        public void Update(Garniture entity)
        {
            entity.UpdatedDate= DateTime.Now;
            _garnitureDal.Update(entity);
        }
        public void UpdateStatus(int id)
        {
            var garniture = _garnitureDal.GetById(id);
            garniture.Status = garniture.Status == Status.Active ? Status.Passive : Status.Active;
            garniture.UpdatedDate = DateTime.Now;
            _garnitureDal.Update(garniture);
        }
    }
}
