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
        /// <remarks>This field is read-only and initialized with a value from a secure source. It is
        /// intended for internal use only and should not be exposed publicly.</remarks>
        private readonly string _connectionString = Secret.ConnectionString;

        /// <summary>
        /// Asynchronously retrieves all light sensor data from the database.
        /// </summary>
        /// <remarks>This method executes a SQL query to fetch all records from the "Light" table. It returns a list
        /// with all light sensor data, each represented as a Light object.
        /// The method returns an empty list if no records are found.</remarks>
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
        /// <remarks>This method queries the database for a light record with the specified identifier. 
        /// If no matching record is found, the method returns a null value.</remarks>
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
        /// Asynchronously retrieves the most recent Light object for a given RaspberryId.
        /// </summary>
        /// <returns> The method queries the database for the most recent light record associated with
        /// the given Raspberry Pi device, ordered by date and time in descending order. If no record exists for the
        /// specified RaspberryId, the method returns a null value.</returns>
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
        /// <remarks>This method inserts a new record into the "Light" table in the database. The light parameter must include valid values
        /// for the Light.RaspberryId,Light.Lumen, Light.Date, and Light.Time properties.
        /// If the value is invalid it returns a null value </remarks>
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
        /// <remarks>This method retrieves the light by its identifier before attempting to delete it. If
        /// the light does not exist, the method returns null without performing any deletion. If the
        /// deletion is successful, the method returns the deleted light object.</remarks>
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
        /// <remarks>This method removes all rows where the "Date" column is earlier than 90 days from the
        /// current date. The operation is performed asynchronously and returns the number of rows deleted.</remarks>
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
