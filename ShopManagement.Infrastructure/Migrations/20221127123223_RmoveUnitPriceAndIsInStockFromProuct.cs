﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class RmoveUnitPriceAndIsInStockFromProuct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInStock",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsInStock",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}