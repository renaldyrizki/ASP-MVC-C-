namespace Lab01_151524026_Renaldy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public class MemberModel : DbContext
    {
        public MemberModel()
            : base("name=db_lab01") // nama connection string
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }
    }
}