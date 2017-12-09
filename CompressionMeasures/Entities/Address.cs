namespace CompressionMeasures
{
    public class Address
    {
        public Address()
        {
            StreetAddress = Faker.Address.StreetAddress();
            City = Faker.Address.City();
            Country = Faker.Address.Country();
        }

        public string StreetAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}