namespace CsSombreroPlot
{
    partial class SombreroPlot
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
            PlotPictureBox = new PictureBox();
            StartButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PlotPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PlotPictureBox
            // 
            PlotPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlotPictureBox.BackColor = SystemColors.ActiveBorder;
            PlotPictureBox.Location = new Point(12, 52);
            PlotPictureBox.Name = "PlotPictureBox";
            PlotPictureBox.Size = new Size(1198, 941);
            PlotPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PlotPictureBox.TabIndex = 0;
            PlotPictureBox.TabStop = false;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(12, 12);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(160, 34);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 1005);
            Controls.Add(StartButton);
            Controls.Add(PlotPictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PlotPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PlotPictureBox;
        private Button StartButton;
    }
}