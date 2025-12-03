using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DB
{
    public class TemperatureRepositoryDB : ITemperatureRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;
        public async Task<List<Temperature>> GetAllAsync()
        {
            List<Temperature> result = new List<Temperature>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Celsius, Date, Time FROM Temperature", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Temperature(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Decibel"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                ));
            }
            return result;
        }

        public async Task<Temperature?> GetByIdAsync(int id)
        {
            Temperature? temperature = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Celsius, Date, Time FROM Noise WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                temperature = new Temperature(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Decibel"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }
            return temperature;
        }

        public async Task<Temperature?> GetByRaspberryIdAsync(int raspberryId)
        {
            Temperature? temperature = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT Id, RaspberryId, Celcius, Date, Time FROM Temperature WHERE RaspberryId = @RaspberryId",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", raspberryId);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                temperature = new Temperature(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Decibel"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromDateTime(reader.GetDateTime("Time"))
                );
            }

            return temperature;
        }

        public async Task<Temperature?> AddTemperatureAsync(Temperature temperature)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("INSERT INTO Temperature (RaspberryId, Decibel, Date, Time) OUTPUT INSERTED.Id VALUES (@RaspberryId, @Decibel, @Date, @Time)", connection);

            await connection.OpenAsync();

            cmd.Parameters.AddWithValue("@RaspberryId", temperature.RaspberryId);
            cmd.Parameters.AddWithValue("@Decibel", temperature.Celsius);
            cmd.Parameters.AddWithValue("@Date", temperature.Date);
            cmd.Parameters.AddWithValue("@Time", temperature.Time);

            object? id = await cmd.ExecuteScalarAsync();

            if (id == null) return null;

            return temperature;
        }

        public async Task<Temperature?> DeleteTemperatureAsync(int id)
        {
            Temperature? temperature = await GetByIdAsync(id);
            if (temperature == null) return null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("DELETE FROM Temperature WHERE Id = @Id", connection);

            await connection.OpenAsync();

            cmd.Parameters.AddWithValue("@Id", id);

            int noOfRows = await cmd.ExecuteNonQueryAsync();
            Console.WriteLine($"Antal fjernede i tabellen {noOfRows}");

            if (noOfRows == 1) return temperature;

            return null;
        }
        public async Task<int> DeleteOlderThan90DaysAsync()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string sql = @"DELETE FROM Temperature 
                   WHERE Date < DATEADD(day, -90, CAST(GETDATE() AS date))";

            using SqlCommand cmd = new SqlCommand(sql, connection);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected;
        }
    }
}
