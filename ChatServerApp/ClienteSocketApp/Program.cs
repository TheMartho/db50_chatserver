using ClienteSocketApp.Comunicación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ClienteSocket cliente = new ClienteSocket(ip, puerto);

            ClienteSocket clienteSocket = new ClienteSocket(ip, puerto);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conectandose al servidor {0} en el puerto {1}", ip, puerto);
            if (clienteSocket.Conectar())
            {
                //Comunicarme
                Console.WriteLine("Cliente Conectado");

                //Hacer el protocolo de comunicacion
                string mensaje = "";
                while (mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("Ingrese su mensaje");
                    mensaje = Console.ReadLine().Trim();
                    Console.WriteLine("C:{0}", mensaje);
                    cliente.Escribir(mensaje);
                    if (mensaje.ToLower() != "chao")
                    {
                        mensaje = cliente.Leer();
                        Console.WriteLine("S{0}", mensaje);
                    }
                }
                cliente.Desconectar();
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error de Conexion");
            }
        }
    }
}
