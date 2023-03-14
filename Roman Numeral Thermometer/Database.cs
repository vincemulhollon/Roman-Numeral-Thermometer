using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TODO: install the NuGet package
// using Microsoft.Data.SqlClient;

// As I understand Azure pricing the minimum cost is about five hundred dollars per month?
// TODO: research DB pricing options...
// https://azure.microsoft.com/en-us/pricing/details/azure-sql-database/single/#pricing

namespace Roman_Numeral_Thermometer
{
    public class Database
    {
        public OutdoorTemperature? OutdoorTemperature { get; set; }
        public Database(OutdoorTemperature temperature) {
            OutdoorTemperature = temperature;
        }

        public void insert()
        {
            // TODO Upload the outdoor temperature into an Azure database

            Console.WriteLine("SQL Insert complete");
            return;
        }

    }
}
