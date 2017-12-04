﻿
using XYZReservation.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace XYZReservation
{ 

    public class ReservationDBContext : DbContext
    {

        public DbSet<Station> Stations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        //Note: prevents the code to generate pluralized tables
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        
    }
}
