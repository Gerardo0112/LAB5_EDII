using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using LAB5_EDII.Models;

namespace NUEVO_CIFRADO
{
    class Program
    {
        static void Main(string[] args)
        {
            ValuesDataTaken data;
            string method = "";

            Console.WriteLine("Escriba la ruta del archivo: ", data.File);
            Console.ReadLine();

            Console.WriteLine("Escriba nombre del nuevo archivo ", data.Name);
            Console.ReadLine();

            Console.WriteLine("Escriba la ruta del metodo a utilizar: ", method);
            Console.ReadLine();

            //Eleccion de cifrado.
            switch(method)
            {
                case "cipher/cesar":
                    Console.WriteLine("Escriba la clave: ", data.word);
                    Console.ReadLine();

                    Cesar.Cipher(data);
                    break;
                case "cipher/zigzag":
                    Console.WriteLine("Escriba la cantidad de olas: ", data.levels);
                    Console.ReadLine();

                    ZigZag.Cipher(new NumbersDataTaken { File = data.File, Name = data.Name, levels = Convert.ToInt32(data.levels) });
                    break;
                case "cipher/route":
                    Console.WriteLine("Escriba la cantidad de olas: ", data.rows);
                    Console.ReadLine();

                    Console.WriteLine("Escriba la cantidad de olas: ", data.columns);
                    Console.ReadLine();

                    Route.Cipher(new NumbersDataTaken { File = data.File, Name = data.Name, rows = Convert.ToInt32(data.rows), columns = Convert.ToInt32(data.columns) });
                    break;
                case "decipher/cesar":
                    Console.WriteLine("Escriba la clave: ", data.word);
                    Console.ReadLine();

                    Cesar.Decipher(data);
                    break;
                case "decipher/zigzag":
                    Console.WriteLine("Escriba la cantidad de olas: ", data.levels);
                    Console.ReadLine();

                    ZigZag.Decipher(new NumbersDataTaken { File = data.File, Name = data.Name, levels = Convert.ToInt32(data.levels) });
                    break;
                case "decipher/route":
                    Console.WriteLine("Escriba la cantidad de olas: ", data.rows);
                    Console.ReadLine();

                    Console.WriteLine("Escriba la cantidad de olas: ", data.columns);
                    Console.ReadLine();

                    Route.Decipher(new NumbersDataTaken { File = data.File, Name = data.Name, rows = Convert.ToInt32(data.rows), columns = Convert.ToInt32(data.columns) });
                    break;
            }
        }
    }
}
