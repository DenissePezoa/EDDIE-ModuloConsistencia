using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesModuloConsistencia
{
    public interface IComments
    {
        string GetName();
        string GetVersion();

        List<List<string>> GetComments(string namePDF);


    }
}
