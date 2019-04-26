using System;
using SQLite;

namespace WeatherApp.Models
{
    public class SavedLocation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Zip { get; set; }
        public string Name { get; set; }

    }
}
