using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueEconomy.Migrations
{
    public partial class AllTableRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "logins");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "logins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins",
                column: "RolesId",
                principalTable: "roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "logins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins",
                column: "RolesId",
                principalTable: "roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
