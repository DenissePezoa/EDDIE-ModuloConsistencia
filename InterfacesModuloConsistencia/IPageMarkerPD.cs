using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
namespace InterfacesModuloConsistencia
{
    public interface IPageMarkerPD
    {
        int GetPageMarker(Mat _frame, string namePDF);

        int SavePageMarker(string namePDF);
        string GetName(); 
        string GetVersion();
    }
}
