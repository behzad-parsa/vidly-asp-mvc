namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies Set NumberAvailable = Movies.NumberInStock ");
        }
        
        public override void Down()
        {
        }
    }
}
