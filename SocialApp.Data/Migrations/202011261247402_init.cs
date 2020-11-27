namespace SocialApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.String(),
                        Picture = c.String(),
                        Text = c.String(),
                        Like = c.Boolean(nullable: false),
                        Dislike = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Interests = c.String(),
                        Image = c.String(),
                        FriendRequest = c.Boolean(nullable: false),
                        Online = c.Boolean(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Users", new[] { "Post_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
