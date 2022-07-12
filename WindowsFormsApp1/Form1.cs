using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ctrl+k ctrl+d ile satırlar düzeltilir
        //öylesine bir tekrar windows form uygulaması butonlarla dama tahtası yapma
        //class ın değer ataması kullanıldı
        private void Form1_Load(object sender, EventArgs e)
        {
            Button[,] buttons = new Button[16,16];
            int top=15;
            int left=15;
            for (int i = 0; i < buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j < buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Top = top,
                        Left = left,
                    };
                    if ((i+j)%2==0)
                    {
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }
                    left += 50;
                    this.Controls.Add(buttons[i,j]);
                }
                left = 15;
                top += 50;
            }

        }
    }
}
