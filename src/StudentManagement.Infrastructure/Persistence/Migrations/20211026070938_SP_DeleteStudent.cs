using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Infrastructure.Persistence.migrations
{
    public partial class SP_DeleteStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE PROC sp_DeleteStudent
			                                    @id uniqueidentifier
                                    AS
                                    BEGIN
	                                    DELETE Student
	                                    WHERE Id = @id
                                    END
                                    GO
                                 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
