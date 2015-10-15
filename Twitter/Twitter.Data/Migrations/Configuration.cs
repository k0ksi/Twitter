using System.Data.Entity.Migrations;

namespace Twitter.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TwitterContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterContext context)
        {
        }
    }
}
