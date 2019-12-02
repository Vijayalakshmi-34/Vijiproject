namespace OnlineDoctorsAppointmentBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDoctorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Long(nullable: false),
                        DoctorFirstName = c.String(),
                        DoctorLastName = c.String(),
                        Qualification = c.String(),
                        Experience = c.Byte(),
                        MobileNumber = c.Long(),
                        EmailId = c.String(),
                        PassWord = c.String(),
                        IsAvailable = c.Boolean(),
                        Location = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
