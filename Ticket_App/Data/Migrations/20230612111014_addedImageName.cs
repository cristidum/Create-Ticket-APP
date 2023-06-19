using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "TicketTopic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "TicketTopic");
        }
    }
}
