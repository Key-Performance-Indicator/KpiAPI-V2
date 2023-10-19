using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kpi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Projects_ProjectId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId1",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRolesProject");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId1",
                table: "UserRolesProject",
                newName: "IX_UserRolesProject_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRolesProject",
                newName: "IX_UserRolesProject_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_ProjectId",
                table: "UserRolesProject",
                newName: "IX_UserRolesProject_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRolesProject",
                table: "UserRolesProject",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesProject_Projects_ProjectId",
                table: "UserRolesProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesProject_Roles_RoleId",
                table: "UserRolesProject",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesProject_Users_UserId1",
                table: "UserRolesProject",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesProject_Projects_ProjectId",
                table: "UserRolesProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesProject_Roles_RoleId",
                table: "UserRolesProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesProject_Users_UserId1",
                table: "UserRolesProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRolesProject",
                table: "UserRolesProject");

            migrationBuilder.RenameTable(
                name: "UserRolesProject",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolesProject_UserId1",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolesProject_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolesProject_ProjectId",
                table: "UserRoles",
                newName: "IX_UserRoles_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Projects_ProjectId",
                table: "UserRoles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId1",
                table: "UserRoles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
