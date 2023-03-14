using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

// As I understand Azure pricing the minimum cost is about five hundred dollars per month?
// Thats a bit much for a thermometer experiment.
// TODO: research DB pricing options.
// https://azure.microsoft.com/en-us/pricing/details/azure-sql-database/single/#pricing

namespace Roman_Numeral_Thermometer
{
    public class Database
    {
        public OutdoorTemperature? OutdoorTemperature { get; set; }
        public Database(OutdoorTemperature temperature) {
            OutdoorTemperature = temperature;
        }

        /// <summary>
        /// Stores OutdoorTemperature object into Azure database
        /// </summary>
        public void insert()
        {
            try
            {
                // TODO: Need to figure out how in VS to include secrets, securely
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "<your_server>.database.windows.net";
                builder.UserID = "<your_username>";
                builder.Password = "<your_password>";
                builder.InitialCatalog = "<your_database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    // This is probably the MSSQL equivalent of mysql's
                    // "CREATE TABLE IF NOT EXISTS"
                    String table =
                        @"IF OBJECT_ID(N'dbo.Observations', N'U') IS NULL
                            BEGIN
                                CREATE TABLE dbo.Observations (
                                    Celsius numeric(5,2) not null,
                                    Fahrenheit numeric(5,1) not null,
                                    Roman varchar(64) not null,
                                    ObservationTime datetime DEFAULT(getdate())
                                );
                            END;";
                    using (SqlCommand command = new SqlCommand(table, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    string insertText = @"INSERT INTO dbo.Observations
                                        (Celsius, Fahrenheit, Roman, ObservationTime)
                                        values(@celsius, @fahrenheit, @roman, DEFAULT)";

                    using (SqlCommand command = new SqlCommand(insertText, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@celsius", OutdoorTemperature!.Celsius);
                        command.Parameters.AddWithValue("@fahrenheit", OutdoorTemperature.Fahrenheit);
                        command.Parameters.AddWithValue("@roman", OutdoorTemperature.Roman());
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("SQL Insert complete");
            return;
        }

    }
}