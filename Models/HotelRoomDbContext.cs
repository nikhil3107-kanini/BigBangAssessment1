﻿using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Models
{
    public class HotelRoomDbContext: DbContext
    {

        public HotelRoomDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Hotel>? Hotels { get; set; }

        public DbSet<Room>? Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);
        }

        
    }
}
