namespace CourseManager.Migrations
{
    using CourseManager.Migrations.Seeds;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseManager.Models.CourseManagerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourseManager.Models.CourseManagerEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            new ActionLinkCreator(context).Seed();
            new SideBarCreator(context).Seed();
            new UserCreator(context).Seed();
        }
    }
}
