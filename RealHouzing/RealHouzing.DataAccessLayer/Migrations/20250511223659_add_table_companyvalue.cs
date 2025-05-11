using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealHouzing.DataAccessLayer.Migrations
{
    public partial class add_table_companyvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyValues",
                columns: table => new
                {
                    CompanyValueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage1 = table.Column<int>(type: "int", nullable: false),
                    ValueTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage2 = table.Column<int>(type: "int", nullable: false),
                    ValueTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyValues", x => x.CompanyValueID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyValues");
        }
    }
}
