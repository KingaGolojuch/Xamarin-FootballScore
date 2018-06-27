using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.ViewModels
{
    public class InitializationViewModel
    {
        public void SizeChanged(double width, double height)
        {
            (Application.Current as App).Width = width;
            (Application.Current as App).Height = height;
        }
    }
}
