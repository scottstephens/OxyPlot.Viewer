using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace OxyPlot.Viewer.WinForms
{
    public class MovableContentDockPaneStripFactory : IDockPaneStripFactory
    {
        private IDockPaneStripFactory Inner;

        public MovableContentDockPaneStripFactory(IDockPaneStripFactory inner)
        {
            this.Inner = inner;
        }

        public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
        {
            var output = this.Inner.CreateDockPaneStrip(pane);
            output.MouseDown += Output_MouseDown;
            return output;
        }

        private void Output_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tsender = (DockPaneStripBase)sender;
                var content = DockPaneStripHelper.GetContent(tsender, e.Location);
                var tcontent = content as MovableDockContent;
                tsender.DoDragDrop(tcontent.Id, DragDropEffects.Move);
            }
        }
    }
}
