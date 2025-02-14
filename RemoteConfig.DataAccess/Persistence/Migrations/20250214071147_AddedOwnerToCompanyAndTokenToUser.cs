using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemoteConfig.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedOwnerToCompanyAndTokenToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Owner",
                table: "Company",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "AspNetUsers");
        }
    }
}
