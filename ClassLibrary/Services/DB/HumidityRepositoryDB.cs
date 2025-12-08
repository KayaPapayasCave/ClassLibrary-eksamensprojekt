using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    /// <summary>
    /// A repository class for managing Humidity data in a SQL database.
    /// </summary>
    public class HumidityRepositoryDB : IHumidityRepositoryDB
    {
        /// <summary>
        /// Represents the connection string used to establish a connection to the database.
        /// </summary>
        private readonly string _connectionString = Secret.ConnectionString;

        /// <summary>
        /// Initializes a new instance of the HumidityRepositoryDB class.
        /// </summary>
        public HumidityRepositoryDB()
        {
            _connectionString = Secret.ConnectionString;
        }

        /// <summary>
        /// Initializes a new instance of the HumidityRepositoryDB class with the specified database
        /// connection string.
        /// </summary>
        public HumidityRepositoryDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Asynchronously retrieves all humidity records from the database.
        /// <summary>

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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }

            return result;
        }

        /// <summary>
        /// Retrieves a Humidity object by its unique identifier.
        /// </summary>
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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                );
            }

            return humidity;
        }

        /// <summary>
        /// Asynchronously retrieves the most recent humidity record for the specified Raspberry Pi device in a list
        /// </summary>
        public async Task<List<Humidity>> GetByRaspberryIdAsync(int raspberryId)
        {
            List<Humidity> result = new List<Humidity>();

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
                result.Add( new Humidity(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("HumidityPercent"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }

            return result;
        }

        /// <summary>
        /// Asynchronously adds a new humidity record to the database and returns 
        /// the inserted record with its generated ID.
        /// </summary>
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

        /// <summary>
        /// Deletes the humidity record with the specified identifier from the database.
        /// </summary>
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

        /// <summary>
        /// Deletes records from the Humidity table that are older than 90 days.
        /// </summary>
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
