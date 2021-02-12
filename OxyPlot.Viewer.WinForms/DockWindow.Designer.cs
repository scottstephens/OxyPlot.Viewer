
namespace OxyPlot.Viewer.WinForms
{
    partial class DockWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.SuspendLayout();
            // 
            // DockPanel
            // 
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(0, 0);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(800, 450);
            this.DockPanel.TabIndex = 0;
            // 
            // DockWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DockPanel);
            this.IsMdiContainer = true;
            this.Name = "DockWindow";
            this.Text = "DockWindow";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DockWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DockWindow_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        internal WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel;
    }
}