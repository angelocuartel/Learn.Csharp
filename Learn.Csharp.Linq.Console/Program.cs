
using Learn.Csharp.Linq.Console;

class Program
{
    static void Main(string[] args)
    {


    }

    static List<Person> GeneratePeople(int count)
    {
        var firstNames = new[] { "John", "Jane", "Alex", "Emily", "Chris", "Katie", "Mike", "Laura", "David", "Sara" };
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Martinez", "Lee" };
        var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
        var countries = new[] { "USA", "Canada", "UK", "Australia", "Germany" };
        var rnd = new Random();
        var people = new List<Person>();

        for (int i = 1; i <= count; i++)
        {
            var firstName = firstNames[rnd.Next(firstNames.Length)];
            var lastName = lastNames[rnd.Next(lastNames.Length)];
            var birthDate = DateTime.Now.AddYears(-rnd.Next(18, 65)).AddDays(-rnd.Next(0, 365));
            var email = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@example.com";
            var phone = $"+1-555-{rnd.Next(1000, 9999)}";
            var address = $"{rnd.Next(100, 999)} {lastName} St";
            var city = cities[rnd.Next(cities.Length)];
            var country = countries[rnd.Next(countries.Length)];
            var isActive = rnd.NextDouble() > 0.5;

            people.Add(new Person
            {
                Id = i,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email,
                Phone = phone,
                Address = address,
                City = city,
                Country = country,
                IsActive = isActive
            });
        }

        return people;
    }

    static void TestGroupByLinq(List<Person> people)
    {
        // Group by Country and calculate count and average age
        var groupedByCountry = people
            .GroupBy(p => p.Country)
            .Select(g => new
            {
                Country = g.Key,
                Count = g.Count(),
                AverageAge = g.Average(p => DateTime.Now.Year - p.BirthDate.Year),
                Names = g.Select(p => $"{p.FirstName} {p.LastName}").ToList()
            });

        foreach (var item in groupedByCountry)
        {
            foreach (var name in item.Names)
            {
                Console.WriteLine($"{item.Country}: {name}, Count: {item.Count}, Average Age: {item.AverageAge:F1}");
            }
        }
    }
}
