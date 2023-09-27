﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Console.WriteLine("List init");
List<string> strings = new List<string>();
for (int i = 0; i < 100; i++)
{
    strings.Add(i.ToString());
}

var results = new List<int>();


Console.WriteLine("Task creation");
List<Task> Tasks = new List<Task>();
foreach (var s in strings)
{
    Tasks.Add(Task.Run(() => DoSomething(s, results)));
}

Console.WriteLine("Task starting");

await Task.WhenAll(Tasks);

Console.WriteLine("Task Done");

foreach (var r in results)
{
    Console.WriteLine(r);
}

Console.WriteLine($"Results Done: {results.Count}");


async Task DoSomething(string s, List<int> results)
{
    //Console.WriteLine(s);
    if (int.TryParse(s, out int delay))
    {
        await Task.Delay(delay * 10);
        results.Add(delay);
        await Task.Delay(delay * 10);
    }
    //Console.WriteLine(s);
}
