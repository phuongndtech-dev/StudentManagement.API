using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Infrastructure.Persistence.migrations
{
    public partial class SP_UpdateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                CREATE PROC sp_UpdateStudent
			                    @id uniqueidentifier,
			                    @name nvarchar(500),
			                    @year date,
			                    @address nvarchar(500),
			                    @email nvarchar(500)
                                AS
                                BEGIN
	                                UPDATE Student set Name = @name,
					                                   Year = @year,
					                                   Address = @address,
					                                   Email = @email
	                                WHERE Id = @id
                                END
                                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
