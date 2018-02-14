namespace Number2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 100),
                        Pages = c.Int(nullable: false),
                        Content = c.String(),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_AuthorId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorId, t.Book_BookId })
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.AuthorBooks", new[] { "Book_BookId" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_AuthorId" });
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
        }
    }
}
