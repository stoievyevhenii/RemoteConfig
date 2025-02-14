using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemoteConfig.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedStringValueFieldInAppConfigurationToListOfValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Configurations");

            migrationBuilder.AddColumn<string[]>(
                name: "Values",
                table: "Configurations",
                type: "text[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Values",
                table: "Configurations");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Configurations",
                type: "text",
                nullable: true);
        }
    }
}
