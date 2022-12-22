using RandomMockUpTest.Data.Models;
using RandomPersonInfoGenerator.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMockUpTest.Data.Services
{
    public interface IPersonService
    {
        List<Person> CreateRandomPeopleByAmount(int amount);
    }

    public class PersonService : IPersonService
    {
        private readonly RandomInfoService service = new();

        //Returns a new random Person(Male) or Person(Female).
        public List<Person> CreateRandomPeopleByAmount(int amount)
        {
            int id = 0;
            List<Person> result = new();
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    string gender = service.GetRandomGender();
                    //The switch use the random gender-value to set the correct name and gender.ToLower() to the Person-object. 
                    switch (gender)
                    {
                        case "MALE":
                            {
                                result.Add(new Person
                                {
                                    Id = ++id,
                                    FirstName = service.GetRandomMaleFirstName(),
                                    LastName = service.GetRandomLastName(),
                                    Birthdate = service.GetRandomAge(),
                                    Gender = gender.ToLower()
                                });
                                break;
                            }
                        case "FEMALE":
                            {
                                result.Add(new Person
                                {
                                    Id = ++id,
                                    FirstName = service.GetRandomFemaleFirstName(),
                                    LastName = service.GetRandomLastName(),
                                    Birthdate = service.GetRandomAge(),
                                    Gender = gender.ToLower()
                                });
                                break;
                            }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Value can't be lower than 1.", nameof(amount));
            }

            return result;
        }
    }
}
