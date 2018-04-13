namespace Lab01_151524026_Renaldy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(nullable: false, maxLength: 255),
                        Location = c.String(maxLength: 255),
                        Motto = c.String(maxLength: 225),
                        EstabilishedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(nullable: false, maxLength: 255),
                        Location = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 225),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        DateOfBirth = c.DateTime(nullable: false),
                        Height = c.Int(),
                        Weight = c.Int(),
                        Email = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Member");
            DropTable("dbo.Competition");
            DropTable("dbo.Club");
        }
    }
}
