using Registration.Models;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Dapper;



namespace Registration.Service
{
    public class Registerservice : IRegisterService
    {
        private readonly string _connectionstring;
        public Registerservice(IConfiguration connectionstring)
        {
            _connectionstring = connectionstring.GetConnectionString("DefaultConnection");
        }


        public async Task<List<Reg>> GetallAsync()
        {
            using var connection = new SqlConnection(_connectionstring);
            var result = await connection.QueryAsync<Reg>(
                "sp_GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task InsertDepartmentasyn(Reg model)
        {
            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(
                "sp_Insert",
                new
                {
                    model.Name,
                    model.Qualification,
                    model.Age,
                    model.Mobile ,
                    model.Email,
                    .
                },
                commandType: CommandType.StoredProcedure);

        }

        public async Task<Reg> GetDepartmentID(int deptID)
        {
            using var connection = new SqlConnection(_connectionstring);
            var result = await connection.QueryFirstOrDefaultAsync<Reg>(
                "sp_GetId",
                new
                {
                    DeptID = deptID
                },
                commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task UpdateDepartmentasyn(Reg model)
        {
            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(
                "sp_Update",
                new
                {
                    model.Id,
                    model.Name,
                    model.Qualification,
                    model.Age,
                    model.Mobile,
                    model.Email
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task DeleteDepartment(int Id)
        {
            using var connection = new SqlConnection(_connectionstring);
            var result = await connection.QueryFirstOrDefaultAsync<Reg>(
                "sp_Delete",
                new
                {
                    Id= Id
                },
                commandType: CommandType.StoredProcedure);

        }
    }
}
