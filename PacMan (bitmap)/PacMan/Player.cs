using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Player
    {
        public Graphics g;
        public Bitmap PacmanBitmap;
        public Form1 form;
        public Board board;
        //public PictureBox PacmanImage = new PictureBox();
        private ImageList PacmanImages = new ImageList();
        public Timer timer = new Timer();
        public int pX;
        public int pY;
		public int checkX;
		public int checkY;
        public int currentDirection = 1;
        private int imageOn = 0;
        
        public Player(){
            
        }
        public Player(int x, int y, ImageList imglist, Board board, Form1 form){
            this.form = form;
            this.board = board;
            pX = x * 2;
            pY = y * 2;
			checkX = x;
			checkY = y;
            for(int i = 0; i < imglist.Images.Count; i++)
                PacmanImages.Images.Add(imglist.Images[i]);

            PacmanBitmap = new Bitmap(PacmanImages.Images[1]);
            g = form.BoardPanel.CreateGraphics();
            g.DrawImage(PacmanBitmap, new Point((pX * 9 - 2), (pY * 9 - 1)));
            g.Dispose();

            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Rectangle rc = new Rectangle(((pX - 1) * 9 - 2), ((pY - 1) * 9 - 1), 41, 42);
            form.BoardPanel.Invalidate(rc, true);
            PacmanBitmap.Dispose();
            UpdatePacmanImage();
        }
        private void UpdatePacmanImage()
        {
            PacmanBitmap = (Bitmap)PacmanImages.Images[((currentDirection - 1) * 4) + imageOn];
            imageOn++;
            if (imageOn > 3) { imageOn = 0; }
        }

        public void StartGame()
        {
            timer.Enabled = true;
        }

        public void StopGame()
        {
            timer.Enabled = false;
        }

        public void ResetGame()
        {
            imageOn = 0;

            currentDirection = 1;
            pX = board.StartX * 2;
            pY = board.StartY * 2;
            checkX = board.StartX;
            checkY = board.StartY;

            PacmanBitmap = new Bitmap(PacmanImages.Images[1]);
            g = form.CreateGraphics();
            g.DrawImage(PacmanBitmap, new Point((pX * 9 - 2), (pY * 9 - 1)));
            g.Dispose();

            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
    }
}
