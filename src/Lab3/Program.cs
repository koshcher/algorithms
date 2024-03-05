Console.WriteLine("Enter a string in which we will search (long one):");
var source = Console.ReadLine();

Console.WriteLine("Enter a string we need to search in previous string (short one)");
var search = Console.ReadLine();

if (source == null || search == null)
{
    Console.WriteLine("Input is invalid. Goodbye");
    return;
}

var indexOfSearch = source.IndexOf(search);
if (indexOfSearch < 0)
{
    Console.WriteLine($"{search} was not found");
}
else
{
    Console.WriteLine($"{search} was found at index: {indexOfSearch}");
}