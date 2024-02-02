namespace _7IM_TechTest.Models
{
    public record Person
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Gender { get; set; }
    }
}