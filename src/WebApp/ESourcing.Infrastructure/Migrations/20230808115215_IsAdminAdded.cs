using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESourcing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsAdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "WebAppIdentity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "WebAppIdentity",
                table: "AspNetUsers");
        }
    }
}
