using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelId,
                    hotelRoom.RoomNumber
                });
            modelBuilder.Entity<RoomAmenity>()
                .HasKey(roomAmenity => new
                {
                    roomAmenity.RoomID,
                    roomAmenity.AmenityID
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 3, Name = "Marrrrriot", City = "Cedar Rapids", Country = "USA", Phone = "Oh no you don't", State = "Iowa", StreetAddress = "665 Place st" },
                new Hotel { Id = 1, Name = "Carrion", City = "Cedar Rapids", Country = "USA", Phone = "Still not gonna", State = "Iowa", StreetAddress = "664 Place st" },
                new Hotel { Id = 2, Name = "Joe's House", City = "Cedar Rapids", Country = "USA", Phone = "Maybe next time", State = "Iowa", StreetAddress = "663 Place st" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 3, Layout = 0, Name = "Satin's Lounge" },
                new Room { Id = 1, Layout = 2, Name = "Rogues's Lounge" },
                new Room { Id = 2, Layout = 1, Name = "Crow's Lounge" }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 3, Name = "The Moon" },
                new Amenity { Id = 1, Name = "Soap" },
                new Amenity { Id = 2, Name = "A Tree" }
                );
        }
    }
}
