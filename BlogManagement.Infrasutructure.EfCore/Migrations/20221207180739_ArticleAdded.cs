using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class ArticleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
