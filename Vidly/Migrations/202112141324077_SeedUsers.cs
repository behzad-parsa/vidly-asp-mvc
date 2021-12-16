namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'35335922-5062-4e73-a871-f1f8de739144', N'guest@vidly.com', 0, N'AF85glYQwvXujoz0Fkmp/qPHXqQEYGbOn7zNJpv5qmbrb6ooxu1knjQ48ZmWQ4vgyg==', N'22525964-2a17-4bbc-9e56-6002ffdd438c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6af99874-bf56-4157-8d00-0c139fa87e40', N'admin@vildy.com', 0, N'AH3aFX/MNUze5O6f+8SOGrVaW0WzNi+OElUcFWEf9xyyZHZ7rWXhIT6iaOS9lI4XxQ==', N'4946fc59-7471-4279-9bbe-4aa62f41503b', NULL, 0, 0, NULL, 1, 0, N'admin@vildy.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9784d543-39f6-4c82-9787-c5dda6607f81', N'behzad@yahoo.com', 0, N'AOsH4vL3q2Du0Edg/JCo4JR8SF57+RtsPSUCBgiyo0V16bcEbOssh5nVxTjF/A1E5g==', N'c05d027d-e730-4bce-9d65-e06336f55854', NULL, 0, 0, NULL, 1, 0, N'behzad@yahoo.com')
        
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'102fae73-1f2b-4dc5-9071-de76190320cd', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6af99874-bf56-4157-8d00-0c139fa87e40', N'102fae73-1f2b-4dc5-9071-de76190320cd')

        ");


        }
        
        public override void Down()
        {
        }
    }
}
