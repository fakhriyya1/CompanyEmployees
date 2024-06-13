using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("6113aa17-b2b3-49e1-a14d-a9bf787a7954"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("67618a77-5871-4aed-b49c-324810b4fa4b"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("894b46db-3b0f-43f4-a279-5f1f8f0343b6"), 30, new Guid("67618a77-5871-4aed-b49c-324810b4fa4b"), "Jana McLeaf", "Software developer" },
                    { new Guid("b0699811-6bef-4f8a-8002-0e913ca4aa6b"), 35, new Guid("6113aa17-b2b3-49e1-a14d-a9bf787a7954"), "Kane Miller", "Administrator" },
                    { new Guid("e8a67a84-f29d-41a6-93e0-897005c28825"), 26, new Guid("67618a77-5871-4aed-b49c-324810b4fa4b"), "Sam Raiden", "Software developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("894b46db-3b0f-43f4-a279-5f1f8f0343b6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b0699811-6bef-4f8a-8002-0e913ca4aa6b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e8a67a84-f29d-41a6-93e0-897005c28825"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("6113aa17-b2b3-49e1-a14d-a9bf787a7954"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("67618a77-5871-4aed-b49c-324810b4fa4b"));
        }
    }
}
