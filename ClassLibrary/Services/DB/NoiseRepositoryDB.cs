using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    /// <summary>
    /// Repository class for Noise class items
    /// </summary>
    public class NoiseRepositoryDB : INoiseRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;
        
        /// <summary>
        /// Function to fetch all Noise class items, asynchronous
        /// </summary>
        /// <returns>List of Noise class items</returns>
        public async Task<List<Noise>> GetAllAsync()
        {
            List<Noise> result = new List<Noise>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Decibel, Date, Time FROM Noise", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Noise(
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
        /// Function to fetch Noise class item, by specific Id, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, possibility for null</returns>
        public async Task<Noise?> GetByIdAsync(int id)
        {
            Noise? noise = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Decibel, Date, Time FROM Noise WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                noise = new Noise(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Decibel"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                );
            }
            return noise;
        }

        /// <summary>
        /// Function to fetch list of all Noise class items, with same Raspberry-Id, asynchronous
        /// </summary>
        /// <param name="raspberryId">integer</param>
        /// <returns>List of Noise class items</returns>
        public async Task<List<Noise>> GetByRaspberryIdAsync(int raspberryId)
        {
            List<Noise> result = new List<Noise>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT Id, RaspberryId, Decibel, Date, Time FROM Noise WHERE RaspberryId = @RaspberryId",
                connection
            );

            cmd.Parameters.AddWithValue("@RaspberryId", raspberryId);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                result.Add( new Noise(
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
        /// Function to add singular Noise class item, asynchronous
        /// </summary>
        /// <param name="noise">Noise class item</param>
        /// <returns>Noise class item, possibility for null</returns>
        public async Task<Noise?> AddNoiseAsync(Noise noise)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string sql = "INSERT INTO Noise (RaspberryId, Decibel, Date, Time) " +
                         "OUTPUT INSERTED.Id " +
                         "VALUES (@RaspberryId, @Decibel, @Date, @Time)";

            using SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@RaspberryId", noise.RaspberryId);
            cmd.Parameters.AddWithValue("@Decibel", noise.Decibel);
            cmd.Parameters.AddWithValue("@Date", noise.Date);
            cmd.Parameters.AddWithValue("@Time", noise.Time);

            await connection.OpenAsync();

            object? id = await cmd.ExecuteScalarAsync();

            if (id == null) return null;

            noise.Id = (int)id;
            return noise;
        }

        /// <summary>
        /// Function to delete singular Noise class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, possibility for null</returns>
        public async Task<Noise?> DeleteNoiseAsync(int id)
        {
            Noise? noise = await GetByIdAsync(id);
            if (noise == null) return null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("DELETE FROM Noise WHERE Id = @Id", connection);

            await connection.OpenAsync();

            cmd.Parameters.AddWithValue("@Id", id);

            int noOfRows = await cmd.ExecuteNonQueryAsync();
            Console.WriteLine($"Antal fjernede i tabellen {noOfRows}");

            if (noOfRows == 1) return noise;

            return null;
        }

        /// <summary>
        /// Function to delete multiple Noise class Items, asynchronous
        /// </summary>
        /// <returns>Integer, number of affected rows</returns>
        public async Task<int> DeleteOlderThan90DaysAsync()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string sql = @"DELETE FROM Noise 
                   WHERE Date < DATEADD(day, -90, CAST(GETDATE() AS date))";

            using SqlCommand cmd = new SqlCommand(sql, connection);

            await connection.OpenAsync();

            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected;
        }
    }
}
