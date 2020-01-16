using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Long_Game
{
    public class CActorBackground
    {
        public int xS, yS;
        public int xD, yD;
        public Bitmap im;
    }

    public class CActorTiles
    {
        public int X, Y;
        public Bitmap im;
    }

    class CActorGround
    {
        public int X, Y;
        public Bitmap im;
        public int nWholeWidth;

        public void DrawYourSelf(Graphics g2)
        {
            int tempx = X;
            for (int i = 0; i < nWholeWidth; i++)
            {
                g2.DrawImage(im, tempx, Y);
                tempx += im.Width-8;
            }

        }
    }

    public class CActorHero
    {
        public int X, Y;
        public int dy;
        public List<Bitmap> im;
        public int iFrame;
        public int Hide = 0;
    }

    public class CActorEnemy1
    {
        public int X, Y;
        public int dx;
        public int minX, maxX;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorShakoosh
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
        public int dx = -1;
    }

    public class CActorLife
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorGameOver
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorWinner
    {
        public int X, Y;
        public Bitmap im1;
        public Bitmap im2;
    }

    public class CActorFire
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorCoins
    {
        public int X, Y;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorEnemy2
    {
        public int X, Y;
        public int dx;
        public List<Bitmap> im;
        public int iFrame;
    }

    public class CActorRectMode
    {
        public int X, Y;
        public Bitmap im;
        public int Flag;
    }

    public class CActorElevator
    {
        public int X, Y;
        public Bitmap im;
        public int dy;
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        List<CActorBackground> LBackground = new List<CActorBackground>();
        List<CActorGround> LGround = new List<CActorGround>();
        List<CActorHero> LHero = new List<CActorHero>();
        List<CActorTiles> LTiles = new List<CActorTiles>();
        List<CActorEnemy1> LEnemy1 = new List<CActorEnemy1>();
        List<CActorShakoosh> LShakoosh = new List<CActorShakoosh>();
        List<CActorLife> LLife = new List<CActorLife>();
        List<CActorGameOver> LGameOver = new List<CActorGameOver>();
        List<CActorWinner> LWinner = new List<CActorWinner>();
        List<CActorFire> LFire = new List<CActorFire>();
        List<CActorCoins> LCoins = new List<CActorCoins>();
        List<CActorEnemy2> LEnemy2 = new List<CActorEnemy2>();
        List<CActorRectMode> LRect = new List<CActorRectMode>();
        List<CActorElevator> LElevator = new List<CActorElevator>();

        Timer t = new Timer();
        int CountTick = 0;
        int FlagLeftH = 0;
        int FlagRightH = 0;
        int FlagUpH = 0;
        int Countmove = 0;
        int FlagJump = 0;
        int CountLife = 3;
        int GameOverW = 20;
        int WinnerWidth = 20;
        int FlagFire = 0;
        int Score = 0;
        int FlagWinner = 0;
        Random RR = new Random();

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 10;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            int i;
            int k;
            //////////////////////////////////////////////////////////////////////////////////////////
            if (CountLife != 0 && FlagWinner == 0)
            {
                if (FlagLeftH == 1)
                {
                    if (LBackground[0].xD <= 0)
                    {
                        for (i = 0; i < LBackground.Count; i++)
                        {
                            LBackground[i].xD += 7;
                            if (LBackground[1].xD <= 0)
                            {
                                LBackground[1].xD = this.ClientSize.Width;
                                LBackground[0].xD = 0;
                            }
                        }
                        LGround[0].X += 7;
                        LElevator[0].X += 7;
                        for (i = 0; i < LTiles.Count; i++)
                        {
                            LTiles[i].X += 7;
                        }

                        for (i = 0; i < LCoins.Count; i++)
                        {
                            LCoins[i].X += 7;
                        }

                        for (i = 0; i < LEnemy2.Count; i++)
                        {
                            LEnemy2[i].X += 7;
                        }

                        for (i = 0; i < LEnemy1.Count; i++)
                        {
                            LEnemy1[i].X += 7;
                            LEnemy1[i].maxX += 7;
                            LEnemy1[i].minX += 7;
                        }
                        for (i = 0; i < LShakoosh.Count; i++)
                        {
                            LShakoosh[i].X += 7;
                        }
                    }
                    if (LHero[0].iFrame >= 3)
                    {
                        LHero[0].iFrame = 0;
                    }
                    LHero[0].iFrame += 1;
                    //LHero[0].X -= 2;
                }

                if (FlagRightH == 1)
                {
                    for (i = 0; i < LBackground.Count; i++)
                    {
                        LBackground[i].xD -= 7;
                        if (LBackground[1].xD <= 0)
                        {
                            LBackground[1].xD = this.ClientSize.Width;
                            LBackground[0].xD = 0;
                        }
                    }
                    LGround[0].X -= 7;
                    LElevator[0].X -= 7;
                    for (i = 0; i < LTiles.Count; i++)
                    {
                        LTiles[i].X -= 7;
                    }

                    for (i = 0; i < LEnemy1.Count; i++)
                    {
                        LEnemy1[i].X -= 7;
                        LEnemy1[i].maxX -= 7;
                        LEnemy1[i].minX -= 7;
                    }
                    for (i = 0; i < LShakoosh.Count; i++)
                    {
                        LShakoosh[i].X -= 7;
                    }

                    for (i = 0; i < LCoins.Count; i++)
                    {
                        LCoins[i].X -= 7;
                    }

                    for (i = 0; i < LEnemy2.Count; i++)
                    {
                        LEnemy2[i].X -= 7;
                    }

                    if (LHero[0].iFrame <= 0)
                    {
                        LHero[0].iFrame = 4;
                    }
                    LHero[0].iFrame -= 1;
                    //LHero[0].X += 2;
                }

                if (FlagUpH == 1)
                {
                    if (LHero[0].dy == -1)
                    {
                        LHero[0].Y -= 40;
                        if (Countmove <= 3)
                        {
                            LHero[0].iFrame = 4;
                        }
                        if (Countmove > 3)
                        {
                            LHero[0].iFrame = 5;
                        }
                        Countmove++;
                        if (Countmove == 6)
                        {
                            LHero[0].dy = 1;
                            FlagUpH = 0;
                            LHero[0].iFrame = 5;
                            Countmove = 0;
                        }
                    }
                }

                if (LHero[0].dy == 1)
                {
                    LHero[0].Y += 40;
                    if (Countmove < 3)
                    {
                        LHero[0].iFrame = 5;
                    }
                    if (Countmove >= 3)
                    {
                        LHero[0].iFrame = 6;
                    }
                    Countmove++;
                    for (i = 0; i < LTiles.Count; i++)
                    {
                        if (LHero[0].Y + LHero[0].im[0].Height - 100 >= 350 && LHero[0].X + LHero[0].im[0].Width >= LTiles[i].X
                            && LHero[0].X <= (LTiles[i].X + LTiles[i].im.Width))
                        {
                            LHero[0].dy = 0;
                            LHero[0].iFrame = 0;
                        }
                    }
                    if (LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height)
                    {
                        LHero[0].dy = 0;
                        LHero[0].iFrame = 0;
                    }
                }
                if (LHero[0].dy == 0)
                {
                    FlagJump = 0;
                    for (i = 0; i < LTiles.Count; i++)
                    {
                        if (LHero[0].Y + LHero[0].im[0].Height - 100 >= 350 && LHero[0].X + LHero[0].im[0].Width >= LTiles[i].X
                            && LHero[0].X <= (LTiles[i].X + LTiles[i].im.Width))
                        {
                            FlagJump = 1;
                        }
                    }
                    if (LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height)
                    {
                        FlagJump = 1;
                    }
                    if (FlagJump == 0)
                    {
                        LHero[0].Y += 40;
                        LHero[0].iFrame = 5;
                    }
                }
                if (FlagRightH == 0 && FlagLeftH == 0 && FlagUpH == 0)
                {
                    LHero[0].iFrame = 0;
                }
                ////////////////////////////////////////////////////////Hero Movement/////////////////////////////////////////////

                if (FlagFire == 1)
                {
                    CActorFire pnn = new CActorFire();
                    pnn.X = LHero[0].X + 110;
                    pnn.Y = LHero[0].Y + 80;
                    pnn.im = new List<Bitmap>();
                    for (i = 0; i < 4; i++)
                    {
                        Bitmap bb = new Bitmap("Fire" + (i + 1) + ".png");
                        pnn.im.Add(bb);
                    }
                    pnn.iFrame = 0;
                    LFire.Add(pnn);
                }

                for (i = 0; i < LFire.Count; i++)
                {
                    LFire[i].X += 8;
                    if (CountTick % 3 == 0)
                    {
                        if (LFire[i].iFrame < 3)
                        {
                            LFire[i].iFrame += 1;
                        }
                    }
                }

                for (i = 0; i < LFire.Count; i++)
                {
                    if (CountTick % 10 == 0)
                    {
                        if (LFire[i].iFrame == 3)
                        {
                            LFire.Remove(LFire[i]);
                        }
                    }
                }
                ///////////////////////////////////////////////////Fire creation & Movement///////////////////////////
                for (i = 0; i < LFire.Count; i++)
                {
                    for (k = 0; k < LEnemy1.Count; k++)
                    {
                        if (LFire[i].X >= LEnemy1[k].X 
                            && LFire[i].X <= (LEnemy1[k].X + LEnemy1[k].im[0].Width )
                            && LHero[0].Y == this.ClientSize.Height - (LHero[0].im[0].Height + 60))
                        {
                            LFire.Remove(LFire[i]);
                            Score += 50;
                            LEnemy1.Remove(LEnemy1[k]);
                            //MessageBox.Show("ok");
                            break;
                        }
                    }
                }
                /////////////////////////////////////////////Fire / Enemy1 Life//////////////////////////////

                for (i = 0; i < LEnemy1.Count; i++)
                {
                    if (LEnemy1[i].dx == -1)
                    {
                        LEnemy1[i].X -= 3;
                        if (LEnemy1[i].iFrame >= 3)
                        {
                            LEnemy1[i].iFrame = 0;
                        }
                        if (CountTick % 12 == 0)
                        {
                            LEnemy1[i].iFrame += 1;
                        }
                        if (LEnemy1[i].iFrame == 2)
                        {
                            if (CountTick % 12 == 0)
                            {
                                CActorShakoosh pnn = new CActorShakoosh();
                                pnn.X = LEnemy1[i].X;
                                pnn.Y = this.ClientSize.Height - 200;
                                pnn.iFrame = 0;
                                pnn.im = new List<Bitmap>();
                                for (k = 0; k < 3; k++)
                                {
                                    Bitmap bb = new Bitmap("Shakoosh" + (k + 1) + ".png");
                                    pnn.im.Add(bb);
                                }
                                LShakoosh.Add(pnn);
                            }
                        }
                        if (LEnemy1[i].X <= LEnemy1[i].minX)
                        {
                            LEnemy1[i].dx = 1;
                        }
                    }
                    if (LEnemy1[i].dx == 1)
                    {
                        LEnemy1[i].X += 3;
                        LEnemy1[i].iFrame = 3;
                        if (LEnemy1[i].X >= LEnemy1[i].maxX)
                        {
                            LEnemy1[i].dx = -1;
                        }
                    }
                }
                ////////////////////////////////////////////////////Enemy1 movement & Shakoosh Creation///////////////////////

                for (i = 0; i < LShakoosh.Count; i++)
                {
                    if (LShakoosh[i].dx == -1)
                    {
                        LShakoosh[i].X -= 5;
                    }
                    if (CountTick % 5 == 0)
                    {
                        if (LShakoosh[i].iFrame <= 1)
                        {
                            LShakoosh[i].iFrame += 1;
                        }
                        else
                        {
                            LShakoosh[i].dx = 0;
                            if (LShakoosh[i].Y <= this.ClientSize.Height - 130)
                            {
                                LShakoosh[i].Y += 10;
                            }
                        }
                    }
                }

                for (i = 0; i < LShakoosh.Count; i++)
                {
                    if (LShakoosh[i].Y > this.ClientSize.Height - 130)
                    {
                        LShakoosh.Remove(LShakoosh[i]);
                    }
                }
                /////////////////////////////////////////////////////Shakoosh movement///////////////////////////////////
                CActorLife pTrav = LLife[CountLife - 1];
                if (CountTick % 10 == 0)
                {
                    for (i = 0; i < LEnemy1.Count; i++)
                    {

                        if ((LHero[0].X + 50 >= LEnemy1[i].X 
                            && LHero[0].X <= (LEnemy1[i].X + 50 )
                            && LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height))
                        {
                            if (CountTick % 2 == 0)
                            {
                                if (pTrav.iFrame < 2)
                                {
                                    pTrav.iFrame += 1;
                                }
                            }
                            if (pTrav.iFrame >= 2)
                            {
                                if (CountLife > 1)
                                {
                                    CountLife--;
                                    pTrav = LLife[CountLife - 1];
                                }
                            }
                            break;
                        }
                    }

                    for (i = 0; i < LEnemy2.Count; i++)
                    {

                        if ((LHero[0].X + 100 >= LEnemy2[i].X 
                            && LHero[0].X <= (LEnemy2[i].X + 100 )
                            && LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height))
                        {
                            if (CountTick % 2 == 0)
                            {
                                if (pTrav.iFrame < 2)
                                {
                                    pTrav.iFrame += 1;
                                }
                            }
                            if (pTrav.iFrame >= 2)
                            {
                                if (CountLife > 1)
                                {
                                    CountLife--;
                                    pTrav = LLife[CountLife - 1];
                                }
                            }
                            break;
                        }
                    }

                    for (i = 0; i < LShakoosh.Count; i++)
                    {

                        if ((LHero[0].X + 100 >= LShakoosh[i].X 
                            && LHero[0].X <= (LShakoosh[i].X + 100)
                            && LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height))
                        {
                            if (CountTick % 2 == 0)
                            {
                                if (pTrav.iFrame < 2)
                                {
                                    pTrav.iFrame += 1;
                                }
                            }
                            if (pTrav.iFrame >= 2)
                            {
                                CountLife--;
                                if (CountLife > 1)
                                {
                                    pTrav = LLife[CountLife - 1];
                                }
                            }
                            break;
                        }
                    }
                }
                ///////////////////////////////////////////////////////Counting Lifes//////////////////////////////////////
                for (i = 0; i < LCoins.Count; i++)
                {
                    if (LCoins[i].iFrame > 2)
                    {
                        LCoins[i].iFrame = 0;
                    }
                    if (CountTick % 3 == 0)
                    {
                        LCoins[i].iFrame += 1;
                    }
                }
                //////////////////////////////////////Coins Movenemt/////////////////////////////////////
                for (i = 0; i < LCoins.Count; i++)
                {
                    if(LHero[0].X + 100 >= LCoins[i].X 
                            && LHero[0].X <= (LCoins[i].X + LCoins[i].im[0].Width )
                            && LHero[0].Y + 60 >= LCoins[i].Y 
                            && LHero[0].Y <= (LCoins[i].Y + 30))
                    {
                        LCoins.Remove(LCoins[i]);
                        Score += 20;
                    }
                }
                ///////////////////////////////////////Score Coins/////////////////////////////////////////////
                for (i = 0; i < LEnemy2.Count; i++)
                {
                    if (LEnemy2[i].dx == -1)
                    {
                        LEnemy2[i].X -= 5;
                        if (CountTick % 4 == 0)
                        {
                            LEnemy2[i].iFrame += 1;
                        }
                        if (LEnemy2[i].iFrame == 5)
                        {
                            LEnemy2[i].dx = 1;
                        }
                    }
                    if (LEnemy2[i].dx == 1)
                    {
                        LEnemy2[i].X += 5;
                        if (CountTick % 4 == 0)
                        {
                            LEnemy2[i].iFrame -= 1;
                        }
                        if (LEnemy2[i].iFrame == 0)
                        {
                            LEnemy2[i].dx = -1;
                        }
                    }
                }
                /////////////////////////////////////////////////////////Enemy2 Movement/////////////////////////////
                for (i = 0; i < LEnemy2.Count; i++)
                {
                    for (k = 0; k < LFire.Count; k++)
                    {
                        if(LFire[k].X + 20 >= LEnemy2[i].X 
                            && LFire[k].X <= (LEnemy2[i].X + 20)
                            && LHero[0].Y + LHero[0].im[0].Height + 60 == this.ClientSize.Height)
                        {
                            LFire.Remove(LFire[k]);
                            LEnemy2.Remove(LEnemy2[i]);
                            Score += 50;
                            break;
                        }
                    }
                }
                ////////////////////////////////////////////////Enemy2 Life////////////////////////////
                if (LElevator[0].dy == -1)
                {
                    LElevator[0].Y -= 5;
                    if (LElevator[0].Y <= 0)
                    {
                        LElevator[0].dy = 1;
                    }
                }
                if (LElevator[0].dy == 1)
                {
                    LElevator[0].Y += 5;
                    if (LElevator[0].Y >= this.ClientSize.Height-80-LElevator[0].im.Height)
                    {
                        LElevator[0].dy = -1;
                    }
                }
                ///////////////////////////////////////////////Elevator Movement//////////////////////////
                /*if (LEnemy1.Count <= 0 && LEnemy2.Count <= 0 && Score>=1000)
                {
                    FlagWinner = 1;
                }*/
            }
            
            if (CountLife <= 0)
            {
                CActorGameOver pnn1 = new CActorGameOver();
                pnn1.X = 340;
                pnn1.Y = 100;
                pnn1.im = new Bitmap("GameOver.png");
                LGameOver.Add(pnn1);
                if (GameOverW < pnn1.im.Width)
                {
                    GameOverW += 20;
                }
            }
            ///////////////////////////////////////////////////Game Over Screen///////////////////////////////////////
            if (FlagWinner == 1)
            {
                CActorWinner pnn2 = new CActorWinner();
                pnn2.X = 340;
                pnn2.Y = 100;
                pnn2.im1 = new Bitmap("UWin.png");
                pnn2.im2 = new Bitmap("Winner mega man.png");
                LWinner.Add(pnn2);
                if (WinnerWidth < pnn2.im1.Width + pnn2.im2.Width)
                {
                    WinnerWidth += 20;
                }

            }

            CountTick++;
            DrawDubb();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            int i;
            CActorBackground pnn = new CActorBackground();
            pnn.im = new Bitmap("Background.jpeg");
            pnn.xS = 0;
            pnn.yS = 0;
            pnn.xD = 0;
            pnn.yD = 0;
            LBackground.Add(pnn);

            pnn = new CActorBackground();
            pnn.im = new Bitmap("Background.jpeg");
            pnn.xS = 0;
            pnn.yS = 0;
            pnn.xD = this.ClientSize.Width;
            pnn.yD = 0;
            LBackground.Add(pnn);
            //////////////////////////////////////////////////Background Image////////////////////////////////////////

            CActorGround pnn1 = new CActorGround();
            pnn1.X = -8;
            pnn1.im = new Bitmap("floor.png");
            pnn1.im.MakeTransparent(pnn1.im.GetPixel(0, 0));
            pnn1.Y = this.ClientSize.Height-pnn1.im.Height;
            pnn1.nWholeWidth = 50;
            LGround.Add(pnn1);
            /////////////////////////////////////////////////Ground///////////////////////////////////

            CActorHero pnn2 = new CActorHero();
            pnn2.X = 50;
            pnn2.im = new List<Bitmap>();
            for (i = 0; i < 7; i++)
            {
                Bitmap bb = new Bitmap((i + 1) + ".png");
                pnn2.im.Add(bb);
            }
            pnn2.iFrame = 0;
            pnn2.Y = this.ClientSize.Height - pnn2.im[0].Height - 60;
            pnn2.dy = 0;
            LHero.Add(pnn2);
            /////////////////////////////////////////////Mega man///////////////////////////////////

            CActorTiles pnn3;
            int tempx= 500;
            for (i = 0; i < 20; i++)
            {
                pnn3 = new CActorTiles();
                pnn3.X = tempx;
                pnn3.Y = 450;
                pnn3.im = new Bitmap("Tiles.png");
                pnn3.im.MakeTransparent(pnn3.im.GetPixel(0, 0));
                LTiles.Add(pnn3);
                tempx += 1000;
            }
            ///////////////////////////////////////////////Tiles/////////////////////////////////////
            tempx = 1000;
            int k;
            CActorEnemy1 pnn4;
            for (i = 0; i < 5; i++)
            {
                pnn4 = new CActorEnemy1();
                pnn4.X = tempx;
                pnn4.minX = pnn4.X - 85;
                pnn4.maxX = pnn4.X + 80;
                pnn4.im = new List<Bitmap>();
                for (k = 0; k < 4; k++)
                {
                    Bitmap bb = new Bitmap("Enemy" + (k + 1) + ".png");
                    pnn4.im.Add(bb);
                }
                pnn4.iFrame = 0;
                pnn4.Y = this.ClientSize.Height - pnn4.im[0].Height - 60;
                pnn4.dx = -1;
                LEnemy1.Add(pnn4);
                tempx += 1500;
            }
            ///////////////////////////////////////////Enemy1 "Shakoosh"////////////////////////////////////////

            CActorLife pnn5;
            tempx = 15;
            for (i = 0; i < 3; i++)
            {
                pnn5 = new CActorLife();
                pnn5.X = tempx;
                pnn5.Y = 8;
                pnn5.im = new List<Bitmap>();
                for (k = 0; k < 3; k++)
                {
                    Bitmap bb = new Bitmap("Life" + (k + 1) + ".png");
                    pnn5.im.Add(bb);
                }
                pnn5.iFrame = 0;
                LLife.Add(pnn5);
                tempx += pnn5.im[0].Width + 10;
            }
            //////////////////////////////////////////////Lifes Creation/////////////////////////////////////

            int j;
            int tempy;
            tempx = 510;
            int RandomFrame;
            CActorCoins pnn6;
            for (i = 0; i < 5; i++)
            { 
                if (i % 2 == 0)
                {
                    tempy = 330;
                }
                else
                {
                    tempy = this.ClientSize.Height - 200;
                }
                for (j = 0; j < 3; j++)
                {
                    pnn6 = new CActorCoins();
                    pnn6.X = tempx;
                    pnn6.Y = tempy;
                    pnn6.im = new List<Bitmap>();
                    for (k = 0; k < 4; k++)
                    {
                        Bitmap bb = new Bitmap("Coin" + (k + 1) + ".png");
                        pnn6.im.Add(bb);
                    }
                    RandomFrame = RR.Next(3);
                    if (RandomFrame == 0)
                    {
                        pnn6.iFrame = 0;
                    }
                    if (RandomFrame == 1)
                    {
                        pnn6.iFrame = 1;
                    }
                    if (RandomFrame == 2)
                    {
                        pnn6.iFrame = 2;
                    }
                    LCoins.Add(pnn6);
                    tempx += 40;
                    tempy -= pnn6.im[0].Width - 15;
                }
                for (j = 0; j < 3; j++)
                {
                    pnn6 = new CActorCoins();
                    pnn6.X = tempx + 20;
                    pnn6.im = new List<Bitmap>();
                    for (k = 0; k < 4; k++)
                    {
                        Bitmap bb = new Bitmap("Coin" + (k + 1) + ".png");
                        pnn6.im.Add(bb);
                    }
                    pnn6.Y = tempy + pnn6.im[0].Width - 15;
                    RandomFrame = RR.Next(3);
                    if (RandomFrame == 0)
                    {
                        pnn6.iFrame = 0;
                    }
                    if (RandomFrame == 1)
                    {
                        pnn6.iFrame = 1;
                    }
                    if (RandomFrame == 2)
                    {
                        pnn6.iFrame = 2;
                    }
                    LCoins.Add(pnn6);
                    tempx += 40;
                    tempy += pnn6.im[0].Width - 15;
                }
                tempx += 760;
            }
            ////////////////////////////////////////////////Coins Creation//////////////////////////////////
            tempx = 1500;
            CActorEnemy2 pnn7;
            for (i = 0; i < 6; i++)
            {
                pnn7 = new CActorEnemy2();
                pnn7.X = tempx;
                pnn7.im = new List<Bitmap>();
                for (k = 0; k < 5; k++)
                {
                    Bitmap bb = new Bitmap("Enem" + (k + 1) + ".png");
                    pnn7.im.Add(bb);
                }
                pnn7.iFrame = 0;
                pnn7.Y = this.ClientSize.Height - pnn7.im[0].Height - 70;
                pnn7.dx = -1;
                LEnemy2.Add(pnn7);
                tempx += 1000;
            }
            /////////////////////////////////////////////////Enemy2 Creation//////////////////////////////////

            CActorRectMode pnn8 = new CActorRectMode();
            pnn8.X = this.ClientSize.Width - 315;
            pnn8.Y = 20;
            pnn8.im = new Bitmap("Mode.png");
            pnn8.Flag = 1;
            LRect.Add(pnn8);
            pnn8 = new CActorRectMode();
            pnn8.X = this.ClientSize.Width - 315;
            pnn8.Y = 20 + LRect[0].im.Height;
            pnn8.im = new Bitmap("Night.png");
            pnn8.Flag = 0;
            LRect.Add(pnn8);
            pnn8 = new CActorRectMode();
            pnn8.X = this.ClientSize.Width - 315;
            pnn8.Y = 26 + (LRect[0].im.Height*2);
            pnn8.im = new Bitmap("Day.png");
            pnn8.Flag = 0;
            LRect.Add(pnn8);
            /////////////////////////////////////////////////////Mode Creation////////////////////////////////

            CActorElevator pnn9 = new CActorElevator();
            pnn9.X = 250 * 8;
            pnn9.im = new Bitmap("elevator.png");
            pnn9.Y = this.ClientSize.Height - 80 - pnn9.im.Height;
            pnn9.dy = -1;
            LElevator.Add(pnn9);

        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (CountLife != 0 && FlagWinner == 0)
                {
                    if (e.X >= LRect[0].X && e.X <= (LRect[0].X + LRect[0].im.Width)
                        && e.Y >= LRect[0].Y && e.Y <= (LRect[0].Y + LRect[0].im.Height))
                    {
                        LRect[1].Flag = 1;
                        LRect[2].Flag = 1;

                    }
                    //MessageBox.Show(LRect[0].X + "," + LRect[0].Y + "," + LRect[0].im.Width + "," + LRect[0].im.Height + "," + e.X + "," + e.Y);
                    if (e.X >= LRect[1].X && e.X <= (LRect[1].X + LRect[1].im.Width)
                        && e.Y >= LRect[1].Y && e.Y <= (LRect[1].Y + LRect[1].im.Height))
                    {
                        LBackground[0].im = new Bitmap("Background 2.jpg");
                        LBackground[1].im = new Bitmap("Background 2.jpg");
                        LRect[1].Flag = 0;
                        LRect[2].Flag = 0;

                    }

                    if (e.X >= LRect[2].X && e.X <= (LRect[2].X + LRect[2].im.Width)
                        && e.Y >= LRect[2].Y && e.Y <= (LRect[2].Y + LRect[2].im.Height))
                    {
                        LBackground[0].im = new Bitmap("Background.jpeg");
                        LBackground[1].im = new Bitmap("Background.jpeg");
                        LRect[1].Flag = 0;
                        LRect[2].Flag = 0;

                    }
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (CountLife != 0 && FlagWinner == 0)
                    {
                        FlagRightH = 1;
                    }
                    break;

                case Keys.Left:
                    if (CountLife != 0 && FlagWinner == 0)
                    {
                        FlagLeftH = 1;
                    }
                    break;

                case Keys.Up:
                    if (CountLife != 0 && FlagWinner == 0)
                    {
                        FlagUpH = 1;
                        Countmove = 0;
                        LHero[0].dy = -1;
                        LHero[0].iFrame = 4;
                    }
                    break;

                case Keys.Space:
                    if (CountLife != 0 && FlagWinner == 0)
                    {
                        FlagFire = 1;
                    }
                    break;
                case Keys.Enter:
                    if (LHero[0].X >= LElevator[0].X + 20 && LHero[0].X <= LElevator[0].X + LElevator[0].im.Width
                        && LHero[0].Y >= LElevator[0].Y && LHero[0].Y <= LElevator[0].Y + LElevator[0].im.Height)
                    {
                        LHero[0].Hide = 1;
                        FlagWinner = 1;
                    }
                    break;
            }
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FlagLeftH = 0;
                    break;
                case Keys.Right:
                    FlagRightH = 0;
                    break;
                case Keys.Space:
                    FlagFire = 0;
                    break;
            }
        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.SkyBlue);
            int i;
            Rectangle rcD;
            Rectangle rcS;
            for (i = 0; i < LBackground.Count; i++)
            {
                rcD = new Rectangle(LBackground[i].xD, LBackground[i].yD, this.ClientSize.Width , this.ClientSize.Height);
                rcS = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
                g2.DrawImage(LBackground[i].im, rcD, rcS, GraphicsUnit.Pixel);
            }

            LGround[0].DrawYourSelf(g2);

            Pen P = new Pen(Color.Black, 4);
            for (i = 0; i < LElevator.Count; i++)
            {
                g2.DrawImage(LElevator[i].im, LElevator[i].X, LElevator[i].Y);
                g2.DrawLine(P, LElevator[i].X + 126, 0, LElevator[i].X + 126, LElevator[i].Y);
            }

            int j;

            if (LHero[0].Hide == 0)
            {
                j = LHero[0].iFrame;
                g2.DrawImage(LHero[0].im[j], LHero[0].X, LHero[0].Y);
            }

            for (i = 0; i < LTiles.Count; i++)
            {
                g2.DrawImage(LTiles[i].im, LTiles[i].X, LTiles[i].Y);
            }

            for (i = 0; i < LEnemy1.Count; i++)
            {
                j = LEnemy1[i].iFrame;
                g2.DrawImage(LEnemy1[i].im[j], LEnemy1[i].X , LEnemy1[i].Y);
            }

            for (i = 0; i < LShakoosh.Count; i++)
            {
                j = LShakoosh[i].iFrame;
                g2.DrawImage(LShakoosh[i].im[j], LShakoosh[i].X , LShakoosh[i].Y);
            }

            for (i = 0; i < LLife.Count; i++)
            {
                j = LLife[i].iFrame;
                g2.DrawImage(LLife[i].im[j], LLife[i].X , LLife[i].Y);
            }

            for (i = 0; i < LFire.Count; i++)
            {
                j = LFire[i].iFrame;
                g2.DrawImage(LFire[i].im[j], LFire[i].X, LFire[i].Y);
            }

            for (i = 0; i < LGameOver.Count; i++)
            {
                rcD = new Rectangle(LGameOver[i].X, LGameOver[i].Y, GameOverW, LGameOver[i].im.Height);
                rcS = new Rectangle(0, 0, GameOverW, LGameOver[i].im.Height);
                g2.DrawImage(LGameOver[i].im, rcD, rcS, GraphicsUnit.Pixel);
            }

            for (i = 0; i < LWinner.Count; i++)
            {
                rcD = new Rectangle(LWinner[i].X, LWinner[i].Y, WinnerWidth, LWinner[i].im1.Height);
                rcS = new Rectangle(0, 0, WinnerWidth, LWinner[i].im1.Height);
                g2.DrawImage(LWinner[i].im1, rcD, rcS, GraphicsUnit.Pixel);

                rcD = new Rectangle(LWinner[i].X + (LWinner[i].im1.Width - 30 ), LWinner[i].Y - 30, WinnerWidth, LWinner[i].im2.Height);
                rcS = new Rectangle(0, 0, WinnerWidth, LWinner[i].im2.Height);
                g2.DrawImage(LWinner[i].im2, rcD, rcS, GraphicsUnit.Pixel);
            }

            Font Fnt = new Font("Bernard MT Condensed", 30);
            SolidBrush Brsh = new SolidBrush(Color.Red);
            g2.DrawString("Score: " + Score, Fnt, Brsh,this.ClientSize.Width-200, 20);

            for (i = 0; i < LCoins.Count; i++)
            {
                j = LCoins[i].iFrame;
                g2.DrawImage(LCoins[i].im[j], LCoins[i].X, LCoins[i].Y);
            }

            for (i = 0; i < LEnemy2.Count; i++)
            {
                j = LEnemy2[i].iFrame;
                g2.DrawImage(LEnemy2[i].im[j], LEnemy2[i].X , LEnemy2[i].Y);
            }

            for (i = 0; i < LRect.Count; i++)
            {
                if (LRect[i].Flag == 1)
                {
                    g2.DrawImage(LRect[i].im, LRect[i].X, LRect[i].Y);
                    g2.DrawRectangle(Pens.Red, LRect[i].X, LRect[i].Y, LRect[i].im.Width, LRect[i].im.Height);
                }
            }
            
        }

        void DrawDubb()
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            Graphics g = this.CreateGraphics();
            g.DrawImage(off, 0, 0);
        }
    }
}
