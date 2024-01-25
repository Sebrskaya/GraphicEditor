using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class Form1 : Form
    {
        bool isDown = false;
        Model model;
        Controller controller;
        
        
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            controller = new Controller(model);
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            controller.PaintController.SetPort(Handle);
            controller.PaintController.Clear();
            Controls.Add(model.LayersList);
            model.LayersList.Location = new Point(678, 422);
            model.LayersList.Size = new Size(184, 134);
        }

        private void ButtonLine_Click(object sender, EventArgs e)
        {
            controller.Action.StartCreate(ObjectType.Line);
            controller.Settings.ObjectStyleSettings.PenSettings.LineColor = Color.LightGreen;
            controller.Settings.ObjectStyleSettings.PenSettings.LineWidth = 10;
            controller.Settings.SetObjectStyleSettings();

        }

        private void ButtonRectangle_Click(object sender, EventArgs e)
        {
            controller.Action.StartCreate(ObjectType.Rectangle);
            controller.Settings.ObjectStyleSettings.PenSettings.LineColor = Color.DarkOrange;
            controller.Settings.ObjectStyleSettings.PenSettings.LineWidth = 20;
            controller.Settings.ObjectStyleSettings.BrushSettings.BrushColor = Color.Orange;
            controller.Settings.SetObjectStyleSettings();
        }

        private void ButtonEllipse_Click(object sender, EventArgs e)
        {
            controller.Action.StartCreate(ObjectType.Ellipse);
            controller.Settings.ObjectStyleSettings.PenSettings.LineColor = Color.DeepSkyBlue;
            controller.Settings.ObjectStyleSettings.PenSettings.LineWidth = 13;
            controller.Settings.ObjectStyleSettings.BrushSettings.BrushColor = Color.SkyBlue;
            controller.Settings.SetObjectStyleSettings();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.None)
            {
                controller.Action.MouseDown(e.X, e.Y);
                isDown = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isDown)
            {
                controller.Action.MouseMove(e.X, e.Y);
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                controller.Action.ShiftMouseUp(e.X, e.Y);
                return;
            }
            controller.Action.MouseUp(e.X, e.Y);
            controller.PaintController.Refresh();
            isDown = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) controller.Action.Esc();
            if (e.KeyCode == Keys.Delete) controller.Action.Del();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            controller.Action.Group();
        }

        private void UnGroupButton_Click(object sender, EventArgs e)
        {
            controller.Action.Ungroup();
        }

        private void UpLayerButton_Click(object sender, EventArgs e)
        {
            controller.Action.UpLayer();
        }

        private void DownLayerButton_Click(object sender, EventArgs e)
        {
            controller.Action.DownLayer();
        }

        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            controller.Action.AddLayer();
        }

        private void DeleteLayerButton_Click(object sender, EventArgs e)
        {
            controller.Action.DeleteLayer();
        }

        private void VisibilityOffButton_Click(object sender, EventArgs e)
        {
            controller.Action.VisibilityOff();
        }

        private void VisibilityOnButton_Click(object sender, EventArgs e)
        {
            controller.Action.VisibilityOn();
        }

    }
}
