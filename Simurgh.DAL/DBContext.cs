using Microsoft.EntityFrameworkCore;
using Simurgh.DAL.Model;

namespace Simurgh.DAL
{
    public class SimurghDB : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public SimurghDB(DbContextOptions<SimurghDB> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscriber>()
                .HasIndex(m => m.EMail)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .Property(c => c.RowNo)
                .HasDefaultValue(0)
                .ValueGeneratedNever();

            //modelBuilder.Entity<Client>(c=> {
            //    c.Property(e => e.ClientName).IsRequired(false);
            //    c.Property(e => e.ClientDescription).IsRequired(false);
            //    c.Property(e => e.GoogleMapAddress).IsRequired(false);
            //    c.Property(e => e.Avatar).IsRequired(false);
            //    c.Property(e => e.RowNo).IsRequired(false);
            //    //c.Property(e => e.Pictures).IsRequired(false);
            //    //c.Property(e => e.Projects).IsRequired(false);
            //});

            modelBuilder.Entity<Project>()
                .Property(c => c.RowNo)
                .HasDefaultValue(0)
                .ValueGeneratedNever();

            //modelBuilder.Entity<Project>(p => {
            //    p.Property(e => e.Name).IsRequired(true);
            //    p.Property(e => e.Description).IsRequired(false);
            //    p.Property(e => e.Created).IsRequired(false);
            //    p.Property(e => e.GoogleMapAddress).IsRequired(false);
            //    //p.Property(e => e.ClientId).IsRequired(true);
            //    //p.Property(e => e.Client).IsRequired(true);
            //    p.Property(e => e.EvaluationDate).IsRequired(false);
            //    p.Property(e => e.EvaluationAmount).IsRequired(false);
            //    p.Property(e => e.MoneyRaised).IsRequired(false);
            //    p.Property(e => e.AcctualMoneySpent).IsRequired(false);
            //    p.Property(e => e.ExecutionStarted).IsRequired(false);
            //    p.Property(e => e.Finished).IsRequired(false);
            //    //p.Property(e => e.Pictures).IsRequired(false);
            //    p.Property(e => e.LastUpdated).IsRequired(false);
            //    p.Property(e => e.RowNo).IsRequired(false);
            //});


            //modelBuilder.Entity<Client>()
            //    .HasData(
            //        StaticData.Clients
            //    );
        }

    }
}
