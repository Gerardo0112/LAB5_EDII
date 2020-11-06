using Microsoft.AspNetCore.Http;

namespace LAB5_EDII.Models
{
    public class NumbersDataTaken : Key<int>
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public int word { get; set; }
        public int levels { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
    }

    public class ValuesDataTaken : Key<string>
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string word { get; set; }
        public string levels { get; set; }
        public string rows { get; set; }
        public string columns { get; set; }
    }
}
