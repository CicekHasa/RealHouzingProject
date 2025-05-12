using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealHouzing.DataAccessLayer.Migrations
{
    public partial class add_table_contactinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");
        }
    }
}
