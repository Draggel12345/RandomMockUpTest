using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMockUpTest.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email => SetEmail();
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; } = null!;

        private string SetEmail()
        {
            return $"{FirstName}.{LastName}@mail.com";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"=>Info  Nr.{Id}:");
            sb.AppendLine($"\tName: {FirstName} {LastName}.");
            sb.AppendLine($"\tEmail: {Email}.");
            sb.AppendLine($"\tBirthdate: {Birthdate.ToString("yyyy/dd/MM")}.");
            sb.AppendLine($"\tGender: {Gender}.");

            return sb.ToString();
        }
    }
}
