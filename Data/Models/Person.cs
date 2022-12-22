using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMockUpTest.Data.Models
{
    public class Person
    {
        private readonly Random rnd = new();

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email => SetEmail();
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;

        private string SetEmail()
        {
            string[] mailServices = "hotmail, gmail, aol, yahoo, yandex, outlook".Split(", ");
            string[] mailDotEnd = ".com, .se, .dk, .us, .fi".Split(", ");

            return $"{FirstName}.{LastName}@{mailServices[rnd.Next(0, mailServices.Length)]}{mailDotEnd[rnd.Next(0, mailDotEnd.Length)]}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"==Info=>Nr.{Id}");
            sb.AppendLine($"\tName: {FirstName} {LastName}");
            sb.AppendLine($"\tE-mail: {(Age > 12 ? Email : "no email.")}");
            sb.AppendLine($"\tAge: {Age}{(Age > 1 ? " years" : " year")} old");
            sb.AppendLine($"\tBirthdate: {DateOfBirth.ToString("yyyy/dd/MM")}");
            sb.AppendLine($"\tGender: {Gender}");

            return sb.ToString();
        }
    }
}
