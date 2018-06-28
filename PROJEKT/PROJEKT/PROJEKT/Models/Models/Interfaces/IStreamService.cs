using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models.Interfaces
{
    public interface IStreamService
    {
        Stream GetStream(string path);
    }
}
