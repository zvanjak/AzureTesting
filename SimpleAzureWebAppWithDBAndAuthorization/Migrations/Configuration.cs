namespace SimpleAzureWebAppWithDBAndAuthorization.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using SimpleAzureWebAppWithDBAndAuthorization.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleAzureWebAppWithDBAndAuthorization.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleAzureWebAppWithDBAndAuthorization.Models.ApplicationDbContext context)
        {
            context.FinAccounts.AddOrUpdate(p => p.Name,
                new FinAccount
                {
                    Name = "Debra Garcia",
                    InitialBalance = 100
                },
                new FinAccount
                {
                    Name = "Thorsten Weinrich",
                    InitialBalance = 255
                }
                );
        }
    }
}
