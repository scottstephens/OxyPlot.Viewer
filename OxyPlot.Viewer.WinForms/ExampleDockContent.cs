using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public partial class ExampleDockContent : MovableDockContent
    {
        private static int Count = 0;

        
        public ExampleDockContent(ContentIndex index)
            : base(index)
        {
            InitializeComponent();
            var old = Interlocked.Increment(ref Count);
            this.label1.Text = $"{old}";
        }

        

        
    }
}
