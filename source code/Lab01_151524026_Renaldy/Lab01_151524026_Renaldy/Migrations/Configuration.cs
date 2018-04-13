namespace Lab01_151524026_Renaldy.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lab01_151524026_Renaldy.Models.MemberModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Lab01_151524026_Renaldy.Models.MemberModel";
        }

        protected override void Seed(Lab01_151524026_Renaldy.Models.MemberModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
