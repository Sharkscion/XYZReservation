namespace ReservationCaseStudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFlightAndStationEntity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Flight", name: "ArrivalStation_Code", newName: "ArrivalStationCode");
            RenameColumn(table: "dbo.Flight", name: "DepartureStation_Code", newName: "DepartureStationCode");
            RenameIndex(table: "dbo.Flight", name: "IX_ArrivalStation_Code", newName: "IX_ArrivalStationCode");
            RenameIndex(table: "dbo.Flight", name: "IX_DepartureStation_Code", newName: "IX_DepartureStationCode");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Flight", name: "IX_DepartureStationCode", newName: "IX_DepartureStation_Code");
            RenameIndex(table: "dbo.Flight", name: "IX_ArrivalStationCode", newName: "IX_ArrivalStation_Code");
            RenameColumn(table: "dbo.Flight", name: "DepartureStationCode", newName: "DepartureStation_Code");
            RenameColumn(table: "dbo.Flight", name: "ArrivalStationCode", newName: "ArrivalStation_Code");
        }
    }
}
