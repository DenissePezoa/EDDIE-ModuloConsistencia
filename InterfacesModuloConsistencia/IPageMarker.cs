using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesModuloConsistencia
{
    public interface IPageMarker
    {
        List<List<string>> GetPageMarker(string nombrePDF);
        string GetName(); 
        string GetVersion();
    }
}
