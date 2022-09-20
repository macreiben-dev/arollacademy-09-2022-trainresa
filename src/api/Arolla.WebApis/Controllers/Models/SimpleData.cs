namespace Arolla.WebApis.Controllers.Models
{
    public sealed class SimpleData
    {
        public int Id { get; set; }

        public string VeryImportantData { get; set; }

        public override string ToString()
        {
            return $"SimpleData: {Id} - {VeryImportantData}";
        }
    }
}
