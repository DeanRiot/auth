using Microsoft.EntityFrameworkCore.Migrations;

namespace notifier.EF.Migrations
{
    public partial class add_uuid_gen_path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_SMS",
                table: "SMS",
                column: "sms_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MAIL",
                table: "MAIL",
                column: "mail_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SMS",
                table: "SMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MAIL",
                table: "MAIL");
        }
    }
}
