using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    /// <summary>
    /// A repository class for managing Light data in a SQL database.
    /// </summary>
    public class LightRepositoryDB : ILightRepositoryDB
    {
        /// <summary>
        /// Represents the connection string used to establish a connection to the database.    
        /// </summary>
        private readonly string _connectionString = Secret.ConnectionString;

        /// <summary>
        /// Asynchronously retrieves all light sensor data from the database.
        /// </summary>
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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves a Light object by its unique identifier.
        /// </summary>
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
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                );
            }

            return light;
        }

        /// <summary>
        /// Asynchronously retrieves the most recent Light object for a given RaspberryId in a list.
        /// </summary>
        public async Task<List<Light>> GetByRaspberryIdAsync(int raspberryId)
        {
            List<Light> result = new List<Light>();


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
                result.Add( new Light(
                    reader.GetInt32("Id"),
                    reader.GetInt32("RaspberryId"),
                    (double)reader.GetDecimal("Lumen"),
                    DateOnly.FromDateTime(reader.GetDateTime("Date")),
                    TimeOnly.FromTimeSpan((TimeSpan)reader["Time"])
                ));
            }

            return result;
        }

        /// <summary>
        /// Asynchronously adds a new light measurement to the database and returns the added light object with its
        /// generated identifier.
        /// </summary>
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
            light.Id = (int)id;
            return light;
        }

        /// <summary>
        /// Deletes the light with the specified identifier from the database.
        /// </summary>
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

        /// <summary>
        /// Deletes records from the "Light" table that are older than 90 days.
        /// </summary>
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
