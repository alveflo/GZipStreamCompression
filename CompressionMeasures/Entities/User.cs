using System.Collections.Generic;

namespace CompressionMeasures
{
    public class User
    {
        public User()
        {
            FirstName = Faker.Name.First();
            LastName = Faker.Name.Last();
            Age = Faker.RandomNumber.Next();
            Company = new Company();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
    }
}
