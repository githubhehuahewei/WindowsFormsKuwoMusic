using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsKuwoMusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        ///  移动窗口
        /// </summary>
        Point pointMouseDown;
        Point pointMouseMove;
        bool isMoving = false;//设置一开关，按住（mousedown）窗口时才打开
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            pointMouseDown = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                pointMouseMove = e.Location;
                this.Location = new Point(this.Location.X/*窗口原位置*/
                    + (pointMouseMove.X - pointMouseDown.X/*变化的x坐标*/),
                    this.Location.Y + (pointMouseMove.Y - pointMouseDown.Y));
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;//松开鼠标后移动程序关闭
        }




        /// <summary>
        ///  选取歌曲文件
        /// </summary>



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            string fileName = ofd.FileName;


            //
            axWindowsMediaPlayer1.URL = fileName;
            //url后是文件地址
            axWindowsMediaPlayer1.Ctlcontrols.stop ();
        }


        /// <summary>
        /// 切换播放图片
        /// 
        /// </summary>
        /// 

        bool isPlaying = false;
        private void pictureplay_Click(object sender, EventArgs e)
        {
            isPlaying = !isPlaying;
            if (isPlaying)
            {
                pictureplay.BackgroundImage = Properties.Resources.pause_circle_o;

                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                pictureplay.BackgroundImage = Properties.Resources.play_circle_o;//三角形

                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }



        /// <summary>
        ///  载入歌词文件
        /// </summary>

        private void butLoadLyricc_Click(object sender, EventArgs e)
        {
            //打开文件，读取歌词
            Encoding encode = Encoding.GetEncoding("GB2312");//适应中文码

            //打开文件，读取歌词
            FileStream fs = new FileStream("陈一发儿-童话镇.lrc", FileMode.Open);
            StreamReader sr = new StreamReader(fs, encode);
            string s = sr.ReadLine();
            int xPos = 200;
            int yPos = 50;

            while (s != null)
            {
                s = sr.ReadLine();

                if (s == "")
                {
                    continue;
                }

                Label lbl = new Label();
                lbl.Font = new Font("微软雅黑", 12);
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.White;
                lbl.Location = new Point(xPos, yPos);
                lbl.Width = 200;
                lbl.Text = s;

                this.Controls.Add(lbl);

                yPos += 30;
            }
        }
       
    }
}
