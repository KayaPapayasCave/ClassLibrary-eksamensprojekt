using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Eksempel: Hent alle temperaturmålinger
        public List<Temperature> GetAllTemperatures()
        {
            var temperatures = new List<Temperature>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Temperature";
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temperatures.Add(new Temperature
                        {
                            Id = reader.GetInt32("Id"),
                            RaspberryId = reader.GetInt32("RaspberryId"),
                            Celsius = reader.GetDouble("Celsius"),
                            //MeasuredTime = reader.GetTimeSpan("MeasuredTime"),
                            //MeasuredDate = reader.GetDateTime("MeasuredDate")
                        });
                    }
                }
            }

            return temperatures;
        }

        public List<Humidity> GetAllHumidity()
        {
            var humidities = new List<Humidity>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Humidity";
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        humidities.Add(new Humidity
                        {
                            Id = reader.GetInt32("Id"),
                            RaspberryId = reader.GetInt32("RaspberryId"),
                            HumidityPercent = reader.GetDouble("HumidityPercent"),
                            //MeasuredTime = reader.GetTimeSpan("MeasuredTime"),
                            //MeasuredDate = reader.GetDateTime("MeasuredDate")
                        });
                    }
                }
            }

            return humidities;
        }

        public List<Noise> GetAllNoise()
        {
            var noises = new List<Noise>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Noise";
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        noises.Add(new Noise
                        {
                            Id = reader.GetInt32("Id"),
                            RaspberryId = reader.GetInt32("RaspberryId"),
                            Decibel = reader.GetDouble("Decibel"),
                            //MeasuredTime = reader.GetTimeSpan("MeasuredTime"),
                            //MeasuredDate = reader.GetDateTime("MeasuredDate")
                        });
                    }
                }
            }

            return noises;
        }

        public List<Noise> GetAllLight()
        {
            var lights = new List<Light>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Light";
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lights.Add(new Light
                        {
                            Id = reader.GetInt32("Id"),
                            RaspberryId = reader.GetInt32("RaspberryId"),
                            Lumen = reader.GetDouble("Lumen"),
                            //MeasuredTime = reader.GetTimeSpan("MeasuredTime"),
                            //MeasuredDate = reader.GetDateTime("MeasuredDate")
                        });
                    }
                }
            }

            return lights;
        }
    }
}
