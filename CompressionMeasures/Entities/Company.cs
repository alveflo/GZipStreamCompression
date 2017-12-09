namespace CompressionMeasures
{
    public class Company
    {
        public Company()
        {
            Name = Faker.Company.Name();
            Address = new Address();
        }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}