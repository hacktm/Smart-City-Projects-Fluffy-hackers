namespace ConvertVectorIntoImage
{
    partial class InvPanel
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
            this.panelToDraw = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelToDraw
            // 
            this.panelToDraw.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelToDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToDraw.Location = new System.Drawing.Point(0, 0);
            this.panelToDraw.Name = "panelToDraw";
            this.panelToDraw.Size = new System.Drawing.Size(757, 415);
            this.panelToDraw.TabIndex = 0;
            // 
            // InvPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 415);
            this.Controls.Add(this.panelToDraw);
            this.Name = "InvPanel";
            this.Text = "InvPanel";
            this.Load += new System.EventHandler(this.InvPanelLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToDraw;

    }
}