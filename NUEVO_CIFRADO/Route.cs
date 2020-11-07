using System;
using System.Linq;
using System.IO;

namespace LAB5_EDII.Models
{
    public class Route
    {
        private static string routeDirectory = Environment.CurrentDirectory;

        //Cifrado Ruta Espiral.
        public static void Cipher(NumbersDataTaken info)
        {
            using (var reader = new BinaryReader(info.File.OpenReadStream()))
            {
                //Creacion archivo .rt.
                using (var streamWriter = new FileStream($"{info.Name}.rt", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(streamWriter))
                    {
                        //Buffer de lectura.
                        var bufferLength = info.rows * info.columns;
                        var byteBuffer = new byte[bufferLength];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            var Matriz = new byte[info.rows, info.columns];
                            byteBuffer = reader.ReadBytes(bufferLength);

                            var numVueltas = 0;
                            var posX = 0;
                            var posY = 0;
                            var Direccion = "abajo";

                            foreach (var caracter in byteBuffer)
                            {
                                if (Direccion == "abajo" && posY != info.rows - 1 - numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posY++;
                                }
                                else if (Direccion == "abajo" && posY == info.rows - 1 - numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posX++;
                                    Direccion = "derecha";
                                }
                                else if (Direccion == "derecha" && posX != info.columns - 1 - numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posX++;
                                }
                                else if (Direccion == "derecha" && posX == info.columns - 1 - numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posY--;
                                    Direccion = "arriba";
                                }
                                else if (Direccion == "arriba" && posY != numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posY--;
                                }
                                else if (Direccion == "arriba" && posY == numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    numVueltas++;
                                    posX--;
                                    Direccion = "izquierda";
                                }
                                else if (Direccion == "izquierda" && posX != numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posX--;
                                }
                                else if (Direccion == "izquierda" && posX == numVueltas)
                                {
                                    Matriz[posY, posX] = caracter;
                                    posY++;
                                    Direccion = "abajo";
                                }
                            }

                            for (int i = 0; i < info.rows; i++)
                            {
                                for (int j = 0; j < info.columns; j++)
                                {
                                    writer.Write(Matriz[i, j]);
                                }
                            }
                        }
                    }
                }
            }
        }

        //Decifrado Ruta Espiral
        public static void Decipher(NumbersDataTaken info)
        {
            using (var reader = new BinaryReader(info.File.OpenReadStream()))
            {
                //Creacion archivo .txt.
                using (var streamWriter = new FileStream($"{info.Name}.txt", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(streamWriter))
                    {
                        //Buffer de lectura.
                        var bufferLength = info.rows * info.columns;
                        var byteBuffer = new byte[bufferLength];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            var Matriz = new byte[info.rows, info.columns];
                            byteBuffer = reader.ReadBytes(bufferLength);
                            var cont = 0;

                            for (int i = 0; i < info.rows; i++)
                            {
                                for (int j = 0; j < info.columns; j++)
                                {
                                    if (cont < byteBuffer.Count())
                                    {
                                        Matriz[i, j] = byteBuffer[cont];
                                        cont++;
                                    }
                                    else
                                    {
                                        Matriz[i, j] = (byte)0;
                                    }
                                }
                            }

                            var numVueltas = 0;
                            var posX = 0;
                            var posY = 0;
                            var Direccion = "abajo";

                            for (int i = 0; i < bufferLength; i++)
                            {
                                if (Matriz[posY, posX] != 0)
                                {
                                    if (Direccion == "abajo" && posY != info.rows - 1 - numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posY++;
                                    }
                                    else if (Direccion == "abajo" && posY == info.rows - 1 - numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posX++;
                                        Direccion = "derecha";
                                    }
                                    else if (Direccion == "derecha" && posX != info.columns - 1 - numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posX++;
                                    }
                                    else if (Direccion == "derecha" && posX == info.columns - 1 - numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posY--;
                                        Direccion = "arriba";
                                    }
                                    else if (Direccion == "arriba" && posY != numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posY--;
                                    }
                                    else if (Direccion == "arriba" && posY == numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        numVueltas++;
                                        posX--;
                                        Direccion = "izquierda";
                                    }
                                    else if (Direccion == "izquierda" && posX != numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posX--;
                                    }
                                    else if (Direccion == "izquierda" && posX == numVueltas)
                                    {
                                        writer.Write(Matriz[posY, posX]);
                                        posY++;
                                        Direccion = "abajo";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
