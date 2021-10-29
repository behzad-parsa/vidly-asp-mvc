namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO GENRES(Id , Name) Values (2 , 'Horro')");
            Sql("INSERT INTO GENRES(Id , Name) Values (3 , 'Romance')");
            Sql("INSERT INTO GENRES(Id , Name) Values (4 , 'Animation')");
            Sql("INSERT INTO GENRES(Id , Name) Values (5 , 'Drama')");
            Sql("INSERT INTO GENRES(Id , Name) Values (6 , 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
