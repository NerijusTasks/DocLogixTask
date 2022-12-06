// See https://aka.ms/new-console-template for more information

var students = ProcessCSV("test.csv");

foreach (var item in students)
{
    Console.WriteLine(item.Id + ' ' + item.Name + ' ' + item.Surname);
}

static List<Student> ProcessCSV(string path)
{
    return File.ReadAllLines(path)
        .Skip(1)
        .Where(row => row.Length > 0)
        .Select(Student.ParseRow).ToList();
}



public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }




    internal static Student ParseRow(string row)
    {
        var columns = row.Split(',');

        //int limit = columns.Count();
        //if (columns[limit - 1] == " ")
        //{
        //     limit - 1;
        //}

        return new Student()
        {
            Id = columns[0],
            Name = columns[1],
            Surname = columns[2]
        };


    }
}



