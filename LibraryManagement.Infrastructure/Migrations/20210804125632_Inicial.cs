using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Zipcode = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    City = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
