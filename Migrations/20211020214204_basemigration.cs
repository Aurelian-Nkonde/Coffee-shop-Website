using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace two.Migrations
{
    public partial class basemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TotalPeople = table.Column<int>(type: "integer", nullable: false),
                    CoffeeNames = table.Column<string>(type: "text", nullable: false),
                    TotalCoffees = table.Column<int>(type: "integer", nullable: false),
                    DateBooking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeBooking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "coffees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Info = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coffees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coffees_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coffees_OrderId",
                table: "coffees",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coffees");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
