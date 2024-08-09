using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Account",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                comment: "Tên tài khoản",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldComment: "Tên tài khoản");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Mật khẩu",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldComment: "Mật khẩu");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                },
                comment: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_CreateAt",
                table: "RefreshToken",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_CreatorId",
                table: "RefreshToken",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_DeleteAt",
                table: "RefreshToken",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UpdateAt",
                table: "RefreshToken",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UpdatorId",
                table: "RefreshToken",
                column: "UpdatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Account",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                comment: "Tên tài khoản",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldComment: "Tên tài khoản");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                comment: "Mật khẩu",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Mật khẩu");
        }
    }
}
