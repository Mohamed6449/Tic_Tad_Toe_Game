using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tad_Toe_Game.Properties;

namespace Tic_Tad_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // البحث عن جميع PictureBox داخل الـ GroupBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is PictureBox)
                {
                    ctrl.MouseEnter += PictureBox_MouseEnter;
                    ctrl.MouseLeave += PictureBox_MouseLeave;
                }
            }
        }
        PictureBox p = new PictureBox();
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                p.BackColor = pic.BackColor;
                pic.BackColor = Color.Black; // تغيير الخلفية إلى الأسود
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                pic.BackColor = p.BackColor; // إرجاع الخلفية للوضع الطبيعي
            }
        }
        private void ChangBackGround(PictureBox n1, PictureBox n2, PictureBox n3)
        {
            n1.BackColor = Color.Yellow; n2.BackColor = Color.Yellow; n3.BackColor = Color.Yellow;
            p.BackColor = Color.Yellow;
            isFinshed = true;
            label10.Text = "GameOver";
            if (picture == "X")
            {
                label8.Text = "Player2";
            }
            else
            {
                label8.Text = "Nour";
            }
        }
        private void CheckWin()
        {
            if (pic1.Tag == pic2.Tag && pic1.Tag == pic3.Tag && pic1.Tag.ToString() != "Question") {

                ChangBackGround(pic1, pic2, pic3);
            }
            if (pic1.Tag == pic7.Tag && pic1.Tag == pic8.Tag && pic1.Tag.ToString() != "Question")
            {
                ChangBackGround(pic1, pic8, pic7);
            }

            if (pic2.Tag == pic9.Tag && pic2.Tag == pic6.Tag && pic2.Tag.ToString() != "Question")
            {
                ChangBackGround(pic2, pic6, pic9);
            }
            if (pic3.Tag == pic4.Tag && pic3.Tag == pic5.Tag && pic3.Tag.ToString() != "Question")
            {
                ChangBackGround(pic3, pic4, pic5);
            }

            if (pic5.Tag == pic6.Tag && pic5.Tag == pic7.Tag && pic5.Tag.ToString() != "Question")
            {
                ChangBackGround(pic6, pic5, pic7);
            }


            if (pic4.Tag == pic9.Tag && pic4.Tag == pic8.Tag && pic4.Tag.ToString() != "Question")
            {
                ChangBackGround(pic4, pic8, pic9);
            }

            if (pic1.Tag == pic9.Tag && pic1.Tag == pic5.Tag && pic1.Tag.ToString() != "Question")
            {
                ChangBackGround(pic1, pic5, pic9);
            }
            if (pic7.Tag == pic9.Tag && pic7.Tag == pic3.Tag && pic7.Tag.ToString() != "Question")
            {
                ChangBackGround(pic3, pic9, pic7);
            }

        }
        string picture = "X";
        byte counter = 0;

        bool isFinshed = false;

        private void _ChangePicture(PictureBox pictureBox)
        {
            if (!isFinshed)
            {
                if (pictureBox.Tag.ToString() == "Question")
                {
                    counter++;
                    if (picture == "X")
                    {
                        pictureBox.Image = Resources.X;

                        pictureBox.Tag = "X";
                        picture = "O";
                        label10.Text = "Player2";
                    }
                    else
                    {
                        pictureBox.Image = Resources.O;

                        pictureBox.Tag = "O";
                        picture = "X";
                        label10.Text = "Nour";
                    }
                    CheckWin();
                    if (counter == 9)
                    {
                        if (!isFinshed)
                        {
                            label10.Text = "GameOver";
                            label8.Text = "Draw";

                        }
                        isFinshed = true;
                    }

                }
                else
                {
                    MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            pic1.Image = Resources.question_mark_96;
            pic2.Image = Resources.question_mark_96;
            pic3.Image = Resources.question_mark_96;
            pic4.Image = Resources.question_mark_96;
            pic5.Image = Resources.question_mark_96;
            pic6.Image = Resources.question_mark_96;
            pic7.Image = Resources.question_mark_96;
            pic8.Image = Resources.question_mark_96;
            pic9.Image = Resources.question_mark_96;

            pic1.Tag = "Question";
            pic2.Tag = "Question";
            pic3.Tag = "Question";
            pic4.Tag = "Question";
            pic5.Tag = "Question";
            pic6.Tag = "Question";
            pic7.Tag = "Question";
            pic8.Tag = "Question";
            pic9.Tag = "Question";

            pic1.BackColor = Color.Black;
            pic2.BackColor = Color.Black;
            pic3.BackColor = Color.Black;
            pic4.BackColor = Color.Black;
            pic5.BackColor = Color.Black;
            pic6.BackColor = Color.Black;
            pic7.BackColor = Color.Black;
            pic8.BackColor = Color.Black;
            pic9.BackColor = Color.Black;

            picture = "X";
            counter = 0;

            isFinshed = false;
            label8.Text = "In process";
            label10.Text = "Nour";
        }

        private void pic_Click(object sender, EventArgs e)
        {
            _ChangePicture((PictureBox)sender);

        }
    }
}
