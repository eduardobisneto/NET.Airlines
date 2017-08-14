using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace NET.Airlines.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=AirlinesConnectionstring")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new Initializer());
            (this as IObjectContextAdapter).ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;
        }

        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<TravelFlight> TravelFlight { get; set; }
        public DbSet<Way> Way { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.HasDefaultSchema("AirlinesDatabase");

            modelBuilder.Configurations.Add(new Mapping.AirlineMap());
            modelBuilder.Configurations.Add(new Mapping.ContinentMap());
            modelBuilder.Configurations.Add(new Mapping.CountryMap());
            modelBuilder.Configurations.Add(new Mapping.CityMap());
            modelBuilder.Configurations.Add(new Mapping.AirportMap());
            modelBuilder.Configurations.Add(new Mapping.WayMap());
            modelBuilder.Configurations.Add(new Mapping.TravelMap());
            modelBuilder.Configurations.Add(new Mapping.FlightMap());
            modelBuilder.Configurations.Add(new Mapping.TravelFlightMap());
            modelBuilder.Configurations.Add(new Mapping.TicketMap());
            modelBuilder.Configurations.Add(new Mapping.CustomerMap());
            modelBuilder.Configurations.Add(new Mapping.OrderMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Initializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            List<Continent> continents = new List<Continent>()
            {
                new Continent() { Description = "South America" },
                new Continent() { Description = "North America" },
                new Continent() { Description = "Centre America" },
                new Continent() { Description = "Europe" },
                new Continent() { Description = "Asia" },
                new Continent() { Description = "African" },
                new Continent() { Description = "Ocean" }
            };

            List<Country> countries = new List<Country>()
            {
                new Country() { Description = "Brasil", Continent = continents[0] },
                new Country() { Description = "England", Continent = continents[3] },
                new Country() { Description = "France", Continent = continents[3] },
                new Country() { Description = "Holand", Continent = continents[3] },
                new Country() { Description = "Portugal", Continent = continents[3] },
                new Country() { Description = "German", Continent = continents[3] },
                new Country() { Description = "Nepal", Continent = continents[4] },
                new Country() { Description = "Belgium", Continent = continents[3] },
                new Country() { Description = "Switzerland", Continent = continents[3] }
            };

            List<City> cities = new List<City>()
            {
                new City() { Description = "São Paulo", Country = countries[0] },
                new City() { Description = "London", Country = countries[1] },
                new City() { Description = "Paris", Country = countries[2] },
                new City() { Description = "Amsterdam", Country = countries[3] },
                new City() { Description = "Porto", Country = countries[4] },
                new City() { Description = "Rio de Janeiro", Country = countries[0] },
                new City() { Description = "Bahia", Country = countries[0] },
                new City() { Description = "Bruxels", Country = countries[7] },
                new City() { Description = "Antwerp", Country = countries[7] },
                new City() { Description = "Zurich", Country = countries[8] },
                new City() { Description = "Lisboa", Country = countries[4] },
                new City() { Description = "Kathmandu", Country = countries[6] }
            };

            List<Airport> airports = new List<Airport>()
            {
                new Airport() { Description = "São Paulo (Congonhas)", City = cities[0] },
                new Airport() { Description = "São Paulo (Guarulhos)", City = cities[0] },
                new Airport() { Description = "London Airport", City = cities[1] },
                new Airport() { Description = "Paris Airport", City = cities[2] },
                new Airport() { Description = "Paris Second Airport", City = cities[2] },
                new Airport() { Description = "Amsterdam Airport", City = cities[3] },
                new Airport() { Description = "Porto Airport", City = cities[4] },
                new Airport() { Description = "Kathmandu Airport", City = cities[11] }
            };

            List<Airline> airlines = new List<Airline>()
            {
                new Airline() { Description = "British Airways" },
                new Airline() { Description = "American Airlines" },
                new Airline() { Description = "Emirates" },
                new Airline() { Description = "Air France" },
                new Airline() { Description = "Nepale Airlines" }
            };

            List<Way> ways = new List<Way>()
            {
                new Way(){ Description = "São Paulo - London", Airport = airports[0], AirportDestiny = airports[2] },
                new Way(){ Description = "London - São Paulo", Airport = airports[2], AirportDestiny = airports[1] },
                new Way(){ Description = "London - Paris", Airport = airports[2], AirportDestiny = airports[3] },
                new Way(){ Description = "São Paulo - Paris", Airport = airports[1], AirportDestiny = airports[3] },
                new Way(){ Description = "Paris - São Paulo", Airport = airports[4], AirportDestiny = airports[1] },
                new Way(){ Description = "Paris - London", Airport = airports[3], AirportDestiny = airports[2] },
                new Way(){ Description = "London - Kathmandu", Airport = airports[2], AirportDestiny = airports[7] }
            };

            List<Flight> flights = new List<Flight>()
            {
                new Flight() { Description = "São Paulo - London - manhã",
                    Arrival = new DateTime(2017, 08, 22, 11, 00, 00),
                    Boarding = new DateTime(2017, 08, 22, 03, 00, 00),
                    Airline = airlines[0],
                    Way = ways[0]
                },
                new Flight() {
                    Description = "London - São Paulo - noite",
                    Arrival = new DateTime(2017, 08, 23, 06, 00, 00),
                    Boarding = new DateTime(2017, 08, 22, 22, 00, 00),
                    Airline = airlines[1],
                    Way = ways[1]
                },
                new Flight() {
                    Description = "London - Paris - tarde",
                    Arrival = new DateTime(2017, 08, 22, 14, 00, 00),
                    Boarding = new DateTime(2017, 08, 22, 13, 00, 00),
                    Airline = airlines[3],
                    Way = ways[2]
                },
                new Flight() {
                    Description = "São Paulo - Paris - manhã",
                    Arrival = new DateTime(2017, 08, 22, 10, 00, 00),
                    Boarding = new DateTime(2017, 08, 22, 03, 00, 00),
                    Airline = airlines[3],
                    Way = ways[3]
                },
                new Flight() {
                    Description = "Paris - London - tarde",
                    Arrival = new DateTime(2017, 08, 22, 13, 30, 00),
                    Boarding = new DateTime(2017, 08, 22, 12, 30, 00),
                    Airline = airlines[3],
                    Way = ways[5]
                },
                new Flight() {
                    Description = "Paris - São Paulo",
                    Arrival = new DateTime(2017, 08, 23, 19, 30, 00),
                    Boarding = new DateTime(2017, 08, 23, 12, 30, 00),
                    Airline = airlines[3],
                    Way = ways[4]
                },
                new Flight() {
                    Description = "London - Paris - manhã",
                    Arrival = new DateTime(2017, 08, 23, 11, 30, 00),
                    Boarding = new DateTime(2017, 08, 23, 10, 30, 00),
                    Airline = airlines[0],
                    Way = ways[2]
                },
                new Flight() {
                    Description = "São Paulo - London",
                    Arrival = new DateTime(2017, 08, 22, 21, 30, 00),
                    Boarding = new DateTime(2017, 08, 22, 13, 30, 00),
                    Airline = airlines[2],
                    Way = ways[0]
                },
                new Flight() {
                    Description = "London - Kathmandu",
                    Arrival = new DateTime(2017, 08, 22, 17, 45, 00),
                    Boarding = new DateTime(2017, 08, 22, 13, 30, 00),
                    Airline = airlines[4],
                    Way = ways[6]
                }
            };

            List<Travel> travels = new List<Travel>()
            {
                new Travel(){
                    Way = ways[3], //São Paulo - Paris
                    Description = ways[3].Description,
                    Boarding = flights[0].Boarding,
                    Arrival = flights[2].Arrival
                },
                new Travel(){
                    Way = ways[0], //São Paulo - London
                    Description = ways[0].Description,
                    Boarding = flights[3].Boarding,
                    Arrival = flights[4].Arrival
                },
                new Travel(){
                    Way = ways[0], //São Paulo - London
                    Description = ways[0].Description,
                    Boarding = flights[0].Boarding,
                    Arrival = flights[0].Arrival
                },
                new Travel(){
                    Way = ways[3], //São Paulo - Paris
                    Description = ways[3].Description,
                    Boarding = flights[3].Boarding,
                    Arrival = flights[3].Arrival
                },
                new Travel(){
                    Way = ways[1], //London - São Paulo
                    Description = ways[1].Description,
                    Boarding = flights[6].Boarding,
                    Arrival = flights[5].Arrival
                },
                new Travel(){
                    Way = ways[6], //London - Kathmandu
                    Description = ways[6].Description,
                    Boarding = flights[8].Boarding,
                    Arrival = flights[8].Arrival
                }
            };

            List<TravelFlight> travelFlights = new List<TravelFlight>()
            {
                new TravelFlight(){
                    Flight = flights[0],
                    Travel = travels[0]
                },
                new TravelFlight(){
                    Flight = flights[2],
                    Travel = travels[0]
                },
                new TravelFlight(){
                    Flight = flights[3],
                    Travel = travels[1]
                },
                new TravelFlight(){
                    Flight = flights[4],
                    Travel = travels[1]
                },
                new TravelFlight(){
                    Flight = flights[0],
                    Travel = travels[2]
                },
                new TravelFlight(){
                    Flight = flights[3],
                    Travel = travels[3]
                },
                new TravelFlight(){
                    Flight = flights[5],
                    Travel = travels[4]
                },
                new TravelFlight(){
                    Flight = flights[6],
                    Travel = travels[4]
                },
                new TravelFlight(){
                    Flight = flights[8],
                    Travel = travels[5]
                }
            };

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    Travel = travels[1], //São Paulo - London
                    Description = string.Format("{0} - {1}",
                        travelFlights[2].Flight.Way.Airport.Description,
                        travelFlights[3].Flight.Way.AirportDestiny.Description),
                    Price = 1800
                }
                ,
                new Ticket()
                {
                    Travel = travels[4],
                    Description = string.Format("{0} - {1}",
                        travelFlights[7].Flight.Way.Airport.Description,
                        travelFlights[6].Flight.Way.AirportDestiny.Description),
                    Price = 1250
                },
                new Ticket()
                {
                    Travel = travels[5],
                    Description = string.Format("{0} - {1}",
                        travelFlights[8].Travel.Way.Airport.Description,
                        travelFlights[8].Travel.Way.AirportDestiny.Description),
                    Price = 2300
                }
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Marcelo de Assis Machado",
                    BornDate = DateTime.Now.AddYears(-24).AddHours(-2),
                    Country = countries[0]
                },
                new Customer()
                {
                    Name = "Pedro de Oliveira dos Santos",
                    BornDate = DateTime.Now.AddYears(-34).AddHours(-8),
                    Country = countries[0]
                },
                new Customer()
                {
                    Name = "William Aufhinrassaum Weish",
                    BornDate = DateTime.Now.AddYears(-44).AddHours(-3),
                    Country = countries[5]
                },
                new Customer()
                {
                    Name = "Ayyush Sakrain",
                    BornDate = DateTime.Now.AddYears(-25).AddHours(-7),
                    Country = countries[6]
                }
            };

            context.Country.AddRange(countries);
            context.City.AddRange(cities);
            context.Airline.AddRange(airlines);
            context.Airport.AddRange(airports);
            context.Flight.AddRange(flights);
            context.Customer.AddRange(customers);
            context.Way.AddRange(ways);
            context.Travel.AddRange(travels);
            context.TravelFlight.AddRange(travelFlights);
            context.Ticket.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
