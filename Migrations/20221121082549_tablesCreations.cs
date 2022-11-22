using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueEconomy.Migrations
{
    public partial class tablesCreations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fisherMansgroup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crewName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    physicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fisherMansgroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fisherMansGroupMembers",
                columns: table => new
                {
                    GroupMembersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupMembersFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMembersMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMembersLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMembersPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMembersZMANumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fisherMansGroupMembers", x => x.GroupMembersId);
                });

            migrationBuilder.CreateTable(
                name: "loanBoats",
                columns: table => new
                {
                    LoanBoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoatCodeNumbergenerated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditCost = table.Column<float>(type: "real", nullable: false),
                    HiredBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanBoats", x => x.LoanBoatId);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ammountCredited = table.Column<float>(type: "real", nullable: false),
                    ammountdebited = table.Column<float>(type: "real", nullable: false),
                    Paidby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    physicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fromWhere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fisherMansgroup");

            migrationBuilder.DropTable(
                name: "fisherMansGroupMembers");

            migrationBuilder.DropTable(
                name: "loanBoats");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
