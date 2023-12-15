using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApiBookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class addFieldtoremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AAAvouserremovido",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AAAvouserremovido",
                table: "Books");
        }
    }
}
