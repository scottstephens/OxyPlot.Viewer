using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public partial class DockWindow : Form
    {
        public readonly Guid Id;
        private ContentIndex Index;

        public DockWindow(ContentIndex index)
        {
            InitializeComponent();
            this.Index = index;
            this.Id = Guid.NewGuid();
            this.DockPanel.Theme = new VS2015LightTheme();
            this.DockPanel.Theme.Extender.DockPaneStripFactory = new MovableContentDockPaneStripFactory(this.DockPanel.Theme.Extender.DockPaneStripFactory);
        }

        private void DockWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Guid)))
            {
                var content_id = (Guid)e.Data.GetData(typeof(Guid));
                if (this.Index.TryGet(content_id, out var content))
                {
                    content.DockPanel = null;
                    content.Show(this.DockPanel, DockState.Document);
                }
            }
        }

        private void DockWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Guid)))
            {
                var content_id = (Guid)e.Data.GetData(typeof(Guid));
                if (this.Index.TryGet(content_id, out var content))
                {
                    if (content.DockPanel != this.DockPanel)
                        e.Effect = DragDropEffects.Move;
                    else
                        e.Effect = DragDropEffects.None;
                }
            }
        }
    }
}
