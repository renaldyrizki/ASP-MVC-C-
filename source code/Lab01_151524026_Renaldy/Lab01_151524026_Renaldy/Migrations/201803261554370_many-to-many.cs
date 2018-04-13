namespace Lab01_151524026_Renaldy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompetitionMembers",
                c => new
                    {
                        Competition_CompetitionId = c.Int(nullable: false),
                        Member_MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Competition_CompetitionId, t.Member_MemberId })
                .ForeignKey("dbo.Competition", t => t.Competition_CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.Member_MemberId, cascadeDelete: true)
                .Index(t => t.Competition_CompetitionId)
                .Index(t => t.Member_MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompetitionMembers", "Member_MemberId", "dbo.Member");
            DropForeignKey("dbo.CompetitionMembers", "Competition_CompetitionId", "dbo.Competition");
            DropIndex("dbo.CompetitionMembers", new[] { "Member_MemberId" });
            DropIndex("dbo.CompetitionMembers", new[] { "Competition_CompetitionId" });
            DropTable("dbo.CompetitionMembers");
        }
    }
}
