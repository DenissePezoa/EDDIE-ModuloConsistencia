﻿using System;
using System.Collections.Generic;
using System.Text;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Newtonsoft.Json.Linq;

namespace InterfacesModuloConsistencia
{
    public interface IFiguras
    {
        JObject ObtenerFiguras(Mat imagen, string nombrePDF);

        void GuardarFiguras(string nombrePDF);
        string GetName();
        string GetVersion();
    }
}
