namespace XYZReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        AirlineCode = c.String(nullable: false, maxLength: 128),
                        Number = c.Int(nullable: false),
                        ArrivalStationCode = c.String(maxLength: 128),
                        DepartureStationCode = c.String(maxLength: 128),
                        ScheduledTimeArrival = c.Time(nullable: false, precision: 7),
                        ScheduledTimeDeparture = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.AirlineCode, t.Number })
                .ForeignKey("dbo.Station", t => t.ArrivalStationCode)
                .ForeignKey("dbo.Station", t => t.DepartureStationCode)
                .Index(t => t.ArrivalStationCode)
                .Index(t => t.DepartureStationCode);
            
            CreateTable(
                "dbo.Station",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        PNRNumber = c.String(nullable: false, maxLength: 128),
                        FlightAirlineCode = c.String(maxLength: 128),
                        FlightNumber = c.Int(nullable: false),
                        FlightDate = c.DateTime(nullable: false),
                        NumPassengers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PNRNumber)
                .ForeignKey("dbo.Flight", t => new { t.FlightAirlineCode, t.FlightNumber })
                .Index(t => new { t.FlightAirlineCode, t.FlightNumber });
            
            CreateTable(
                "dbo.Passenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 64),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PassengerReservation",
                c => new
                    {
                        Passenger_Id = c.Int(nullable: false),
                        Reservation_PNRNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Passenger_Id, t.Reservation_PNRNumber })
                .ForeignKey("dbo.Passenger", t => t.Passenger_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reservation", t => t.Reservation_PNRNumber, cascadeDelete: true)
                .Index(t => t.Passenger_Id)
                .Index(t => t.Reservation_PNRNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassengerReservation", "Reservation_PNRNumber", "dbo.Reservation");
            DropForeignKey("dbo.PassengerReservation", "Passenger_Id", "dbo.Passenger");
            DropForeignKey("dbo.Reservation", new[] { "FlightAirlineCode", "FlightNumber" }, "dbo.Flight");
            DropForeignKey("dbo.Flight", "DepartureStationCode", "dbo.Station");
            DropForeignKey("dbo.Flight", "ArrivalStationCode", "dbo.Station");
            DropIndex("dbo.PassengerReservation", new[] { "Reservation_PNRNumber" });
            DropIndex("dbo.PassengerReservation", new[] { "Passenger_Id" });
            DropIndex("dbo.Reservation", new[] { "FlightAirlineCode", "FlightNumber" });
            DropIndex("dbo.Flight", new[] { "DepartureStationCode" });
            DropIndex("dbo.Flight", new[] { "ArrivalStationCode" });
            DropTable("dbo.PassengerReservation");
            DropTable("dbo.Passenger");
            DropTable("dbo.Reservation");
            DropTable("dbo.Station");
            DropTable("dbo.Flight");
        }
    }
}
