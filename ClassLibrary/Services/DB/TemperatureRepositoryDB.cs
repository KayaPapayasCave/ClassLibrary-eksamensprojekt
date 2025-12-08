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
    /// <summary>
    /// Repository class for Temperature class items
    /// </summary>
    public class TemperatureRepositoryDB : ITemperatureRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;

        /// <summary>
        /// Function to fetch all Temperature class items, asynchronous
        /// </summary>
        /// <returns>List of Temperature class items</returns>
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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }
            return result;
        }

        /// <summary>
        /// Function to fetch singular Temperature class items, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, possibility for null</returns>
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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                );
            }
            return temperature;
        }

        /// <summary>
        /// Function to fetch all Temperature class items, with same Raspberry-Id, asynchronous
        /// </summary>
        /// <param name="raspberryId">integer</param>
        /// <returns>List of Temperature class items</returns>
        public async Task<List<Temperature>> GetByRaspberryIdAsync(int raspberryId)
        {
            List<Temperature> result = new List<Temperature>();

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
                result.Add( new Temperature(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Decibel"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }

            return result;
        }

        /// <summary>
        /// Function to add singular Temperature class item, asynchronous
        /// </summary>
        /// <param name="temperature">Temperature class item</param>
        /// <returns>Temperature class item, possible null</returns>
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

        /// <summary>
        /// Function to delete singular Temperature class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, possibility for null</returns>
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
        /// <summary>
        /// Function to delete multiple Temperature class items, asynchronous
        /// </summary>
        /// <returns>integer, number of affected rows</returns>
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
