using Uber.Models;

namespace Uber.Repos
{
    public interface IUnitOfWork
    {
        public IAuthRepo Users { get; }
        public IGenericRepo<Ride> Rides { get; }
        public IGenericRepo<Payment> Payments {  get; }
        public IGenericRepo<Rating> Ratings { get; }
        public IGenericRepo<Vehicle> Vehicles { get; }

        public void Save();
    }
}
