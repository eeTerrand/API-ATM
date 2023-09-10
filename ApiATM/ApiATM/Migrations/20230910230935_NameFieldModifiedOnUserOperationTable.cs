using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiATM.Migrations
{
    /// <inheritdoc />
    public partial class NameFieldModifiedOnUserOperationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "UserOperation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "UserOperation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
