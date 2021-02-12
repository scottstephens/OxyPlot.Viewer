using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public partial class MainForm : Form
    {
        private Dictionary<Guid, DockWindow> OpenWindows = new Dictionary<Guid, DockWindow>();
        private DockWindow LastWindow;
        private DockContent LastDockContent;
        private ContentIndex Index;

        public MainForm()
        {
            InitializeComponent();
            this.Index = new ContentIndex();
        }

        private void btnNewDockWindow_Click(object sender, EventArgs e)
        {
            var d = new DockWindow(this.Index);
            this.OpenWindows.Add(d.Id, d);
            this.LastWindow = d;
            d.Show();
        }

        private void btnNewDockContentToLastWindow_Click(object sender, EventArgs e)
        {
            var c = new ExampleDockContent(this.Index);
            c.Show(this.LastWindow.DockPanel, DockState.Document);
            this.LastDockContent = c;
        }

        private void btnNewContentToLastContent_Click(object sender, EventArgs e)
        {
            var c = new ExampleDockContent(this.Index);
            //c.Show(this.LastDockContent.DockPanel, DockState.Document);
            c.Show(this.LastDockContent.Pane, null);
            this.LastDockContent = c;
            
        }

        private void btnNewDockFloat_Click(object sender, EventArgs e)
        {
            var c = new ExampleDockContent(this.Index);
            this.LastDockContent = c;
            c.Show();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            var source = this.LastDockContent;
            DockPanel target = null;
            foreach (var window in this.OpenWindows.Values)
            {
                if (window.DockPanel != source.DockPanel)
                {
                    target = window.DockPanel;
                    break;
                }
            }
            source.DockPanel = null;
            source.Show(target, DockState.Document);
        }
    }
}
