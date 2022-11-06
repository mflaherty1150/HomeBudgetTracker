using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudget.Data.Migrations
{
    public partial class RemovedProviderIdasrequiredfieldinAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Providers_ProviderId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ProviderId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ProviderEntityId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProviderEntityId",
                table: "Accounts",
                column: "ProviderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Providers_ProviderEntityId",
                table: "Accounts",
                column: "ProviderEntityId",
                principalTable: "Providers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Providers_ProviderEntityId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ProviderEntityId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ProviderEntityId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProviderId",
                table: "Accounts",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Providers_ProviderId",
                table: "Accounts",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
