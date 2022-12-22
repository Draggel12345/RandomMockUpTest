using RandomMockUpTest.Data.Models;
using RandomMockUpTest.Data.Services;

PersonService service = new();

int amount = 2;

List<Person> people = service.CreateRandomPeopleByAmount(amount);

Console.WriteLine($"\tLIST OF {amount}{(amount > 1 ? " PEOPLE" : " PERSON")}");
Console.WriteLine("(Random name, age, email and gender)\n");
people.ForEach(p => Console.WriteLine(p));