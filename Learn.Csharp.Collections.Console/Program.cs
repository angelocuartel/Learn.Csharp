using System.Numerics;

var dictionaries = new Dictionary<string, string>
{
    { "name", "John" },
    { "age", "30" },
    { "city", "New York" }
};


var tupples = new List<(string Key, string Value)>
{
    ("name", "John"),
    ("age", "30"),
    ("city", "New York")
};


var item = tupples[0].Key;


var nationInfo = (country: "country", pop: 12);


var result = Tuple.Create("country", "USA");



foreach (var (key, value) in tupples)
{
    Console.WriteLine($"{key}: {value}");
}