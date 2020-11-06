using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;
using LAB5_EDII.Models;


namespace LAB5_EDII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class apiController : ControllerBase
    {
        //Metodo cifrados.
        [HttpPost, Route("cipher/{method}")]
        public async Task<FileStreamResult> cifrar(string method, [FromForm] ValuesDataTaken data)
        {

            switch (method)
            {
                case "zigzag":
                    ZigZag.Cipher(new NumbersDataTaken { File = data.File, Name = data.Name, levels = Convert.ToInt32(data.levels) });
                    break;
                case "cesar":
                    Cesar.Cipher(data);
                    break;
                case "route":
                    Route.Cipher(new NumbersDataTaken { File = data.File, Name = data.Name, rows = Convert.ToInt32(data.rows), columns = Convert.ToInt32(data.columns) });
                    break;
                default:
                    break;
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream($"{data.Name}.txt", FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            //Retorno del contenido del archivo en Postman.
            return File(memory, MediaTypeNames.Application.Octet, $"{ data.Name}.txt");

        }

        //Metodo decifrados.
        [HttpPost, Route("decipher/{method}")]
        public async Task<FileStreamResult> decifrar(string method, [FromForm] ValuesDataTaken data)
        {

            switch (method)
            {
                case "zigzag":
                    ZigZag.Decipher(new NumbersDataTaken { File = data.File, levels = Convert.ToInt32(data.levels) });
                    break;
                case "cesar":
                    Cesar.Decipher(data);
                    break;
                case "route":
                    Route.Decipher(new NumbersDataTaken { File = data.File, Name = data.Name, rows = Convert.ToInt32(data.rows), columns = Convert.ToInt32(data.columns) });
                    break;
                default:
                    break;
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream($"{ data.Name}.txt", FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            //Retorno del contenido del archivo en Postman.
            return File(memory, MediaTypeNames.Application.Octet, $"{ data.Name}.txt");
        }
    }
}
