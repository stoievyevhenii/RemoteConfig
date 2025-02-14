using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemoteConfig.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNormalizedKeyFieldToAppConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedKey",
                table: "Configurations",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedKey",
                table: "Configurations");
        }
    }
}
