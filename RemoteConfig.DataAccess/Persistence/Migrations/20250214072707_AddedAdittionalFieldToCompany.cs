using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemoteConfig.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdittionalFieldToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Company",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Company");
        }
    }
}
