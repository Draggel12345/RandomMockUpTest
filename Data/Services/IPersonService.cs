using RandomMockUpTest.Data.Models;
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
}
