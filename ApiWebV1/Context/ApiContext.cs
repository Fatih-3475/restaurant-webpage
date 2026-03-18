using ApiProjeWeb.Entities;
using ApiWebV1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeWeb.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Messega> Messegas { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<YummyEvent> YummyEvents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Messega>()
                .Property(x => x.SendData)
                .HasColumnType("timestamp without time zone");
        }
    }
}
