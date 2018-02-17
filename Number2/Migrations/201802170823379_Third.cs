namespace Number2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_BookId" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorId" });
            AddColumn("dbo.Authors", "Book_BookId", c => c.Int());
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Authors", "Book_BookId");
            AddForeignKey("dbo.Authors", "Book_BookId", "dbo.Books", "BookId");
            DropColumn("dbo.Authors", "BookId");
            DropTable("dbo.BookAuthors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookId = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookId, t.Author_AuthorId });
            
            AddColumn("dbo.Authors", "BookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Authors", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_BookId" });
            DropColumn("dbo.Books", "AuthorId");
            DropColumn("dbo.Authors", "Book_BookId");
            CreateIndex("dbo.BookAuthors", "Author_AuthorId");
            CreateIndex("dbo.BookAuthors", "Book_BookId");
            AddForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
        }
    }
}
