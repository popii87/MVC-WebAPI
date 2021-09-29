using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "MyFKConstraint",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FavoriteGenre", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 5, "Robert", "Dimov", "123", "rdimov" },
                    { 2, 0, "Viktor", "Jakovlev", "456", "vjakovlev" },
                    { 3, 1, "Bob", "Bobski", "789", "bboski" },
                    { 4, 3, "Ben", "Solski", "889", "bencb" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "dasda", 0, "Rambo", 1, 1996 },
                    { 2, "Group of heroes save the world from evil", 5, " The Lord Of The Rings", 1, 2000 },
                    { 3, "Superheroes against the evil", 1, " Avengers", 1, 2002 },
                    { 4, "Superheroes against the evil", 1, " Avengers2", 1, 2002 },
                    { 5, "Superheroes against the evil", 3, "Vratice se rode", 1, 2000 },
                    { 6, "Superheroes against the evil", 4, "Interstellar", 1, 2010 },
                    { 7, "Superheroes against the evil", 2, "Money Heist", 1, 2010 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
