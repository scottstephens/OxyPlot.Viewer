
namespace OxyPlot.Viewer.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewDockWindow = new System.Windows.Forms.Button();
            this.btnNewDockContent = new System.Windows.Forms.Button();
            this.btnNewDockFloat = new System.Windows.Forms.Button();
            this.btnNewContentToLastContent = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewDockWindow
            // 
            this.btnNewDockWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDockWindow.Location = new System.Drawing.Point(13, 13);
            this.btnNewDockWindow.Name = "btnNewDockWindow";
            this.btnNewDockWindow.Size = new System.Drawing.Size(349, 23);
            this.btnNewDockWindow.TabIndex = 0;
            this.btnNewDockWindow.Text = "New DockWindow";
            this.btnNewDockWindow.UseVisualStyleBackColor = true;
            this.btnNewDockWindow.Click += new System.EventHandler(this.btnNewDockWindow_Click);
            // 
            // btnNewDockContent
            // 
            this.btnNewDockContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDockContent.Location = new System.Drawing.Point(13, 42);
            this.btnNewDockContent.Name = "btnNewDockContent";
            this.btnNewDockContent.Size = new System.Drawing.Size(350, 23);
            this.btnNewDockContent.TabIndex = 1;
            this.btnNewDockContent.Text = "New Dock Content to Last Window";
            this.btnNewDockContent.UseVisualStyleBackColor = true;
            this.btnNewDockContent.Click += new System.EventHandler(this.btnNewDockContentToLastWindow_Click);
            // 
            // btnNewDockFloat
            // 
            this.btnNewDockFloat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDockFloat.Location = new System.Drawing.Point(12, 100);
            this.btnNewDockFloat.Name = "btnNewDockFloat";
            this.btnNewDockFloat.Size = new System.Drawing.Size(350, 23);
            this.btnNewDockFloat.TabIndex = 2;
            this.btnNewDockFloat.Text = "New Dock Float";
            this.btnNewDockFloat.UseVisualStyleBackColor = true;
            this.btnNewDockFloat.Click += new System.EventHandler(this.btnNewDockFloat_Click);
            // 
            // btnNewContentToLastContent
            // 
            this.btnNewContentToLastContent.Location = new System.Drawing.Point(13, 71);
            this.btnNewContentToLastContent.Name = "btnNewContentToLastContent";
            this.btnNewContentToLastContent.Size = new System.Drawing.Size(350, 23);
            this.btnNewContentToLastContent.TabIndex = 3;
            this.btnNewContentToLastContent.Text = "New Content to Last Content";
            this.btnNewContentToLastContent.UseVisualStyleBackColor = true;
            this.btnNewContentToLastContent.Click += new System.EventHandler(this.btnNewContentToLastContent_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(13, 130);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(349, 23);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 271);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnNewContentToLastContent);
            this.Controls.Add(this.btnNewDockFloat);
            this.Controls.Add(this.btnNewDockContent);
            this.Controls.Add(this.btnNewDockWindow);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewDockWindow;
        private System.Windows.Forms.Button btnNewDockContent;
        private System.Windows.Forms.Button btnNewDockFloat;
        private System.Windows.Forms.Button btnNewContentToLastContent;
        private System.Windows.Forms.Button btnMove;
    }
}

