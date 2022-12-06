using Newtonsoft.Json;

string patch = @"..\..\..\data.csv";

string[] data = File.ReadAllLines(patch);

string[] headerLine = data[0].Split(',');

Console.WriteLine("Please insert column name");

string columnName = Console.ReadLine();
string searchText = "";

if (headerLine.Contains(columnName))
{
    Console.WriteLine("Please insert searching text");

    searchText = Console.ReadLine();

    if (searchText == "")
    {
        Console.WriteLine("Please insert text!");
        return;
    }
}
else
{
    Console.WriteLine("Bad column name");
    return;
}

int columnIndex = Array.IndexOf(headerLine, columnName);

var searchQuery =
    from line in data
    let elements = line.Split(',')
    let columnCount = elements.Count()
    where columnCount > columnIndex
    where elements[columnIndex].Contains(searchText)
    select line;

var filteredLines = searchQuery.ToList();

var foundedResults = filteredLines.Select(
    (x) =>
        x.Split(',')
            .Where((y, i) => y.Count() > i)
            .Select((y, i) => new { Key = headerLine[i], Value = y })
            .ToDictionary(d => d.Key, d => d.Value)
);

var jsonData = JsonConvert.SerializeObject(foundedResults, Formatting.Indented);

string filePath = @"..\..\..\FoundedData.json";

File.WriteAllText(filePath, jsonData);

Console.WriteLine("Data writed into FoundedData.json file");
