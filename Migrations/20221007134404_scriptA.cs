using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management.Migrations
{
    public partial class scriptA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesigRank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                });

            migrationBuilder.CreateTable(
                name: "MedicineLists",
                columns: table => new
                {
                    MedicineListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MedicineListId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineLists", x => x.MedicineListId);
                    table.ForeignKey(
                        name: "FK_MedicineLists_MedicineLists_MedicineListId1",
                        column: x => x.MedicineListId1,
                        principalTable: "MedicineLists",
                        principalColumn: "MedicineListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtSymtomps",
                columns: table => new
                {
                    PtSymtompId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InPtPrescriptionId = table.Column<int>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtSymtomps", x => x.PtSymtompId);
                });

            migrationBuilder.CreateTable(
                name: "Testlists",
                columns: table => new
                {
                    TestlistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testlists", x => x.TestlistId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNo = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    DesignationId = table.Column<int>(nullable: false),
                    DoctorType = table.Column<string>(nullable: true),
                    VisitFee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorsId);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNo = table.Column<int>(nullable: false),
                    BedType = table.Column<string>(nullable: true),
                    BedCharge = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appoinments",
                columns: table => new
                {
                    AppoinmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    AppointDate = table.Column<DateTime>(nullable: false),
                    Problem = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
                    DoctorsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoinments", x => x.AppoinmentId);
                    table.ForeignKey(
                        name: "FK_Appoinments_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDays = table.Column<string>(nullable: true),
                    ScheduleTime = table.Column<string>(nullable: true),
                    DoctorsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddmissionDate = table.Column<DateTime>(nullable: false),
                    Problem = table.Column<string>(nullable: true),
                    IsRelase = table.Column<bool>(nullable: false),
                    DoctorsId = table.Column<int>(nullable: false),
                    BedId = table.Column<int>(nullable: false),
                    OutptPresccriptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.AdmissionId);
                    table.ForeignKey(
                        name: "FK_Admissions_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "BedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorsId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OutptPresccripts",
                columns: table => new
                {
                    OutptPresccriptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppoinmentId = table.Column<int>(nullable: false),
                    MedicineName = table.Column<string>(nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    Instruction = table.Column<string>(nullable: true),
                    Admitstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutptPresccripts", x => x.OutptPresccriptId);
                    table.ForeignKey(
                        name: "FK_OutptPresccripts_Appoinments_AppoinmentId",
                        column: x => x.AppoinmentId,
                        principalTable: "Appoinments",
                        principalColumn: "AppoinmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddmisonId = table.Column<int>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    FacilityPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilitiesId);
                    table.ForeignKey(
                        name: "FK_Facilities_Admissions_AddmisonId",
                        column: x => x.AddmisonId,
                        principalTable: "Admissions",
                        principalColumn: "AdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InPtPrescriptions",
                columns: table => new
                {
                    InPtPrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddmisonId = table.Column<int>(nullable: false),
                    IsReleased = table.Column<bool>(nullable: false),
                    PrescriptionDate = table.Column<DateTime>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    Relase = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InPtPrescriptions", x => x.InPtPrescriptionId);
                    table.ForeignKey(
                        name: "FK_InPtPrescriptions_Admissions_AddmisonId",
                        column: x => x.AddmisonId,
                        principalTable: "Admissions",
                        principalColumn: "AdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionId = table.Column<int>(nullable: false),
                    FacilitiesId = table.Column<int>(nullable: false),
                    PatientTestId = table.Column<int>(nullable: false),
                    PatientMedicineId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Payment = table.Column<decimal>(nullable: false),
                    Due = table.Column<decimal>(nullable: false),
                    NetPayment = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailsId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "AdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTests",
                columns: table => new
                {
                    PatientTestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InPtPrescriptionId = table.Column<int>(nullable: false),
                    TestlistId = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTests", x => x.PatientTestId);
                    table.ForeignKey(
                        name: "FK_PatientTests_InPtPrescriptions_InPtPrescriptionId",
                        column: x => x.InPtPrescriptionId,
                        principalTable: "InPtPrescriptions",
                        principalColumn: "InPtPrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTests_Testlists_TestlistId",
                        column: x => x.TestlistId,
                        principalTable: "Testlists",
                        principalColumn: "TestlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PntMedicines",
                columns: table => new
                {
                    PntMedicineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InPtPrescriptionId = table.Column<int>(nullable: false),
                    MedicineListId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Doges = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PntMedicines", x => x.PntMedicineId);
                    table.ForeignKey(
                        name: "FK_PntMedicines_InPtPrescriptions_InPtPrescriptionId",
                        column: x => x.InPtPrescriptionId,
                        principalTable: "InPtPrescriptions",
                        principalColumn: "InPtPrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PntMedicines_MedicineLists_MedicineListId",
                        column: x => x.MedicineListId,
                        principalTable: "MedicineLists",
                        principalColumn: "MedicineListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_BedId",
                table: "Admissions",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DoctorsId",
                table: "Admissions",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appoinments_DoctorsId",
                table: "Appoinments",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DesignationId",
                table: "Doctors",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AddmisonId",
                table: "Facilities",
                column: "AddmisonId");

            migrationBuilder.CreateIndex(
                name: "IX_InPtPrescriptions_AddmisonId",
                table: "InPtPrescriptions",
                column: "AddmisonId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineLists_MedicineListId1",
                table: "MedicineLists",
                column: "MedicineListId1");

            migrationBuilder.CreateIndex(
                name: "IX_OutptPresccripts_AppoinmentId",
                table: "OutptPresccripts",
                column: "AppoinmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTests_InPtPrescriptionId",
                table: "PatientTests",
                column: "InPtPrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTests_TestlistId",
                table: "PatientTests",
                column: "TestlistId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_AdmissionId",
                table: "PaymentDetails",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PntMedicines_InPtPrescriptionId",
                table: "PntMedicines",
                column: "InPtPrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PntMedicines_MedicineListId",
                table: "PntMedicines",
                column: "MedicineListId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DepartmentId",
                table: "Rooms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorsId",
                table: "Schedules",
                column: "DoctorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "OutptPresccripts");

            migrationBuilder.DropTable(
                name: "PatientTests");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "PntMedicines");

            migrationBuilder.DropTable(
                name: "PtSymtomps");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Appoinments");

            migrationBuilder.DropTable(
                name: "Testlists");

            migrationBuilder.DropTable(
                name: "InPtPrescriptions");

            migrationBuilder.DropTable(
                name: "MedicineLists");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
