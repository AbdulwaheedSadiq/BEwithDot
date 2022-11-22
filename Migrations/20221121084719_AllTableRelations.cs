using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueEconomy.Migrations
{
    public partial class AllTableRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoatStockId",
                table: "payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FisherMansGroupId",
                table: "payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "logins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BoatStockId",
                table: "loanBoats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FisherMansGroupId",
                table: "loanBoats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FisherMansGroupId",
                table: "fisherMansGroupMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_LoginId",
                table: "suppliers",
                column: "LoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_BoatStockId",
                table: "payments",
                column: "BoatStockId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_FisherMansGroupId",
                table: "payments",
                column: "FisherMansGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_logins_RolesId",
                table: "logins",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_loanBoats_BoatStockId",
                table: "loanBoats",
                column: "BoatStockId");

            migrationBuilder.CreateIndex(
                name: "IX_loanBoats_FisherMansGroupId",
                table: "loanBoats",
                column: "FisherMansGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_fisherMansGroupMembers_FisherMansGroupId",
                table: "fisherMansGroupMembers",
                column: "FisherMansGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_fisherMansGroupMembers_fisherMansgroup_FisherMansGroupId",
                table: "fisherMansGroupMembers",
                column: "FisherMansGroupId",
                principalTable: "fisherMansgroup",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_loanBoats_boatStock_BoatStockId",
                table: "loanBoats",
                column: "BoatStockId",
                principalTable: "boatStock",
                principalColumn: "BoatStockId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_loanBoats_fisherMansgroup_FisherMansGroupId",
                table: "loanBoats",
                column: "FisherMansGroupId",
                principalTable: "fisherMansgroup",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins",
                column: "RolesId",
                principalTable: "roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_boatStock_BoatStockId",
                table: "payments",
                column: "BoatStockId",
                principalTable: "boatStock",
                principalColumn: "BoatStockId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_fisherMansgroup_FisherMansGroupId",
                table: "payments",
                column: "FisherMansGroupId",
                principalTable: "fisherMansgroup",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_logins_LoginId",
                table: "suppliers",
                column: "LoginId",
                principalTable: "logins",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fisherMansGroupMembers_fisherMansgroup_FisherMansGroupId",
                table: "fisherMansGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_loanBoats_boatStock_BoatStockId",
                table: "loanBoats");

            migrationBuilder.DropForeignKey(
                name: "FK_loanBoats_fisherMansgroup_FisherMansGroupId",
                table: "loanBoats");

            migrationBuilder.DropForeignKey(
                name: "FK_logins_roles_RolesId",
                table: "logins");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_boatStock_BoatStockId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_fisherMansgroup_FisherMansGroupId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_logins_LoginId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_LoginId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_payments_BoatStockId",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_FisherMansGroupId",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_logins_RolesId",
                table: "logins");

            migrationBuilder.DropIndex(
                name: "IX_loanBoats_BoatStockId",
                table: "loanBoats");

            migrationBuilder.DropIndex(
                name: "IX_loanBoats_FisherMansGroupId",
                table: "loanBoats");

            migrationBuilder.DropIndex(
                name: "IX_fisherMansGroupMembers_FisherMansGroupId",
                table: "fisherMansGroupMembers");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "BoatStockId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "FisherMansGroupId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "logins");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "logins");

            migrationBuilder.DropColumn(
                name: "BoatStockId",
                table: "loanBoats");

            migrationBuilder.DropColumn(
                name: "FisherMansGroupId",
                table: "loanBoats");

            migrationBuilder.DropColumn(
                name: "FisherMansGroupId",
                table: "fisherMansGroupMembers");
        }
    }
}
