using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.Viewer.WinForms
{
    public class PlotContent : MovableDockContent
    {
        public PlotContent() : base(null) { }

        public PlotContent(ContentIndex index)
            : base(index)
        {

        }
    }
}
