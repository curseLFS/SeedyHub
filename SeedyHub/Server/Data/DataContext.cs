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

            modelBuilder.Entity<Category>().HasData(
                new Category 
                {
                    CategoryId = 1,
                    CategoryName = "Fruits"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Frozen Goods"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Vegetables"
                }
            );
;

            modelBuilder.Entity<Members>().HasData(
                new Members
                {
                    MemberId = 1,
                    FirstName = "Jeoganni",
                    LastName = "Canda",
                    Suffix = "Jr",
                    Birthday = DateTime.Now,
                    RoleId = 1,
                    Accepted = DateTime.Now

                },
                new Members
                {
                    MemberId = 2,
                    FirstName = "Juncel",
                    LastName = "Diaz",
                    Suffix = "",
                    Birthday = DateTime.Now,
                    RoleId = 2,
                    Accepted = DateTime.Now
                }
           );

            modelBuilder.Entity<ItemDetails>().HasData(
                new ItemDetails
                {
                    ItemId = 1,
                    ItemName = "Mango",
                    Price = 60.00,
                    Quantity = 30,
                    TotalPrice = 1800.00,
                    TotalQuantity = 30,
                    Description = "The mango fruit is roughly oval in shape," +
                        " with uneven sides. The fruit is a drupe, with an outer" +
                        " flesh surrounding a stone. The flesh is soft and bright" + 
                        " yellow-orange in color. The skin of the fruit is" +
                        " yellow-green to red. Mango trees can grow to a height" + 
                        " of 45 m (148 ft) and can live for in excess of 100 years.",
                    DateOfTransaction = DateTime.Now,
                    CategoryId = 1
                },
                new ItemDetails
                {
                    ItemId = 2,
                    ItemName = "Fries",
                    Price = 120.00,
                    Quantity = 50,
                    TotalPrice = 6000.00,
                    TotalQuantity = 50,
                    Description = "French fries are served hot, either soft or" +
                        " crispy, and are generally eaten as part of lunch or" +
                        " dinner or by themselves as a snack, and they commonly" +
                        " appear on the menus of diners, fast food restaurants," +
                        " pubs, and bars.",
                    DateOfTransaction = DateTime.Now,
                    CategoryId = 2
                },
                new ItemDetails
                {
                    ItemId = 3,
                    ItemName = "Talong",
                    Price = 20.00,
                    Quantity = 10,
                    TotalPrice = 200.00,
                    TotalQuantity = 20,
                    Description = "Filipino eggplants, botanically classified as" +
                    " Solanum melongena, are cultivated in the Philippines and are" +
                    " a member of the Solanaceae, or nightshade family. Similar to" +
                    " the Chinese eggplant and Japanese eggplant, these fruits are" +
                    " known for their sweet flavor, very few seeds, and meaty texture",
                    DateOfTransaction = DateTime.Now,
                    CategoryId = 3
                }
            );
        }

        public DbSet<Members> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ItemDetails> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
