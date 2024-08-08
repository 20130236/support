using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Tên tài khoản"),
                    Password = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Mật khẩu"),
                    RoleName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Tên vai trò"),
                    RoleCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Mã vai trò"),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                },
                comment: "Tài khoản");

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Mã số"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Tên gọi"),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                },
                comment: "Chi nhánh");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Mã số"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Tên gọi"),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                },
                comment: "Giáo viên");

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Mã số"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Tên gọi"),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Lớp học");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Mã số"),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Tên gọi"),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id lớp học"),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian khởi tạo"),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người tạo"),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian chỉnh sửa cuối"),
                    UpdatorId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Id người chỉnh sửa"),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Thời gian xóa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Sinh viên");

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreateAt", "CreatorId", "DeleteAt", "Password", "RoleCode", "RoleName", "UpdateAt", "UpdatorId", "UserName" },
                values: new object[,]
                {
                    { new Guid("653dc4d4-ca05-45ac-83cd-e98fa91b890f"), null, null, null, "123", "SV", "Sinh viên", null, null, "usernameSV" },
                    { new Guid("6f6e615e-feeb-40b5-b53c-7f9056082d36"), null, null, null, "123", "GV", "Giáo viên", null, null, "usernameGV" }
                });

            migrationBuilder.InsertData(
                table: "Site",
                columns: new[] { "Id", "Code", "CreateAt", "CreatorId", "DeleteAt", "Name", "UpdateAt", "UpdatorId" },
                values: new object[,]
                {
                    { new Guid("3e08cf2e-d8a2-49b5-8663-fa31f0cdd168"), "H002", null, null, null, "Quận 6", null, null },
                    { new Guid("7a2ed7c2-e6f7-48c1-a86a-aa701aee1e22"), "H001", null, null, null, "Quận 5", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreateAt",
                table: "Account",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreatorId",
                table: "Account",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_DeleteAt",
                table: "Account",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdateAt",
                table: "Account",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatorId",
                table: "Account",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserName",
                table: "Account",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Code",
                table: "Class",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_CreateAt",
                table: "Class",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CreatorId",
                table: "Class",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_DeleteAt",
                table: "Class",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Name",
                table: "Class",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_UpdateAt",
                table: "Class",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Class_UpdatorId",
                table: "Class",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Code",
                table: "Site",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_CreateAt",
                table: "Site",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CreatorId",
                table: "Site",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_DeleteAt",
                table: "Site",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Name",
                table: "Site",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Site_UpdateAt",
                table: "Site",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Site_UpdatorId",
                table: "Site",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Code",
                table: "Student",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreateAt",
                table: "Student",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreatorId",
                table: "Student",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeleteAt",
                table: "Student",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Name",
                table: "Student",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdateAt",
                table: "Student",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdatorId",
                table: "Student",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Code",
                table: "Teacher",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CreateAt",
                table: "Teacher",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CreatorId",
                table: "Teacher",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DeleteAt",
                table: "Teacher",
                column: "DeleteAt");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Name",
                table: "Teacher",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UpdateAt",
                table: "Teacher",
                column: "UpdateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UpdatorId",
                table: "Teacher",
                column: "UpdatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
