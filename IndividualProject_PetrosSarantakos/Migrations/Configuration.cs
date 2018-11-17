namespace IndividualProject_PetrosSarantakos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IndividualProject_PetrosSarantakos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IndividualProject_PetrosSarantakos.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFrameworkExample1.AppContext";
        }

        protected override void Seed(IndividualProject_PetrosSarantakos.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var user1 = new User()
            {
                Id = "admin",
                Password = "admin",
                Name = "Petros",
                Surname = "Sarantakos",
                BirthDate = Convert.ToDateTime("1990 - 10 - 30"),
                Email = "petros.west@gmail.com",
                UserState = (State)1
            };

            //context.Users.AddOrUpdate(user1);
            //context.SaveChanges();
        }
    }
}
