namespace SeedyHub.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Role>().HasData(
                new Role 
                { 
                    RoleId = 1, 
                    RoleName = "Admin" 
                },
                new Role 
                { 
                    RoleId = 2, 
                    RoleName = "Regular" 
                }
            );

            modelBuilder.Entity<Members>().HasData(
                new Members
                {
                    MemberId = 1,
                    FirstName = "Jeoganni",
                    LastName = "Canda",
                    RoleId = 1,
                    Accepted = "04/30/2022"

                },
                new Members
                {
                    MemberId = 2,
                    FirstName = "Juncel",
                    LastName = "Diaz",
                    RoleId = 2,
                    Accepted = "04/30/2022"
                }
           );

        }

        public DbSet<Members> members { get; set; }
        public DbSet<Role> roles { get; set; }

    }
}
