using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiBookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar (50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar (50)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    AutorIdAutor = table.Column<int>(type: "int", nullable: true),
                    LivroISBN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Autores_Autores_AutorIdAutor",
                        column: x => x.AutorIdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor");
                    table.ForeignKey(
                        name: "FK_Livro_Autores_Livros_LivroISBN",
                        column: x => x.LivroISBN,
                        principalTable: "Livros",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autores_AutorIdAutor",
                table: "Livro_Autores",
                column: "AutorIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autores_LivroISBN",
                table: "Livro_Autores",
                column: "LivroISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Autores");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
