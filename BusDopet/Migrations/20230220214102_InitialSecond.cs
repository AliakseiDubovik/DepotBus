using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusDepot.Migrations
{
    public partial class InitialSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Buses_BusId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_BusId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Trip",
                table: "Routes");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusId",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TripId",
                table: "Routes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Routes");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Trip",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Buses_BusId",
                table: "Trips",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
