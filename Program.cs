using RandomMockUpTest.Data.Models;
using RandomMockUpTest.Data.Services;

PersonService service = new();

List<Person> people = service.CreateRandomPeopleByAmount(15);

people.ForEach(p => Console.WriteLine(p));