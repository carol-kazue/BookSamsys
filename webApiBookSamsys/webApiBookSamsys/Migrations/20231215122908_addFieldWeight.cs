using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApiBookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class addFieldWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Books");
        }
    }
}
