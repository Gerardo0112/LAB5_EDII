using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_EDII.Models
{
    public interface Key<T>
    {
        IFormFile File { get; set; }
        string Name { get; set; }
        T word { get; set; }
        T levels { get; set; }
        T rows { get; set; }
        T columns { get; set; }
    }
}
