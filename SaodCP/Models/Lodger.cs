namespace SaodCP.Models
{
    /// <summary>
    /// Постоялец
    /// </summary>
    public class Lodger
    {
        public static readonly string PassportIdPattern = "NNNN-NNNNNN";

        public int PassportId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int BirthYear { get; set; }

        public string Address { get; set; } = string.Empty;

        
    }
}
