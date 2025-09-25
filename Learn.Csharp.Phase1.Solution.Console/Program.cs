using Learn.Csharp.Phase1.Solution.Console;



var fetcher = new PublicApiFetcher();

// Fetch posts and users in parallel
var postsTask = fetcher.GetAsync<Post>("posts");
var usersTask = fetcher.GetAsync<User>("users");

await Task.WhenAll(postsTask, usersTask);

var posts = postsTask.Result;
var users = usersTask.Result;

// Group posts by UserId
var postsByUser = posts.GroupBy(p => p.UserId)
                       .ToDictionary(g => g.Key, g => g.ToList());

var test = posts.GroupBy(x => x.UserId);

var firstPost = postsByUser;


foreach (var item in firstPost)
{
    Console.WriteLine(item.Key);
}

// Print summary with user names
foreach (var kvp in postsByUser)
{
    var userId = kvp.Key;
    var user = users.FirstOrDefault(u => u.Id == userId);

    Console.WriteLine($"{user?.Name ?? "Unknown User"} has {kvp.Value.Count} posts.");
    Console.WriteLine($"First post title: {kvp.Value.First().Title}");
    Console.WriteLine("----");
}


