using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SchoolBusManagement.Models
{
    public static class DataStorage
    {
        private static readonly string carsFile = "cars.json";
        private static readonly string driversFile = "drivers.json";
        private static readonly string studentsFile = "students.json";
        private static readonly string ridesFile = "rides.json";

        public static List<Car> LoadCars()
        {
            if (!File.Exists(carsFile)) return new List<Car>();
            var jsonData = File.ReadAllText(carsFile);
            return JsonConvert.DeserializeObject<List<Car>>(jsonData);
        }

        public static void SaveCars(List<Car> cars)
        {
            var jsonData = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText(carsFile, jsonData);
        }

        public static List<Driver> LoadDrivers()
        {
            if (!File.Exists(driversFile)) return new List<Driver>();
            var jsonData = File.ReadAllText(driversFile);
            return JsonConvert.DeserializeObject<List<Driver>>(jsonData);
        }

        public static void SaveDrivers(List<Driver> drivers)
        {
            var jsonData = JsonConvert.SerializeObject(drivers, Formatting.Indented);
            File.WriteAllText(driversFile, jsonData);
        }

        public static List<Student> LoadStudents()
        {
            if (!File.Exists(studentsFile)) return new List<Student>();
            var jsonData = File.ReadAllText(studentsFile);
            return JsonConvert.DeserializeObject<List<Student>>(jsonData);
        }

        public static void SaveStudents(List<Student> students)
        {
            var jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(studentsFile, jsonData);
        }

        public static List<Ride> LoadRides()
        {
            if (!File.Exists(ridesFile)) return new List<Ride>();
            var jsonData = File.ReadAllText(ridesFile);
            return JsonConvert.DeserializeObject<List<Ride>>(jsonData);
        }

        public static void SaveRides(List<Ride> rides)
        {
            var jsonData = JsonConvert.SerializeObject(rides, Formatting.Indented);
            File.WriteAllText(ridesFile, jsonData);
        }
    }
}
