using MongoDB.Driver.Core.Configuration;
using SurveyFormProject.Models;
using System.Data;
using System.Data.SqlClient;

namespace SurveyFormProject.Repositories
{
    public class RepositoryAdo : IRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _conString;

        public RepositoryAdo(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _conString = _configuration["ConnectionStrings:DockerConnectionString"];
        }

        public void AddResponse(GuestResponseDto response)
        {
            // Create a SqlConnection
            using (SqlConnection connection = new SqlConnection(_conString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand for the INSERT statement
                string insertQuery = "INSERT INTO GuestResponses (Name, Email, Phone, WillAttend ) VALUES (@Value1, @Value2, @Value3, @Value4)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Define parameters and their values
                    command.Parameters.AddWithValue("@Value1", response.Name);
                    command.Parameters.AddWithValue("@Value2", response.Email);
                    command.Parameters.AddWithValue("@Value3", response.Phone);
                    command.Parameters.AddWithValue("@Value4", response.WillAttend);

                    // Execute the INSERT statement
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully!");
                    }
                    else
                    {
                        throw new Exception($"Response email: {response.Email}, could not insert data.");
                    }
                }
            }
        }

        public IEnumerable<GuestResponseDto> GetResponsesWillAttend()
        {
            string sql = "SELECT * FROM GuestResponses WHERE WillAttend LIKE 1";

            var result = new List<GuestResponseDto>();

            using (SqlConnection con = new SqlConnection(_conString))
            {
                //open the connection
                con.Open();

                //pass command and connectionnobject to send it to the server
                SqlCommand cmd = new SqlCommand(sql, con);

                //abstraction to serve to us

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temp = new GuestResponseDto();

                        temp.Id = int.Parse(reader[0].ToString());
                        temp.Name = reader[1].ToString();
                        temp.Email = reader[2].ToString();
                        temp.Phone = reader[3].ToString();
                        temp.WillAttend = bool.Parse(reader[4].ToString());

                        result.Add(temp);
                    }
                }
            }

            return result;
        }
    }
}
