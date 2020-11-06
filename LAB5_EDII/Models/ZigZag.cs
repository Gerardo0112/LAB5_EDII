using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace LAB5_EDII.Models
{
    public class ZigZag
    {
        private static string routeDirectory = Environment.CurrentDirectory;

        //Cifrado Cesar.
        public static void Cipher(NumbersDataTaken info)
        {
            using (var reader = new BinaryReader(info.File.OpenReadStream()))
            {
                //Creacion archivo .zz.
                using (var streamWriter = new FileStream($"{info.Name}.zz", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(streamWriter))
                    {
                        var GrupoOlas = (2 * info.levels) - 2;
                        var len = (float)reader.BaseStream.Length / (float)GrupoOlas;
                        var cantOlas = len % 1 <= 0.5 ? Math.Round(len) + 1 : Math.Round(len);
                        cantOlas = Convert.ToInt32(cantOlas);

                        var pos = 0;
                        var contNivel = 0;

                        var mensaje = new List<byte>[info.levels];

                        for (int i = 0; i < info.levels; i++)
                        {
                            mensaje[i] = new List<byte>();
                        }

                        //Buffer de lectura
                        var bufferLength = 100000;
                        var byteBuffer = new byte[bufferLength];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            byteBuffer = reader.ReadBytes(bufferLength);
                            foreach (var caracter in byteBuffer)
                            {
                                if (pos == 0 || pos % GrupoOlas == 0)
                                {
                                    mensaje[0].Add(caracter);
                                    contNivel = 0;
                                }
                                else if (pos % GrupoOlas == info.levels - 1)
                                {
                                    mensaje[info.levels - 1].Add(caracter);
                                    contNivel = info.levels - 1;
                                }
                                else if (pos % GrupoOlas < info.levels - 1)
                                {
                                    contNivel++;
                                    mensaje[contNivel].Add(caracter);
                                }
                                else if (pos % GrupoOlas > info.levels - 1)
                                {
                                    contNivel--;
                                    mensaje[contNivel].Add(caracter);
                                }
                                pos++;
                            }
                        }

                        for (int i = 0; i < info.levels; i++)
                        {
                            var cantIteracion = i == 0 || i == info.levels - 1 ? cantOlas : cantOlas * 2;
                            var inicio = mensaje[i].Count();
                            for (int j = inicio; j < cantIteracion; j++)
                            {
                                mensaje[i].Add((byte)0);
                            }
                            writer.Write(mensaje[i].ToArray());
                        }
                    }
                }
            }
        }
    }
}
