namespace CsSombreroPlot
{

    /// <summary>
    /// This is a quick-n-dirty conversion of the Sombrero Plot on a KIM1 as written by Dave Plummer.
    /// His code can be found in his video at https://www.youtube.com/shorts/WC5-TeTWsCA.
    /// </summary>
    public partial class SombreroPlot : Form
    {
        private readonly Color _backColor = Color.Black;
        private readonly Pen _backColorPen = Pens.Black;
        private readonly Pen _plotColorPen = Pens.Yellow;

        // Create a Bitmap as a class-level object because it going to be our "screen"
        // and must exist at all times. Windows can tell this window to repaint itself
        // at any time, including after the PlotSombrero function has completed its
        // work.
        private Bitmap? _plotBitmap;

        // Setup a thread-safe say to set show the image.
        private delegate void SetPlotImageDelegate(Bitmap bitmap);
        private readonly SetPlotImageDelegate SetPlotImageCall;

        public SombreroPlot()
        {
            InitializeComponent();

            SetPlotImageCall = new SetPlotImageDelegate(SetPlotImage);
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            await PlotSombrero();
            StartButton.Enabled = true;
        }

        private Task PlotSombrero()
        {
            return Task.Factory.StartNew(() =>
            {
                // If the plot bitmap already exists, kill it so we can
                // create a new one without leaking resources.
                _plotBitmap?.Dispose();

                // I'm using 320x200 here because I don't know what the
                // KIM1 machine supports.
                _plotBitmap = new Bitmap(320, 200);

                // Start drawing the sombrero!
                using Graphics g = Graphics.FromImage(_plotBitmap);
                g.Clear(_backColor);

                float xp = 144;
                float xr = 4.71238905F;
                float xf = xr / xp;

                for (float zi = -64.0F; zi <= 64; zi++)
                {
                    float zt = zi * 2.25F;
                    float zs = zt * zt;
                    float xl = (int)(Math.Sqrt(20736 - zs) + 0.5F);
                    for (float xi = 0 - xl; xi <= xl; xi++)
                    {
                        float xt = (float)Math.Sqrt(xi * xi + zs) * xf;
                        float yy = (float)((Math.Sin(xt) + Math.Sin(xt * 3) * 0.4) * 56);
                        float a = xi + zi + 160.0F;
                        float b = 90.0F - yy + zi;

                        float x1 = a, y1 = b;
                        float x2 = x1, y2 = 191;
                        g.DrawLine(_plotColorPen, x1, y1, x2, y2);

                        y1 = b + 1.0F;
                        g.DrawLine(_backColorPen, x1, y1, x2, y2);

                        // If you want to see the code draw every point in the graph, 
                        // uncomment this line and comment out the one below.
                        // SetPlotImage(_plotBitmap);
                    }

                    // Though the KIM1 code plots every single pixel/line on screen as
                    // the points are calculated, and we can do this in the C# code too,
                    // it slows the plot code down greatly. Showing the plot bitmap here
                    // shows the current state of the "screen" after each line of the graph
                    // has been drawn to the bitmap.
                    SetPlotImage(_plotBitmap);
                }
            });
        }

        /// <summary>
        /// Shows the current plot bitmap in a thread-safe manner.
        /// </summary>
        private void SetPlotImage(Bitmap bitmap)
        {
            if (PlotPictureBox.InvokeRequired)
            {
                PlotPictureBox.Invoke(SetPlotImageCall, new object[] { bitmap });
            }
            else
            {
                PlotPictureBox.Image = bitmap;
            }
        }
    }
}