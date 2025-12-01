using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.Services.DB
{
    public class NoiseRepositoryDB : INoiseRepositoryDB
    {
        private readonly string _connectionString = Secret.ConnectionString;

        public async Task<List<Noise>> GetAllAsync()
        {
            List<Noise> result = new List<Noise>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Decibel, Time FROM Noise", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Noise
                { 
                    Id = reader.GetInt32("Id"),
                    RaspberryId = reader.GetInt32("RaspberryId"),
                    Decibel = (double)reader.GetDecimal("Decibel"),
                    Time = reader.GetDateTime("Time")
                });
            }

            return result;
        }

        public async Task<Noise?> GetByIdAsync(int id)
        {
            Noise? noise = null;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SELECT Id, RaspberryId, Decibel, Time FROM Noise WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                noise = new Noise
                {
                    Id = reader.GetInt32("Id"),
                    RaspberryId = reader.GetInt32("RaspberryId"),
                    Decibel = (double)reader.GetDecimal("Decibel"),
                    Time = reader.GetDateTime("Time")
                };
            }

            return noise;
        }

        public async Task<Noise?> GetByRaspberryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Noise?> AddNoiseAsync(Noise noise)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("INSERT INTO Noise (RaspberryId, Decibel, Time) OUTPUT INSERTED.Id VALUES (@RaspberryId, @Decibel, @Time)", connection);

            await connection.OpenAsync();

            cmd.Parameters.AddWithValue("@RaspberryId", noise.RaspberryId);
            cmd.Parameters.AddWithValue("@Decibel", noise.Decibel);
            cmd.Parameters.AddWithValue("@Time", noise.Time);

            object? id = await cmd.ExecuteScalarAsync(); // Tries to retrieve the id the new board got from the database.

            if (id == null) return null;

            return noise;
        }

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
    }
}
