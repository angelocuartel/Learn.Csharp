using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learn.Csharp.Week2.Solution.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDateUpdatedBlogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Blog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
