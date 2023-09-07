using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website.Migrations
{
    /// <inheritdoc />
    public partial class AddPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenDiagonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoresCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2a03ea6-0baa-4943-9987-59bf57f8e2f1", "AQAAAAIAAYagAAAAEFREqhIiZnm4Ev4avAMvn4QD3Pg3DpOO6WZq+Pllg4cT1I/R6PHWDLKz7mf9px9E1g==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 4, 9, 42, 42, 557, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 4, 9, 42, 42, 557, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 4, 9, 42, 42, 557, DateTimeKind.Utc).AddTicks(1677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07e5b160-ef79-4193-b504-733ec9862c1a", "AQAAAAIAAYagAAAAEELQunuzQT9Zu7eHSQfJVTDuBcKefbSId/aRhqOPF6jW5FUEr3RsByMBYORixWfYzA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2023, 8, 24, 11, 38, 3, 449, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2023, 8, 24, 11, 38, 3, 449, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2023, 8, 24, 11, 38, 3, 449, DateTimeKind.Utc).AddTicks(6969));
        }
    }
}
