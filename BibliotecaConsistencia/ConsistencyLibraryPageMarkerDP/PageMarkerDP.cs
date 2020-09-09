using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using InterfacesModuloConsistencia;
namespace ConsistencyLibraryPageMarkerDP
{
    public class PageMarkerDP : IPageMarker
    { 

        public List<List<string>> GetPageMarker(string nombrePDF)
        {
            string oldFile = nombrePDF;
            string newFile = "temporal.pdf";
            PdfReader reader = new PdfReader(oldFile);
            IList<Dictionary<String, Object>> bmProperties = SimpleBookmark.GetBookmark(reader);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(newFile, FileMode.Create));
            List<List<string>> marcadores_final = new List<List<string>>();
            if (bmProperties != null)
            {
                //listBox1.Items.Clear();
                //MessageBox.Show("Cantidad marcadores " + bmProperties.Count());
                List<string> aux_marcador = new List<string>();
               
                foreach (IDictionary<String, Object> bmProperty in bmProperties)
                {

                    aux_marcador.Clear();
                   // MessageBox.Show("pagina " + bmProperty["Page"] + " - Titulo " + bmProperty["Title"]);
                    var getPage = bmProperty["Page"];
                    var getTittle = bmProperty["Title"];

                    var aux_pagina = getPage.ToString().Split(' ');
                    var pagina = aux_pagina[0];
                    var titulo = getTittle;
                    aux_marcador.Add(pagina.ToString());
                    aux_marcador.Add(titulo.ToString());
                    marcadores_final.Add(aux_marcador);
                    //listBox1.Items.Add(titulo + "  Pag. " + pagina);

                    //}
                }
                stamp.Close();
                reader.Close();
            }


            return marcadores_final;

        }

        public string GetName()
        {
            string name = "PageMarkerDP";
            return name;
        }

        public string GetVersion()
        {
            string version = "1.0";
            return version;
        }
    }
}
