﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Newtonsoft.Json.Linq;
namespace ModuloConsistenciaDatos
{
    public class ConsistenciaFigurasFD
    {

        public JObject buscarFiguras(Mat imagen, string nombrePDF)
        {
            //List<string> figurasObtenidas = new List<string>();
           
            string path = Directory.GetCurrentDirectory() + "\\PluginsConsistencia\\";
            
            string extensionsPath = path + "ConsistencyLibraryFiguresPD.dll";
            
            JObject figurasObtenidas= new JObject();
            var assembly = Assembly.LoadFile(extensionsPath);
            
            

            try
            {
                // load the assembly or type
                // foreach (var type in assembly.GetTypes())
                //{
               
                Type type = assembly.GetTypes()[0];
                    Console.WriteLine("tipossss555 " + type);
                    Console.WriteLine("Cargo correctamente el archivo de tipo " + type);
                    object obj = Activator.CreateInstance(type);
                    Console.WriteLine("cargo objeto  " + obj.ToString());
                    var result = type.GetMethod("ObtenerFiguras");
                    Console.WriteLine("cargo metodo "+ result.Name);
                    object[] parametros = new object[] {imagen, nombrePDF };
                    Console.WriteLine("parametrosss  "+parametros[0].ToString());
                    var respuesta = result.Invoke(obj, new object[] { imagen, nombrePDF });
                    figurasObtenidas = (JObject)respuesta;
                    return figurasObtenidas;
               // }
                
                
                
            }
            catch (Exception ex)
            {
               
                    
                
                if (ex is System.Reflection.ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                    foreach (var item in loaderExceptions)
                    {

                        Console.WriteLine("Error " +item.Message);
                    }
                }

                if (ex.InnerException != null)
                {
                    string err = ex.InnerException.Message;
                    Console.WriteLine("Error de carga de bibliotecas 1 " + err);
                }
                /* if (ex is System.Reflection.TargetInvocationException)
                 {
                     var exception = ex as TargetInvocationException;
                     var loaderExceptions = exception.Message;

                     Console.WriteLine("Error de carga de bibliotecas 2 " + loaderExceptions);

                 }*/
            }
            //
            return figurasObtenidas;

        }
    }
}
