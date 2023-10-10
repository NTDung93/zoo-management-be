using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCertificates_Certificates_CertificateCode1",
                table: "EmployeeCertificates");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCertificates_CertificateCode1",
                table: "EmployeeCertificates");

            migrationBuilder.DropColumn(
                name: "CertificateCode1",
                table: "EmployeeCertificates");

            migrationBuilder.AlterColumn<string>(
                name: "CertificateCode",
                table: "EmployeeCertificates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificates_CertificateCode",
                table: "EmployeeCertificates",
                column: "CertificateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCertificates_Certificates_CertificateCode",
                table: "EmployeeCertificates",
                column: "CertificateCode",
                principalTable: "Certificates",
                principalColumn: "CertificateCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCertificates_Certificates_CertificateCode",
                table: "EmployeeCertificates");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCertificates_CertificateCode",
                table: "EmployeeCertificates");

            migrationBuilder.AlterColumn<string>(
                name: "CertificateCode",
                table: "EmployeeCertificates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateCode1",
                table: "EmployeeCertificates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificates_CertificateCode1",
                table: "EmployeeCertificates",
                column: "CertificateCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCertificates_Certificates_CertificateCode1",
                table: "EmployeeCertificates",
                column: "CertificateCode1",
                principalTable: "Certificates",
                principalColumn: "CertificateCode");
        }
    }
}
