using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Boolean goleft, goright, jumping, isgameover;

        int jumpspeed;
        int force;
        int score=0;
        int playerspeed = 10;



        int horizontalspeed = 5;

        int verticalspeed = 3;

        int enemy1speed = 5;

        int enemy2speed = 3;






        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void score_Click(object sender, EventArgs e)
        {

        }

        private void maingametimerevent(object sender, EventArgs e)
        {
            textscore.Text = "score:" + score;
            player.Top += jumpspeed;
            if (goleft == true)
            {
                player.Left -= playerspeed;
            }
            if (goright == true)
            {
                player.Left += playerspeed;
            }
            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpspeed = -8;
// 108111108
                force -= 1;
            }
            else 
            {
                jumpspeed = 10;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                { 
                    if ((string)x.Tag == "platform") 
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                            if ((string)x.Name == "horizontalplatform" && goleft==false ||(string)x.Name== "horizontalplatform" && goright==false)
                            {
                                player.Left -= horizontalspeed;
                            }



                        }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "money")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible==true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gametimer.Stop();
                            isgameover = true;
                            textscore.Text = "score:" + score + Environment.NewLine + "GAME OVER";
                        }
                    }
                }
            }

            horizontalplatform.Left -= horizontalspeed;
            if (horizontalplatform.Left < 0 || horizontalplatform.Left + horizontalplatform.Width > this.ClientSize.Width)
            {
                horizontalspeed = -horizontalspeed;
            }
            verticalplatform.Top += verticalspeed;
            if (verticalplatform.Top<195 || verticalplatform.Top>581) 
            {
                verticalspeed = -verticalspeed;
            }
            enemy1.Left -= enemy1speed;
            if (enemy1.Left < pictureBox3.Left || enemy1.Left + enemy1.Width > pictureBox3.Left+pictureBox3.Width) 
            {
                enemy1speed = -enemy1speed;
            }
            enemy2.Left += enemy2speed;

            if (enemy2.Left < pictureBox8.Left || enemy2.Left + enemy2.Width > pictureBox8.Left + pictureBox8.Width)
            {
                enemy2speed = -enemy2speed;
            }

            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gametimer.Stop();
                isgameover = true;
                textscore.Text = "score" + score + Environment.NewLine + "loser!";
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && score == 17)
            {
                gametimer.Stop();
                isgameover = true;
                textscore.Text = "score" + score + Environment.NewLine + "win!";
            }
            else 
            {
                textscore.Text = "score" + score + Environment.NewLine + "蒐集硬幣!";
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Left)  
            {
                goleft = true; 
            } 
            if (e.KeyCode == Keys.Right) 
            {
                goright = true; 
            }
            if (e.KeyCode == Keys.Space && jumping ==false)
                 
            {
                jumping= true; 
            }
            

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (jumping == true)

            {
                jumping = false;
            }
            if (e.KeyCode == Keys.Enter && isgameover == true)
            {
                restartgame();

            }

        }
        private void restartgame()
        {
            jumping = false;
            goleft = false;
            goright = false;
            isgameover = false;
            score = 0;
            textscore.Text = "score:" + score;
            foreach (Control x in this.Controls) 
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            
            }
            player.Left = 72;
            player.Top = 656;
            enemy1.Left = 471;
            enemy2.Left = 360;
            horizontalplatform.Left = 275;
            verticalplatform.Top = 581;
            gametimer.Start();

        }
    }
}
