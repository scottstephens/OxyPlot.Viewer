using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public class MovableDockContent : DockContent
    {
        public Guid Id { get; private set; }
        private readonly ContentIndex Index;

        internal MovableDockContent() : base() { }

        public MovableDockContent(ContentIndex index) : base()
        {
            this.Index = index;
            this.Id = Guid.NewGuid();
            this.FormClosed += CustomDockContent_FormClosed;
            this.Index.Add(this);
        }

        private void CustomDockContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Index.Remove(this);
        }
    }
}
