using System;
using System.Collections;
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
    class Ghost2
    {
        private const int GhostAmount = 1;

        public int Ghosts = GhostAmount;
        Graphics g;
        private Form1 form;
        private Board board;
        public Bitmap GhostBitmap;
        private ImageList GhostImages = new ImageList();
        private Timer timer = new Timer();
        private Timer startTimer = new Timer();
        private Timer triggerTimer = new Timer();
        private Timer killTimer = new Timer();
        private Timer stateTimer = new Timer();
        private Timer homeTimer = new Timer();
        private int imageCnt = 0;
        public int State;
        public int gX;
        public int gY;
        public int homeX;
        public int homeY;
        public int checkX;
        public int checkY;
        public int xStart;
        public int yStart;
        public int Direction;
        public int DirectionX;
        public int DirectionY;
        private int pacmanX;
        private int pacmanY;
        private int blinkyX;
        private int blinkyY;
        private int movePointX;
        private int movePointY;
        private int EscapeX;
        private int EscapeY;
        public bool stop = true;
        private ArrayList InkyMoveRouteX = new ArrayList();
        private ArrayList InkyMoveRouteY = new ArrayList();
        private Random ran = new Random();
        public int[,] map = new int[30, 27];
        public int[,] checkMap = new int[,] {
                        { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
                        { -1,00,00,00,00,00,00,00,00,00,00,00,00,-1,-1,00,00,00,00,00,00,00,00,00,00,00,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,00,00,00,00,00,-1,-1,00,00,00,00,-1,-1,00,00,00,00,-1,-1,00,00,00,00,00,00,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,00,00,00,00,00,00,00,00,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,00,00,00,-1,-1,-1,-1,-1,-1,-1,-1,00,00,00,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,00,00,00,00,00,00,00,00,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1 },
                        { -1,00,00,00,00,00,00,00,00,00,00,00,00,-1,-1,00,00,00,00,00,00,00,00,00,00,00,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,-1,-1,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,00,-1,-1,-1,-1,00,-1 },
                        { -1,00,00,00,-1,-1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,-1,-1,00,00,00,-1 },
                        { -1,-1,-1,00,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,00,-1,-1,-1 },
                        { -1,-1,-1,00,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,00,-1,-1,-1 },
                        { -1,00,00,00,00,00,00,-1,-1,00,00,00,00,-1,-1,00,00,00,00,-1,-1,00,00,00,00,00,00,-1 },
                        { -1,00,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,00,-1 },
                        { -1,00,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,00,-1,-1,00,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,00,-1 },
                        { -1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,-1 },
                        { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 } };

        public Ghost2(int x, int y, ImageList imglist, Board board, Form1 form)
        {
            this.form = form;
            this.board = board;
            for (int i = 0; i < imglist.Images.Count; i++)
                GhostImages.Images.Add(imglist.Images[i]);

            Direction = 1;
            DirectionX = -1;
            DirectionY = -1;
            State = 1;

            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 27; j++)
                    map[i, j] = checkMap[i, j];

            gX = x * 2;
            gY = (y + 1) * 2;
            checkX = x;
            checkY = y;
            xStart = x;
            yStart = y;
            State = 0;
            blinkyX = 0;
            blinkyY = 0;

            GhostBitmap = new Bitmap(GhostImages.Images[4 + Direction]);
            Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
            form.BoardPanel.Invalidate(rc, true);

            timer.Interval = 110;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);

            startTimer.Interval = 3000;
            startTimer.Enabled = false;
            startTimer.Tick += new EventHandler(startTimer_Tick);

            killTimer.Interval = 165;
            killTimer.Enabled = false;
            killTimer.Tick += new EventHandler(killTimer_Tick);

            triggerTimer.Interval = 25;
            triggerTimer.Enabled = true;
            triggerTimer.Tick += new EventHandler(triggerTimer_Tick);

            stateTimer.Interval = 10000;
            stateTimer.Enabled = false;
            stateTimer.Tick += new EventHandler(stateTimer_Tick);

            homeTimer.Interval = 5;
            homeTimer.Enabled = false;
            homeTimer.Tick += new EventHandler(homeTimer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Direction == 2 || Direction == 4)
                if (board.Map[checkY, checkX] > 10)
                {
                    if (board.Map[checkY, checkX + DirectionX] < 7 || board.Map[checkY, checkX + DirectionX] > 10)
                    {
                        gX += DirectionX;
                        if (gX % 2 == 0)
                            checkX = gX / 2;
                    }
                }
                else
                {
                    if (board.Map[checkY, checkX + DirectionX] < 7)
                    {
                        gX += DirectionX;
                        if (gX % 2 == 0)
                            checkX = gX / 2;
                    }
                }
            if (Direction == 1 || Direction == 3)
                if (board.Map[checkY, checkX] > 10)
                {
                    if (board.Map[checkY + DirectionY, checkX] < 7 || board.Map[checkY + DirectionY, checkX] > 10)
                    {
                        gY += DirectionY;
                        if (gY % 2 == 0)
                            checkY = gY / 2;
                    }
                }
                else
                {
                    if (board.Map[checkY + DirectionY, checkX] < 7)
                    {
                        gY += DirectionY;
                        if (gY % 2 == 0)
                            checkY = gY / 2;
                    }
                }
            MoveGhosts();
            GhostBitmap = (Bitmap)GhostImages.Images[4 + Direction];
            Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
            form.BoardPanel.Invalidate(rc, true);
        }
        public void MoveGhosts()
        {
            if (board.Map[checkY, checkX] == 05 && gX % 2 == 0 && gY % 2 == 0 || board.Map[checkY, checkX] == 04 && gX % 2 == 0 && gY % 2 == 0)
            {
                if (InkyMoveRouteX.Count < 2)
                {
                    InkyMoveRouteX.Clear();
                    InkyMoveRouteY.Clear();
                    InkyAlgorithm();
                    blinkyAlgorithm(checkX, checkY, 0);
                    for (int i = 0; i < 30; i++)
                        for (int j = 0; j < 27; j++)
                            checkMap[i, j] = map[i, j];
                }
            }
            if (InkyMoveRouteX.Count != 0 && gX % 2 == 0 && gY % 2 == 0)
            {
                if (checkX == (int)InkyMoveRouteX[0])
                {
                    if ((int)InkyMoveRouteY[0] - checkY < 0)
                        Direction = 1;
                    else
                        Direction = 3;
                }
                else
                {
                    if ((int)InkyMoveRouteX[0] - checkX < 0)
                        Direction = 4;
                    else
                        Direction = 2;
                }
                InkyMoveRouteX.RemoveAt(0);
                InkyMoveRouteY.RemoveAt(0);
            }

            if (check_direction(Direction) && gX % 2 == 0 && gY % 2 == 0)
            {
                switch (Direction)
                {
                    case 1: DirectionY = -1; break;
                    case 2: DirectionX = 1; break;
                    case 3: DirectionY = 1; break;
                    case 4: DirectionX = -1; break;
                }
            }
        }
        public void ScaryMoveGhosts1()
        {
            if (board.Map[checkY, checkX] == 05 && gX % 2 == 0 && gY % 2 == 0 || board.Map[checkY, checkX] == 04 && gX % 2 == 0 && gY % 2 == 0)
            {
                InkyMoveRouteX.Clear();
                InkyMoveRouteY.Clear();
                EscapeAlgorithm(checkX, checkY, 0);
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 27; j++)
                        checkMap[i, j] = map[i, j];
            }
            if (InkyMoveRouteX.Count != 0 && gX % 2 == 0 && gY % 2 == 0)
            {
                if (checkX == (int)InkyMoveRouteX[0])
                {
                    if ((int)InkyMoveRouteY[0] - checkY < 0)
                        Direction = 1;
                    else
                        Direction = 3;
                }
                else
                {
                    if ((int)InkyMoveRouteX[0] - checkX < 0)
                        Direction = 4;
                    else
                        Direction = 2;
                }
                InkyMoveRouteX.RemoveAt(0);
                InkyMoveRouteY.RemoveAt(0);
            }

            if (check_direction(Direction) && gX % 2 == 0 && gY % 2 == 0)
            {
                switch (Direction)
                {
                    case 1: DirectionY = -1; break;
                    case 2: DirectionX = 1; break;
                    case 3: DirectionY = 1; break;
                    case 4: DirectionX = -1; break;
                }
            }
        }
        public void MoveScaryGhosts()
        {
            if (board.Map[checkY, checkX] == 05 && gX % 2 == 0 && gY % 2 == 0 || board.Map[checkY, checkX] == 04 && gX % 2 == 0 && gY % 2 == 0)
            {
                ScaryMoveGhosts1();
            }
            if (check_direction(Direction) && gX % 2 == 0 && gY % 2 == 0)
            {
                switch (Direction)
                {
                    case 1: DirectionY = -1; break;
                    case 2: DirectionX = 1; break;
                    case 3: DirectionY = 1; break;
                    case 4: DirectionX = -1; break;
                }
            }
        }

        private bool check_direction(int direction)
        {
            switch (direction)
            {
                case 1: return direction_ok(checkX, checkY - 1);
                case 2: return direction_ok(checkX + 1, checkY);
                case 3: return direction_ok(checkX, checkY + 1);
                case 4: return direction_ok(checkX - 1, checkY);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            if (board.Map[checkY, checkX] > 10)
                if (board.Map[y, x] < 6 || board.Map[y, x] > 10) { return true; } else { return false; }
            else
                if (board.Map[y, x] < 6) { return true; } else { return false; }
        }
        private void triggerTimer_Tick(object sender, EventArgs e)
        {
            if (checkX == pacmanX && checkY == pacmanY && State == 0){
                form.PacmanDead();
            }
            if (checkX == pacmanX && checkY == pacmanY && State == 1)
            {
                State = 2;
                timer.Enabled = false;
                killTimer.Enabled = false;
                homeTimer.Enabled = true;
                homeX = gX * 9 - 2;
                homeY = gY * 9 - 2;
                GhostBitmap = (Bitmap)GhostImages.Images[0];
                Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
                form.BoardPanel.Invalidate(rc, true);
                form.score += 500;
            }
        }
        private void killTimer_Tick(object sender, EventArgs e)
        {
            if (Direction == 2 || Direction == 4)
                if (board.Map[checkY, checkX] > 10)
                {
                    if (board.Map[checkY, checkX + DirectionX] < 7 || board.Map[checkY, checkX + DirectionX] > 10)
                    {
                        gX += DirectionX;
                        if (gX % 2 == 0)
                            checkX = gX / 2;
                    }
                }
                else
                {
                    if (board.Map[checkY, checkX + DirectionX] < 7)
                    {
                        gX += DirectionX;
                        if (gX % 2 == 0)
                            checkX = gX / 2;
                    }
                }
            if (Direction == 1 || Direction == 3)
                if (board.Map[checkY, checkX] > 10)
                {
                    if (board.Map[checkY + DirectionY, checkX] < 7 || board.Map[checkY + DirectionY, checkX] > 10)
                    {
                        gY += DirectionY;
                        if (gY % 2 == 0)
                            checkY = gY / 2;
                    }
                }
                else
                {
                    if (board.Map[checkY + DirectionY, checkX] < 7)
                    {
                        gY += DirectionY;
                        if (gY % 2 == 0)
                            checkY = gY / 2;
                    }
                }
            if (State > 0)
            {
                MoveScaryGhosts();
            }
            imageCnt++;
            if (imageCnt <= 4)
                GhostBitmap = (Bitmap)GhostImages.Images[17];
            else
                GhostBitmap = (Bitmap)GhostImages.Images[18];
            if (imageCnt == 8) { imageCnt = 0; }
            Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
            form.BoardPanel.Invalidate(rc, true);
        }
        private void stateTimer_Tick(object sender, EventArgs e)
        {
            if (State != 2)
            {
                State = 0;
                stateTimer.Enabled = false;
                timer.Enabled = true;
                timer.Start();
                killTimer.Enabled = false;
            }
        }
        private void startTimer_Tick(object sender, EventArgs e)
        {
            if (!stop)
            {
                timer.Enabled = true;
                timer.Start();
                startTimer.Enabled = false;
            }
        }
        private void homeTimer_Tick(object sender, EventArgs e)
        {
            if (State == 2)
            {
                int xpos = xStart * 18 - 2;
                int ypos = yStart * 18 - 1;
                if (homeX > xpos) { homeX--; }
                if (homeX < xpos) { homeX++; }
                if (homeY > ypos) { homeY--; }
                if (homeY < ypos) { homeY++; }
                Rectangle rc = new Rectangle((homeX - 20), (homeY - 20), 40, 40);
                form.BoardPanel.Invalidate(rc, false);
                if (homeY == ypos && homeX == xpos)
                {
                    State = 0;
                    InkyMoveRouteX.Clear();
                    InkyMoveRouteY.Clear();
                    gX = xStart * 2;
                    gY = yStart * 2;
                    checkX = xStart;
                    checkY = yStart;
                    Direction = 1;
                    GhostBitmap = (Bitmap)GhostImages.Images[4 + Direction];
                    rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
                    form.BoardPanel.Invalidate(rc, true);
                    timer.Enabled = true;
                }
            }
        }
        public void ChangeGhostState()
        {
            if (State != 2)
            {
                if (State == 0)
                {
                    State = 1;
                    InkyMoveRouteX.Clear();
                    InkyMoveRouteY.Clear();
                    GhostBitmap = (Bitmap)GhostImages.Images[17];
                    Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
                    form.BoardPanel.Invalidate(rc, true);
                }
                timer.Enabled = false;
                killTimer.Stop();
                killTimer.Enabled = true;
                killTimer.Start();
                stateTimer.Stop();
                stateTimer.Enabled = true;
                stateTimer.Start();
            }
        }
        private void InkyAlgorithm()
        {
            int x = blinkyX - pacmanX;
            int y = blinkyY - pacmanY;
            x = pacmanX + (x * -1);
            y = pacmanY + (y * -1);

            if (x < 27 && y < 30 && x > 0 && y > 0)
            {
                if (checkMap[y, x] != -1)
                {
                    movePointX = x;
                    movePointY = y;
                }
                else
                {
                    movePointX = pacmanX;
                    movePointY = pacmanY;
                }
            }
            else
            {
                movePointX = pacmanX;
                movePointY = pacmanY;
            }
        }
        private void blinkyAlgorithm(int x, int y, int cnt)
        {
            checkMap[y, x] = 01;
            if (x == movePointX && y == movePointY)
                return;
            while (checkMap[movePointY, movePointX] == 0)
            {
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 27; j++)
                        if (checkMap[i, j] > 0)
                        {
                            if (checkMap[i + 1, j] == 00)
                                checkMap[i + 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i - 1, j] == 00)
                                checkMap[i - 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i, j + 1] == 00)
                                checkMap[i, j + 1] = checkMap[i, j] + 1;
                            if (checkMap[i, j - 1] == 00)
                                checkMap[i, j - 1] = checkMap[i, j] + 1;
                        }
            }
            int X = movePointX;
            int Y = movePointY;
            while (true)
            {
                if (checkMap[Y + 1, X] == checkMap[Y, X] - 1)
                {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    Y += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y - 1, X] == checkMap[Y, X] - 1)
                {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    Y -= 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X + 1] == checkMap[Y, X] - 1)
                {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    X += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X - 1] == checkMap[Y, X] - 1)
                {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    X -= 1;
                    if (X == x && Y == y)
                        break;
                }
            }
        }
        private void EscapeAlgorithm(int x, int y, int cnt) {
            checkMap[y, x] = 01;
            if (pacmanX < 13 && pacmanY < 15) {
                EscapeX = 25;
                EscapeY = 29;
            } else if (pacmanX < 13 && pacmanY >= 15) {
                EscapeX = 25;
                EscapeY = 1;
            } else if (pacmanX >= 13 && pacmanY < 15) {
                EscapeX = 1;
                EscapeY = 29;
            } else if (pacmanX >= 13 && pacmanY >= 15) {
                EscapeX = 1;
                EscapeY = 1;
            }
            if (x == EscapeX && y == EscapeY)
                return;
            while (checkMap[EscapeY, EscapeX] == 0) {
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 27; j++)
                        if (checkMap[i, j] > 0) {
                            if (checkMap[i + 1, j] == 00)
                                checkMap[i + 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i - 1, j] == 00)
                                checkMap[i - 1, j] = checkMap[i, j] + 1;
                            if (checkMap[i, j + 1] == 00)
                                checkMap[i, j + 1] = checkMap[i, j] + 1;
                            if (checkMap[i, j - 1] == 00)
                                checkMap[i, j - 1] = checkMap[i, j] + 1;
                        }
            }
            int X = EscapeX;
            int Y = EscapeY;

            while (true) {
                if (checkMap[Y + 1, X] == checkMap[Y, X] - 1) {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    Y += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y - 1, X] == checkMap[Y, X] - 1) {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    Y -= 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X + 1] == checkMap[Y, X] - 1) {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    X += 1;
                    if (X == x && Y == y)
                        break;
                }
                if (checkMap[Y, X - 1] == checkMap[Y, X] - 1) {
                    InkyMoveRouteX.Insert(0, X);
                    InkyMoveRouteY.Insert(0, Y);
                    X -= 1;
                    if (X == x && Y == y)
                        break;
                }
            }
        }

        public void CheckForPacman(int x, int y)
        {
            pacmanX = x;
            pacmanY = y;
        }

        public void CheckForBlinky(int x, int y)
        {
            blinkyX = x;
            blinkyY = y;
        }

        public void StartGame()
        {
            stop = false;
            startTimer.Enabled = true;
            startTimer.Start();
        }

        public void StopGame()
        {
            stop = true;
            timer.Enabled = false;
            killTimer.Enabled = false;
            triggerTimer.Enabled = false;
            stateTimer.Enabled = false;
            homeTimer.Enabled = false;
        }

        public void GameReset()
        {
            stop = true;
            Direction = 1;
            DirectionX = -1;
            DirectionY = -1;

            gX = xStart * 2;
            gY = (yStart + 1) * 2;
            checkX = xStart;
            checkY = yStart;
            State = 0;

            GhostBitmap = (Bitmap)GhostImages.Images[4 + Direction];
            Rectangle rc = new Rectangle(((gX - 1) * 9 - 2), ((gY - 1) * 9 - 1), 41, 42);
            form.BoardPanel.Invalidate(rc, true);

            timer.Enabled = false;
            startTimer.Enabled = false;
            killTimer.Enabled = false;
            triggerTimer.Enabled = true;
            stateTimer.Enabled = false;
            homeTimer.Enabled = false;

            InkyMoveRouteX.Clear();
            InkyMoveRouteY.Clear();
        }
    }
}
