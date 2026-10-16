
namespace bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public string? ISBN { get; set; }
        public string? PublicationYear { get; set; }

        public string? Edition { get; set; }
        public string? PublicationLocation { get; set; }

        public string GetMlaCitation()
        {
            string author = $"{AuthorLastName}, {AuthorFirstName}";
            string citation = $"{author}. {Title}.";

            if (!string.IsNullOrWhiteSpace(Edition))
                citation += $" {Edition}.";

            citation += $" {Publisher}, {PublicationYear}.";

            return citation;
        }

        public string GetChicagoCitation()
        {
            string author = $"{AuthorLastName}, {AuthorFirstName}";
            string citation = $"{author}. {Title}.";

            if (!string.IsNullOrWhiteSpace(Edition))
                citation += $" {Edition}.";

            if (!string.IsNullOrWhiteSpace(PublicationLocation))
                citation += $" {PublicationLocation}:";

            citation += $" {Publisher}, {PublicationYear}.";

            return citation;
        }

        public string MlaCitation => GetMlaCitation();
        public string ChicagoCitation => GetChicagoCitation();
    }
}
