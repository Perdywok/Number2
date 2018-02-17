namespace Number2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class First : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthorBooks", newName: "BookAuthors");
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", new[] { "Book_BookId", "Author_AuthorId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", new[] { "Author_AuthorId", "Book_BookId" });
            RenameTable(name: "dbo.BookAuthors", newName: "AuthorBooks");
        }
    }
}
