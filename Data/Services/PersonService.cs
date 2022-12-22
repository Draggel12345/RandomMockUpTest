using RandomMockUpTest.Data.Models;
using RandomPersonInfoGenerator.Data.Services;

namespace RandomMockUpTest.Data.Services
{
    public class PersonService : IPersonService
    {
        private readonly RandomInfoService service = new();

        /// <summary>
        /// <Author>Mike Polen</Author>
        /// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <DateTime name="today"></DateTime>
        /// <returns name="age"></returns>
        private static int DateOfBirthConvertedToAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        //Returns a new random Person(Male) or Person(Female).
        public List<Person> CreateRandomPeopleByAmount(int amount)
        {
            int id = 0;
            List<Person> result = new();
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    DateTime dateOfBirth = service.GetRandomDateOfBirth();
                    string gender = service.GetRandomGender();
                    //The switch use the random gender-value to set the correct name and gender.ToLower() to the Person-object. 
                    switch (gender)
                    {
                        case "Male":
                            {
                                result.Add(new Person
                                {
                                    Id = ++id,
                                    FirstName = service.GetRandomMaleFirstName(),
                                    LastName = service.GetRandomLastName(),
                                    Age = DateOfBirthConvertedToAge(dateOfBirth),
                                    DateOfBirth = dateOfBirth,
                                    Gender = gender
                                });
                                break;
                            }
                        case "Female":
                            {
                                result.Add(new Person
                                {
                                    Id = ++id,
                                    FirstName = service.GetRandomFemaleFirstName(),
                                    LastName = service.GetRandomLastName(),
                                    Age = DateOfBirthConvertedToAge(dateOfBirth),
                                    DateOfBirth = dateOfBirth,
                                    Gender = gender
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
