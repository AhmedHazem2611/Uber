using Uber.Models;

namespace Uber.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthRepo Users { get; }

        public IGenericRepo<Ride> Rides { get; }

        public IGenericRepo<Payment> Payments { get; }

        public IGenericRepo<Rating> Ratings { get; }

        public IGenericRepo<Vehicle> Vehicles { get; }
        private readonly AppDbContext context;
        public UnitOfWork(IAuthRepo users, IGenericRepo<Ride> rides, IGenericRepo<Payment> payments, IGenericRepo<Rating> ratings, IGenericRepo<Vehicle> vehicles, AppDbContext context)
        {
            Users = users;
            Rides = rides;
            Payments = payments;
            Ratings = ratings;
            Vehicles = vehicles;
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
