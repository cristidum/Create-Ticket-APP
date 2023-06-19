using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class changesMade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "EmailBody",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "EmailSubject",
                table: "Ticket",
                newName: "Subject");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAT",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAT",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Ticket",
                newName: "EmailSubject");

            migrationBuilder.AddColumn<string>(
                name: "EmailBody",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    TicketDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketDetailsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketSubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.TicketDetailsID);
                });
        }
    }
}
