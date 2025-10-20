using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InsertCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c7c25e71-1522-443f-b8ac-a0973ee5c7c8"), "Fantasy" },
                    { new Guid("c9e38b7c-6a8d-4dbc-b80d-9106f7581534"), "Science Fiction" },
                    { new Guid("d2a3c710-ce95-4099-85e8-5e77d5dbdd2b"), "Mystery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7c25e71-1522-443f-b8ac-a0973ee5c7c8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9e38b7c-6a8d-4dbc-b80d-9106f7581534"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2a3c710-ce95-4099-85e8-5e77d5dbdd2b"));
        }
    }
}
