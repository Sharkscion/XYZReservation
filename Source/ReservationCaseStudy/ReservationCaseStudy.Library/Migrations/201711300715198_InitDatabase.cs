namespace ReservationCaseStudy.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Station",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 3),
                        Description = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Flight",
                c => new
                {
                    AirlineCode = c.String(nullable: false, maxLength: 2),
                    Number = c.Int(nullable: false),
                    ScheduledTimeArrival = c.Time(nullable: false, precision: 7),
                    ScheduledTimeDeparture = c.Time(nullable: false, precision: 7),
                    ArrivalStation_Code = c.String(maxLength: 3),
                    DepartureStation_Code = c.String(maxLength: 3),
                })
                .PrimaryKey(t => new { t.AirlineCode, t.Number })
                .ForeignKey("dbo.Station", t => t.ArrivalStation_Code)
                .ForeignKey("dbo.Station", t => t.DepartureStation_Code)
                .Index(t => t.ArrivalStation_Code)
                .Index(t => t.DepartureStation_Code);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        PNRNumber = c.String(nullable: false, maxLength: 6),
                        FlightAirlineCode = c.String(maxLength: 2),
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
                        Reservation_PNRNumber = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => new { t.Passenger_Id, t.Reservation_PNRNumber })
                .ForeignKey("dbo.Passenger", t => t.Passenger_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reservation", t => t.Reservation_PNRNumber, cascadeDelete: true)
                .Index(t => t.Passenger_Id)
                .Index(t => t.Reservation_PNRNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flight", "DepartureStation_Code", "dbo.Station");
            DropForeignKey("dbo.Flight", "ArrivalStation_Code", "dbo.Station");
            DropForeignKey("dbo.PassengerReservation", "Reservation_PNRNumber", "dbo.Reservation");
            DropForeignKey("dbo.PassengerReservation", "Passenger_Id", "dbo.Passenger");
            DropForeignKey("dbo.Reservation", new[] { "FlightAirlineCode", "FlightNumber" }, "dbo.Flight");
            DropIndex("dbo.PassengerReservation", new[] { "Reservation_PNRNumber" });
            DropIndex("dbo.PassengerReservation", new[] { "Passenger_Id" });
            DropIndex("dbo.Reservation", new[] { "FlightAirlineCode", "FlightNumber" });
            DropIndex("dbo.Flight", new[] { "DepartureStation_Code" });
            DropIndex("dbo.Flight", new[] { "ArrivalStation_Code" });
            DropTable("dbo.PassengerReservation");
            DropTable("dbo.Passenger");
            DropTable("dbo.Reservation");
            DropTable("dbo.Flight");
            DropTable("dbo.Station");
        }
    }
}
