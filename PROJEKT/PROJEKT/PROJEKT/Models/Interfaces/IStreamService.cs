using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models.Interfaces
{
    /// <summary> 
    /// Intefejs do uzyskania stream ze ścieżki do zdjęcia.
    /// </summary> 
    public interface IStreamService
    {
        Stream GetStream(string path);
    }
}
