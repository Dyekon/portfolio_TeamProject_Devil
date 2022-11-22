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
    public partial class Form1 : Form
    {
        Graphics g;
        public PictureBox blockImage = new PictureBox();
        private Board board = new Board();
        private Player player;
        private Ghost ghost;
        private Ghost1 ghost1;
        private Ghost2 ghost2;
        private Ghost3 ghost3;
		private bool isKeyDown;
        private bool isGhostDraw = false;
        public bool isItemOn;
        public bool isItemInvalidate;
        public float itemTime;
        private int speedUpCnt;
		private Keys keyCode;
        private int playerDirectionX;
        private int playerDirectionY;
        private int nextDirection;
        public int score;
        private int blockcnt;
        private String labelText;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            player = new Player(board.StartX, board.StartY, PacImagelist, board, this);
            ghost = new Ghost(board.StartGhostX, board.StartGhostY, ghostImageList, board, this);
            ghost1 = new Ghost1(board.StartGhostX, board.StartGhostY, ghostImageList, board, this);
            ghost2 = new Ghost2(board.StartGhostX, board.StartGhostY, ghostImageList, board, this);
            ghost3 = new Ghost3(board.StartGhostX, board.StartGhostY, ghostImageList, board, this);
            timer1.Enabled = true;
			isKeyDown = false;
            isItemOn = false;
            itemTime = 0;
            blockImage.Image = blockImageList.Images[0];
            score = 0;
            speedUpCnt = 0;
            blockcnt = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			isKeyDown = true;
			keyCode = e.KeyCode;
			if (isKeyDown)
			{
				if (e.KeyCode == Keys.Up)
				{
					nextDirection = 1;
					playerDirectionY = -1;
				}
				else if (e.KeyCode == Keys.Right)
				{
					nextDirection = 2;
					playerDirectionX = 1;
				}
                else if(e.KeyCode == Keys.Down)
				{
					nextDirection = 3;
					playerDirectionY = 1;
				}
                else if(e.KeyCode == Keys.Left)
				{
					nextDirection = 4;
					playerDirectionX = -1;
				}

				if (check_direction(nextDirection) && player.pX % 2 == 0 && player.pY % 2 == 0)
				{
					player.currentDirection = nextDirection;
					switch (nextDirection)
					{
						case 1: playerDirectionY = -1; break;
						case 2: playerDirectionX = 1; break;
						case 3: playerDirectionY = 1; break;
						case 4: playerDirectionX = -1; break;
					}
				}
			}
        }
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			isKeyDown = false;
            speedUpCnt = 0;
		}

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
 
            blockcnt = 0;
            for (int i = 0; i < 27; i++)
                for (int j = 0; j < 30; j++) {
                    if (board.Map[j, i] == 1 || board.Map[j, i] == 5) {
                        g.DrawImage(blockImage.Image, (i * 18 - 2), (j * 18 - 1));
                        blockcnt++;
                    } else if (board.Map[j, i] == 2) {
                        blockImage.Image = blockImageList.Images[1];
                        g.DrawImage(blockImage.Image, (i * 18 - 2), (j * 18 - 1));
                        blockImage.Image = blockImageList.Images[0];
                        blockcnt++;
                    } else if (board.Map[j, i] == 6 && isItemOn) {
                        blockImage.Image = blockImageList.Images[2];
                        g.DrawImage(blockImage.Image, (i * 18 - 2), (j * 18 - 1));
                        blockImage.Image = blockImageList.Images[0];
                        //blockcnt++;
                    }
                }

            g.DrawImage(player.PacmanBitmap, new Point((player.pX * 9 - 2), (player.pY * 9 - 1)));
            if (ghost.State != 2)
                g.DrawImage(ghost.GhostBitmap, new Point((ghost.gX * 9 - 2), (ghost.gY * 9 - 1)));
            else
                g.DrawImage(ghost.GhostBitmap, new Point((ghost.homeX), (ghost.homeY)));
            if (ghost1.State != 2)
                g.DrawImage(ghost1.GhostBitmap, new Point((ghost1.gX * 9 - 2), (ghost1.gY * 9 - 1)));
            else
                g.DrawImage(ghost1.GhostBitmap, new Point((ghost1.homeX), (ghost1.homeY)));
            if (ghost2.State != 2)
                g.DrawImage(ghost2.GhostBitmap, new Point((ghost2.gX * 9 - 2), (ghost2.gY * 9 - 1)));
            else
                g.DrawImage(ghost2.GhostBitmap, new Point((ghost2.homeX), (ghost2.homeY)));
            if (ghost3.State != 2)
                g.DrawImage(ghost3.GhostBitmap, new Point((ghost3.gX * 9 - 2), (ghost3.gY * 9 - 1)));
            else
                g.DrawImage(ghost3.GhostBitmap, new Point((ghost3.homeX), (ghost3.homeY)));

            labelText = String.Format("Score : {0}", score);
            label1.Text = labelText;
            if(blockcnt == 0)
            {
                PacmanDead();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isKeyDown)
                speedUpCnt++;
            if(speedUpCnt >= 7){
                timer1.Interval = 25;
                player.timer.Interval = 25;
            }else{
                timer1.Interval = 100;
                player.timer.Interval = 100;
            }
            if (player.currentDirection == 2 || player.currentDirection == 4)
                if (board.Map[player.checkY, player.checkX + playerDirectionX] < 7)
                {
                    player.pX += playerDirectionX;
                    if (player.pX % 2 == 0)
                        player.checkX = player.pX / 2;
                }
            if (player.currentDirection == 1 || player.currentDirection == 3)
                if (board.Map[player.checkY + playerDirectionY, player.checkX] < 7)
                {
                    player.pY += playerDirectionY;
                    if (player.pY % 2 == 0)
                        player.checkY = player.pY / 2;
                }
            if (player.pX % 2 == 0 && player.pY % 2 == 0 && board.Map[player.checkY, player.checkX] == 1 || player.pX % 2 == 0 && player.pY % 2 == 0 && board.Map[player.checkY, player.checkX] == 5
                 || player.pX % 2 == 0 && player.pY % 2 == 0 && board.Map[player.checkY, player.checkX] == 6) {
                if (board.Map[player.checkY, player.checkX] == 5)
                    board.Map[player.checkY, player.checkX] = 04;
                else if (board.Map[player.checkY, player.checkX] == 6 && isItemOn) {
                    itemTime = 0;
                    isItemOn = false;
                    score += 950;
                } else {
                    if(board.Map[player.checkY, player.checkX] != 6)
                        board.Map[player.checkY, player.checkX] = 0;
                    score += 50;
                }             
                
            } else if (player.pX % 2 == 0 && player.pY % 2 == 0 && board.Map[player.checkY, player.checkX] == 2) {
                board.Map[player.checkY, player.checkX] = 0;
                ghost.ChangeGhostState();
                ghost1.ChangeGhostState();
                ghost2.ChangeGhostState();
                ghost3.ChangeGhostState();
                score += 150;
            }
            ghost.CheckForPacman(player.checkX, player.checkY);
            ghost1.CheckForPacman(player.checkX, player.checkY);
            ghost2.CheckForPacman(player.checkX, player.checkY);
            ghost3.CheckForPacman(player.checkX, player.checkY);
            PacmanMove();

            itemTime += 0.2f;
            if (itemTime > 30) {
                isItemOn = true;
                isItemInvalidate = true;
            } else if (itemTime > 40) {
                isItemOn = false;
                itemTime = 0;
            }

            if (isItemInvalidate) {
                Rectangle rc = new Rectangle((board.itemX * 18 - 2), (board.itemY * 18 - 1), 41, 42);
                BoardPanel.Invalidate(rc, true);
                isItemInvalidate = false;
            }
        }

        private bool check_direction(int direction)
        {
            switch (direction)
            {
                case 1: return direction_ok(player.checkX, player.checkY - 1);
                case 2: return direction_ok(player.checkX + 1, player.checkY);
                case 3: return direction_ok(player.checkX, player.checkY + 1);
                case 4: return direction_ok(player.checkX - 1, player.checkY);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            if (board.Map[y, x] < 6) { return true; } else { return false; }
        }

		private void PacmanMove()
		{
			if (isKeyDown)
			{
				if (keyCode == Keys.Up)
				{
					nextDirection = 1;
					playerDirectionY = -1;
				}
                else if(keyCode == Keys.Right)
				{
					nextDirection = 2;
					playerDirectionX = 1;
				}
                else if(keyCode == Keys.Down)
				{
					nextDirection = 3;
					playerDirectionY = 1;
				}
                else if(keyCode == Keys.Left)
				{
					nextDirection = 4;
					playerDirectionX = -1;
				}

				if (check_direction(nextDirection) && player.pX % 2 == 0 && player.pY % 2 == 0)
				{
					player.currentDirection = nextDirection;
					switch (nextDirection)
					{
						case 1: playerDirectionY = -1; break;
						case 2: playerDirectionX = 1; break;
						case 3: playerDirectionY = 1; break;
						case 4: playerDirectionX = -1; break;
					}
				}
			}
		}

        public void sendForInky(int x, int y){
            ghost2.CheckForBlinky(x, y);
        }

        public void PacmanDead(){
            timer1.Enabled = false;
            player.StopGame();
            ghost.StopGame();
            ghost1.StopGame();
            ghost2.StopGame();
            ghost3.StopGame();
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.StartGame();
            ghost.StartGame();
            ghost1.StartGame();
            ghost2.StartGame();
            ghost3.StartGame();
            timer1.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.ResetGame();
            player.ResetGame();
            ghost.GameReset();
            ghost1.GameReset();
            ghost2.GameReset();
            ghost3.GameReset();
            button1.Enabled = true;
            timer1.Enabled = false;
            score = 0;
            board.CopyMap();
            BoardPanel.Invalidate();
        }
    }
}
