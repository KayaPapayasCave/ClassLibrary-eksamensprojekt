using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    public class LightRepositoryDB : ILightRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;

        public async Task<List<Light>> GetAllAsync()
        {
            List<Light> result = new List<Light>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Lumen, Date, Time FROM Light", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Light(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Lumen"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                ));
            }

            return result;
        }

        public async Task<Light?> GetByIdAsync(int id)
        {
            Light? light = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT Id, RaspberryId, Lumen, Date, Time FROM Light WHERE Id = @Id",
                connection
            );

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                light = new Light(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Lumen"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }

            return light;
        }

        public async Task<Light?> GetByRaspberryIdAsync(int raspberryId)
        {
            Light? light = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Id, RaspberryId, Lumen, Date, Time FROM Light WHERE RaspberryId = @RaspberryId ORDER BY Date DESC, Time DESC",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", raspberryId);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                light = new Light(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Lumen"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }

            return light;
        }

        public async Task<Light?> AddLightAsync(Light light)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "INSERT INTO Light (RaspberryId, Lumen, Date, Time) OUTPUT INSERTED.Id VALUES (@RaspberryId, @Lumen, @Date, @Time)",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", light.RaspberryId);
            cmd.Parameters.AddWithValue("@Lumen", light.Lumen);
            cmd.Parameters.AddWithValue("@Date", light.Date);
            cmd.Parameters.AddWithValue("@Time", light.Time);

            await connection.OpenAsync();

            object? id = await cmd.ExecuteScalarAsync();
            if (id == null) return null;

            return light;
        }

        public async Task<Light?> DeleteLightAsync(int id)
        {
            Light? light = await GetByIdAsync(id);
            if (light == null) return null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("DELETE FROM Light WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected == 1) return light;

            return null;
        }

        public async Task<int> DeleteOlderThan90DaysAsync()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string sql = @"DELETE FROM Light 
                           WHERE Date < DATEADD(day, -90, CAST(GETDATE() AS date))";

            using SqlCommand cmd = new SqlCommand(sql, connection);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected;
        }
    }
}
