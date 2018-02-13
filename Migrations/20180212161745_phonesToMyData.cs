using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vue2Spa.Migrations
{
    public partial class phonesToMyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "MyData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyData",
                table: "MyData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyData",
                table: "MyData");

            migrationBuilder.RenameTable(
                name: "MyData",
                newName: "Phones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");
        }
    }
}
