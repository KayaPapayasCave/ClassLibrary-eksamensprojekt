using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    public class HumidityRepositoryDB : IHumidityRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;

        public async Task<List<Humidity>> GetAllAsync()
        {
            List<Humidity> result = new List<Humidity>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, HumidityPercent, Date, Time FROM Humidity", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Humidity(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("HumidityPercent"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                ));
            }

            return result;
        }

        public async Task<Humidity?> GetByIdAsync(int id)
        {
            Humidity? humidity = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT Id, RaspberryId, HumidityPercent, Date, Time FROM Humidity WHERE Id = @Id",
                connection
            );

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                humidity = new Humidity(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("HumidityPercent"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }

            return humidity;
        }

        public async Task<Humidity?> GetByRaspberryIdAsync(int raspberryId)
        {
            Humidity? humidity = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Id, RaspberryId, HumidityPercent, Date, Time FROM Humidity WHERE RaspberryId = @RaspberryId ORDER BY Date DESC, Time DESC",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", raspberryId);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                humidity = new Humidity(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("HumidityPercent"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }

            return humidity;
        }

        public async Task<Humidity?> AddHumidityAsync(Humidity humidity)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "INSERT INTO Humidity (RaspberryId, HumidityPercent, Date, Time) OUTPUT INSERTED.Id VALUES (@RaspberryId, @HumidityPercent, @Date, @Time)",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", humidity.RaspberryId);
            cmd.Parameters.AddWithValue("@HumidityPercent", humidity.HumidityPercent);
            cmd.Parameters.AddWithValue("@Date", humidity.Date);
            cmd.Parameters.AddWithValue("@Time", humidity.Time);

            await connection.OpenAsync();

            object? id = await cmd.ExecuteScalarAsync();
            if (id == null) return null;

            humidity.Id = (int)id;
            return humidity;
        }

        public async Task<Humidity?> DeleteHumidityAsync(int id)
        {
            Humidity? humidity = await GetByIdAsync(id);
            if (humidity == null) return null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("DELETE FROM Humidity WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected == 1) return humidity;

            return null;
        }

        public async Task<int> DeleteOlderThan90DaysAsync()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string sql = @"DELETE FROM Humidity 
                           WHERE Date < DATEADD(day, -90, CAST(GETDATE() AS date))";

            using SqlCommand cmd = new SqlCommand(sql, connection);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected;
        }
    }
}
