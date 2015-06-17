/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/12/2013
 * Time: 2:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ASInsScan
{
	partial class ScanCard
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanCard));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reScanFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reScanBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reScanBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.dlgPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.lblMrn = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnGetMrn = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tmrToClear = new System.Windows.Forms.Timer(this.components);
            this.txtMrn = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imgVwrBack = new ASInsScan.ImageViewer();
            this.imgVwrFront = new ASInsScan.ImageViewer();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scanToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(419, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "&File...";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
            // 
            // printPreviewToolStripMenuItem1
            // 
            this.printPreviewToolStripMenuItem1.Name = "printPreviewToolStripMenuItem1";
            this.printPreviewToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem1.Text = "P&rint Preview";
            this.printPreviewToolStripMenuItem1.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reScanFrontToolStripMenuItem,
            this.reScanBackToolStripMenuItem,
            this.reScanBothToolStripMenuItem});
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.scanToolStripMenuItem.Text = "Re-&Scan";
            // 
            // reScanFrontToolStripMenuItem
            // 
            this.reScanFrontToolStripMenuItem.Name = "reScanFrontToolStripMenuItem";
            this.reScanFrontToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.reScanFrontToolStripMenuItem.Text = "&Front";
            this.reScanFrontToolStripMenuItem.Click += new System.EventHandler(this.ReScanFrontToolStripMenuItemClick);
            // 
            // reScanBackToolStripMenuItem
            // 
            this.reScanBackToolStripMenuItem.Name = "reScanBackToolStripMenuItem";
            this.reScanBackToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.reScanBackToolStripMenuItem.Text = "&Back";
            this.reScanBackToolStripMenuItem.Click += new System.EventHandler(this.ReScanBackToolStripMenuItemClick);
            // 
            // reScanBothToolStripMenuItem
            // 
            this.reScanBothToolStripMenuItem.Name = "reScanBothToolStripMenuItem";
            this.reScanBothToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.reScanBothToolStripMenuItem.Text = "B&oth";
            this.reScanBothToolStripMenuItem.Click += new System.EventHandler(this.ReScanBothToolStripMenuItemClick);
            // 
            // dlgPrint
            // 
            this.dlgPrint.UseEXDialog = true;
            // 
            // dlgPrintPreview
            // 
            this.dlgPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgPrintPreview.Enabled = true;
            this.dlgPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPrintPreview.Icon")));
            this.dlgPrintPreview.Name = "dlgPrintPreview";
            this.dlgPrintPreview.Visible = false;
            // 
            // lblMrn
            // 
            this.lblMrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMrn.Location = new System.Drawing.Point(12, 552);
            this.lblMrn.Name = "lblMrn";
            this.lblMrn.Size = new System.Drawing.Size(51, 23);
            this.lblMrn.TabIndex = 6;
            this.lblMrn.Text = "MRN#:";
            this.lblMrn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(39, 19);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send to Insurance";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // btnGetMrn
            // 
            this.btnGetMrn.Location = new System.Drawing.Point(156, 552);
            this.btnGetMrn.Name = "btnGetMrn";
            this.btnGetMrn.Size = new System.Drawing.Size(74, 23);
            this.btnGetMrn.TabIndex = 9;
            this.btnGetMrn.Text = "Get MRN#";
            this.btnGetMrn.UseVisualStyleBackColor = true;
            this.btnGetMrn.Click += new System.EventHandler(this.BtnGetMrnClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 27);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(113, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New Scan";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(307, 27);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear All Items";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // tmrToClear
            // 
            this.tmrToClear.Interval = 120000;
            this.tmrToClear.Tick += new System.EventHandler(this.TmrToClearTick);
            // 
            // txtMrn
            // 
            this.txtMrn.Location = new System.Drawing.Point(69, 554);
            this.txtMrn.MaxLength = 7;
            this.txtMrn.Name = "txtMrn";
            this.txtMrn.Size = new System.Drawing.Size(81, 20);
            this.txtMrn.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Location = new System.Drawing.Point(255, 536);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 49);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allscripts Chart";
            // 
            // imgVwrBack
            // 
            this.imgVwrBack.BackColor = System.Drawing.SystemColors.Control;
            this.imgVwrBack.Brightness = 50;
            this.imgVwrBack.EditableImage = null;
            this.imgVwrBack.Location = new System.Drawing.Point(12, 300);
            this.imgVwrBack.Name = "imgVwrBack";
            this.imgVwrBack.Size = new System.Drawing.Size(390, 230);
            this.imgVwrBack.TabIndex = 2;
            this.imgVwrBack.Title = "Back Image";
            // 
            // imgVwrFront
            // 
            this.imgVwrFront.BackColor = System.Drawing.SystemColors.Control;
            this.imgVwrFront.Brightness = 50;
            this.imgVwrFront.EditableImage = null;
            this.imgVwrFront.Location = new System.Drawing.Point(14, 64);
            this.imgVwrFront.Name = "imgVwrFront";
            this.imgVwrFront.Size = new System.Drawing.Size(390, 230);
            this.imgVwrFront.TabIndex = 0;
            this.imgVwrFront.Title = "Front Image";
            // 
            // ScanCard
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 597);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMrn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnGetMrn);
            this.Controls.Add(this.lblMrn);
            this.Controls.Add(this.imgVwrBack);
            this.Controls.Add(this.imgVwrFront);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 1000);
            this.MinimumSize = new System.Drawing.Size(435, 610);
            this.Name = "ScanCard";
            this.Text = "Insurance Card Scanner";
            this.Load += new System.EventHandler(this.ScanCardLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button btnGetMrn;
        private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label lblMrn;
		private System.Windows.Forms.PrintPreviewDialog dlgPrintPreview;
        private System.Windows.Forms.PrintDialog dlgPrint;
		private System.Windows.Forms.ToolStripMenuItem reScanBothToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reScanBackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reScanFrontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip;
		private ASInsScan.ImageViewer imgVwrBack;
        private ASInsScan.ImageViewer imgVwrFront;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer tmrToClear;
        private System.Windows.Forms.TextBox txtMrn;
        private System.Windows.Forms.GroupBox groupBox1;
	}
}
