using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.View
{
    public partial class StudingForm : Form
    {
        public static int CurrentSlide = 0;
        public StudingForm()
        {
            InitializeComponent();
            MakeFormBorders();
            KeyDown += OnKeyDown;
            MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentSlide != ViewGraphics.Slides.Length)
                this.BackgroundImage = ViewGraphics.Slides[CurrentSlide];
            else
            {
                CurrentSlide = 0;
                var form = Application.OpenForms[0];
                form.StartPosition = FormStartPosition.Manual;
                form.Top = Top;
                form.Left = Left;
                form.Show();
                Close();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            CurrentSlide++;
            if(CurrentSlide != ViewGraphics.Slides.Length)
                this.BackgroundImage = ViewGraphics.Slides[CurrentSlide];
            else
            {
                CurrentSlide = 0;
                var form = Application.OpenForms[0];
                form.StartPosition = FormStartPosition.Manual;
                form.Top = Top;
                form.Left = Left;
                form.Show();
                Close();
            }
        }

        public void MakeFormBorders()
        {
            BackgroundImage = ViewGraphics.Slides[CurrentSlide];
            Height = ViewGraphics.Slides[CurrentSlide].Height+ 20;
            Width = ViewGraphics.Slides[CurrentSlide].Width - 5;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}
