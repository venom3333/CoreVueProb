using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vue2Spa.Migrations
{
    public partial class secondTable_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyData",
                table: "MyData");

            migrationBuilder.RenameTable(
                name: "MyData",
                newName: "MyDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyDatas",
                table: "MyDatas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyDataCategory",
                columns: table => new
                {
                    MyDataId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyDataCategory", x => new { x.MyDataId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MyDataCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyDataCategory_MyDatas_MyDataId",
                        column: x => x.MyDataId,
                        principalTable: "MyDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyDataCategory_CategoryId",
                table: "MyDataCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyDataCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyDatas",
                table: "MyDatas");

            migrationBuilder.RenameTable(
                name: "MyDatas",
                newName: "MyData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyData",
                table: "MyData",
                column: "Id");
        }
    }
}
