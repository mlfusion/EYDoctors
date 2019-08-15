using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctors.SPA.Migrations
{
    public partial class IntiCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSchools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MedicalSchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_MedicalSchools_MedicalSchoolId",
                        column: x => x.MedicalSchoolId,
                        principalTable: "MedicalSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialties",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    SpecialtyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialties", x => new { x.DoctorId, x.SpecialtyId });
                    table.UniqueConstraint("AK_DoctorSpecialties_DoctorId", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientRatings",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRatings", x => new { x.DoctorId, x.Comments });
                    table.ForeignKey(
                        name: "FK_PatientRatings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LanguageId",
                table: "Doctors",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_MedicalSchoolId",
                table: "Doctors",
                column: "MedicalSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialties_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecialties");

            migrationBuilder.DropTable(
                name: "PatientRatings");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MedicalSchools");
        }
    }
}
