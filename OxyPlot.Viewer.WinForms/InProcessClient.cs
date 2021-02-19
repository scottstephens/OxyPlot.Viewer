using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OxyPlot.Viewer.WinForms
{
    public class InProcessClient : IDisposable
    {
        public Thread GuiThread { get; private set; }
        private ContentIndex ContentIndex;
        private Control _main_form;
        private Dictionary<Guid, DockWindow> OpenWindows = new Dictionary<Guid, DockWindow>();

        public InProcessClient()
        {
            this.GuiThread = null;
            this.ContentIndex = new ContentIndex();
        }


        protected void Run()
        {
            _main_form = new Control();

            // This seems to force the control to actually get a handle,
            // which then makes _main_form.InvokeRequired and _main_form.Invoke()
            // use the thread running this method as the GUI thread, which is 
            // the desired behavior in this case.
            System.IntPtr a = _main_form.Handle;

            Application.Run();
        }

        public void Start()
        {
            this.GuiThread = new Thread(Run);
            this.GuiThread.Name = "GuiThread";
            this.GuiThread.SetApartmentState(ApartmentState.STA);
            this.GuiThread.Start();
            while (_main_form == null)
                Thread.Sleep(20);
        }

        public void Stop()
        {
            if (_main_form.InvokeRequired)
            {
                _main_form.Invoke(new Action(this.Stop));
            }
            else
            {
                _main_form.Dispose();
                Application.ExitThread();
                this.GuiThread = null;
                _main_form = null;
            }
        }

        #region IDisposable implementation
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    this.Stop();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~InProcessClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion


        public DockWindow ActiveWindow { get; private set; }
        public PlotPane ActivePane { get; private set; }

        public void NewWindow()
        {
            if (_main_form.InvokeRequired)
            {
                _main_form.BeginInvoke(new Action(this.NewWindow));
            }
            else
            {
                var dw = this.createWindow();
                this.ActiveWindow = dw;
                this.ActivePane = null;
            }
        }

        public void NewPane()
        {
            if (_main_form.InvokeRequired)
            {
                _main_form.BeginInvoke(new Action(this.NewPane));
            }
            else
            {
                var np = new PlotPane(this.ContentIndex);
                var aw = this.getOrCreateActiveWindow();
                np.Show(aw.DockPanel, DockState.Document);
                this.ActivePane = np;
            }
        }

        public void Plot(PlotModel plotModel)
        {
            if (_main_form.InvokeRequired)
            {
                _main_form.BeginInvoke(new Action<PlotModel>(this.Plot), plotModel);
            }
            else
            {
                var ap = this.getOrCreateActivePane();
                ap.PlotModel = plotModel;
            }
        }

        private DockWindow createWindow()
        {
            var nw = new DockWindow(this.ContentIndex);
            this.OpenWindows.Add(nw.Id, nw);
            nw.FormClosed += OnDockWindow_FormClosed;
            nw.Show();
            return nw;
        }

        private void OnDockWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            var tsender = (DockWindow)sender;
            this.OpenWindows.Remove(tsender.Id);
        }

        private DockWindow getOrCreateActiveWindow()
        {
            if (this.ActiveWindow == null)
                this.ActiveWindow = this.createWindow();
            return this.ActiveWindow;
        }

        private PlotPane createPane()
        {
            var aw = this.getOrCreateActiveWindow();
            var np = new PlotPane(this.ContentIndex);
            np.Show(aw.DockPanel, DockState.Document);
            return np;
        }

        private PlotPane getOrCreateActivePane()
        {
            if (this.ActivePane == null)
                this.ActivePane = this.createPane();
            return this.ActivePane;
        }
        
    }
}
