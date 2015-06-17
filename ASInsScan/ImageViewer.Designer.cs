/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/12/2013
 * Time: 1:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ASInsScan
{
	partial class ImageViewer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.grpImageId = new System.Windows.Forms.GroupBox();
			this.nmbBright = new System.Windows.Forms.NumericUpDown();
			this.btnReset = new System.Windows.Forms.Button();
			this.lblBrightness = new System.Windows.Forms.Label();
			this.tbBright = new System.Windows.Forms.TrackBar();
			this.pictImage = new System.Windows.Forms.PictureBox();
			this.grpImageId.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmbBright)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbBright)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictImage)).BeginInit();
			this.SuspendLayout();
			// 
			// grpImageId
			// 
			this.grpImageId.Controls.Add(this.nmbBright);
			this.grpImageId.Controls.Add(this.btnReset);
			this.grpImageId.Controls.Add(this.lblBrightness);
			this.grpImageId.Controls.Add(this.tbBright);
			this.grpImageId.Controls.Add(this.pictImage);
			this.grpImageId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpImageId.Location = new System.Drawing.Point(0, 0);
			this.grpImageId.Name = "grpImageId";
			this.grpImageId.Size = new System.Drawing.Size(390, 230);
			this.grpImageId.TabIndex = 0;
			this.grpImageId.TabStop = false;
			this.grpImageId.Text = "[Image ID]";
			// 
			// nmbBright
			// 
			this.nmbBright.Location = new System.Drawing.Point(330, 172);
			this.nmbBright.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.nmbBright.Minimum = new decimal(new int[] {
									255,
									0,
									0,
									-2147483648});
			this.nmbBright.Name = "nmbBright";
			this.nmbBright.Size = new System.Drawing.Size(56, 20);
			this.nmbBright.TabIndex = 5;
			this.nmbBright.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nmbBright.Value = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.nmbBright.ValueChanged += new System.EventHandler(this.NmbBrightValueChanged);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(330, 198);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(56, 23);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = "Default";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnResetClick);
			// 
			// lblBrightness
			// 
			this.lblBrightness.Location = new System.Drawing.Point(330, 16);
			this.lblBrightness.Name = "lblBrightness";
			this.lblBrightness.Size = new System.Drawing.Size(56, 23);
			this.lblBrightness.TabIndex = 3;
			this.lblBrightness.Text = "Brightness";
			this.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbBright
			// 
			this.tbBright.Location = new System.Drawing.Point(330, 42);
			this.tbBright.Maximum = 255;
			this.tbBright.Minimum = -255;
			this.tbBright.Name = "tbBright";
			this.tbBright.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbBright.Size = new System.Drawing.Size(45, 124);
			this.tbBright.TabIndex = 1;
			this.tbBright.Value = 50;
			this.tbBright.ValueChanged += new System.EventHandler(this.TbBrightValueChanged);
			// 
			// pictImage
			// 
			this.pictImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pictImage.Location = new System.Drawing.Point(7, 20);
			this.pictImage.Name = "pictImage";
			this.pictImage.Size = new System.Drawing.Size(317, 201);
			this.pictImage.TabIndex = 0;
			this.pictImage.TabStop = false;
			// 
			// ImageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.grpImageId);
			this.Name = "ImageViewer";
			this.Size = new System.Drawing.Size(390, 230);
			this.grpImageId.ResumeLayout(false);
			this.grpImageId.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmbBright)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbBright)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictImage)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.NumericUpDown nmbBright;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.TrackBar tbBright;
		private System.Windows.Forms.Label lblBrightness;
		private System.Windows.Forms.PictureBox pictImage;
		private System.Windows.Forms.GroupBox grpImageId;
	}
}
