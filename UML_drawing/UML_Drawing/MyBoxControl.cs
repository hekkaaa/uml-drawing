using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Helpers;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library
{
    public partial class MyBoxControl : UserControl
    {
        Handler handler;
        //выделенная фигура
        Component selectedFigure = null;
        //фигура или маркер, который тащится мышью
        Component draggedFigure = null;
        private Control _control;

        List<Marker> markers = new List<Marker>();
        Pen selectRectPen;

        public MyBoxControl()
        {
            InitializeComponent();

            AutoScroll = true;

            DoubleBuffered = true;
            ResizeRedraw = true;

            selectRectPen = new Pen(Color.Red, 1f);
            selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public event EventHandler SelectedChanged;

        public Component SelectedFigure
        {
            get { return selectedFigure; }
            set
            {
                selectedFigure = value;
                CreateMarkers();
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }


        // Тут типа все элементики в списочке
        public Handler Handler
        {
            get { return handler; }
            set
            {
                handler = value;
                selectedFigure = null;
                draggedFigure = null;
                markers.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
            //selectedFigure = null;
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (handler != null)
            {
                foreach (Component f in handler.ComponentsInProj)
                    if (f is Line)
                        f.Draw(gr);
                foreach (Component f in handler.ComponentsInProj)
                    if (f is SimpleRectangle)
                        f.Draw(gr);
            }

            // Это выделение блока
            if (selectedFigure is SimpleRectangle)
            {
                SimpleRectangle figure = selectedFigure as SimpleRectangle;
                RectangleF bounds = figure.Bounds;
                gr.DrawRectangle(selectRectPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            }
            //рисуем маркеры
            foreach (Marker m in markers)
                try
                {
                    m.Draw(gr);
                }
                catch {; }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point location = e.Location;
            // location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);

            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                draggedFigure = FindFigureByPoint(location);
                if (!(draggedFigure is Marker))
                {
                    selectedFigure = draggedFigure;
                    CreateMarkers();
                }
                else
                {
                    Cursor.Hide();
                }

                startDragPoint = location;
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }

        public void CreateMarkers()
        {
            markers = new List<Marker>();
            if (selectedFigure != null)
            {
                foreach (Marker m in selectedFigure.GetMarkers(handler))
                    markers.Add(m);
                UpdateMarkers();
            }
        }

        private void UpdateMarkers()
        {
            foreach (Marker m in markers)
                if (draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        Point startDragPoint;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            // location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (draggedFigure != null && (draggedFigure is SimpleRectangle))
                {
                    (draggedFigure as SimpleRectangle).Offset(location.X - startDragPoint.X, location.Y - startDragPoint.Y);
                    UpdateMarkers();
                    Invalidate();
                    CalcAutoScrollPosition();
                }
            }
            else
            {
                Component figure = FindFigureByPoint(location);
                if (figure is Marker)
                {
                    Cursor = (figure as Marker).Cursor;
                    if (toolTip1.GetToolTip(this) != (figure as Marker).ToolTip)
                        toolTip1.SetToolTip(this, (figure as Marker).ToolTip);
                }
                else
                {
                    if (figure != null)
                        Cursor = Cursors.Hand;
                    else
                        Cursor = Cursors.Default;

                    if (toolTip1.GetToolTip(this) != null)
                        toolTip1.SetToolTip(this, null);
                }
            }

            startDragPoint = location;
        }

        private void CalcAutoScrollPosition()
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            // Перебираем все фигуры, ищем максимальные координаты
            foreach (Component f in handler.ComponentsInProj)
                if (f != null && f is SimpleRectangle)
                    r = RectangleF.Union(r, (f as SimpleRectangle).Bounds);

            Size size = new Size((int)r.Width, (int)r.Height);
            if (size != AutoScrollMinSize)
                AutoScrollMinSize = size;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor.Show();
            draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        // Поиск фигуры по точке
        public Component FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            for (int i = markers.Count - 1; i >= 0; i--)
                if (markers[i].PointIsInside(p))
                    return markers[i];
            //затем ищем среди плоских фигур
            for (int i = handler.ComponentsInProj.Count - 1; i >= 0; i--)
                if (handler.ComponentsInProj[i] is SimpleRectangle && handler.ComponentsInProj[i].PointIsInside(p))
                    return handler.ComponentsInProj[i];
            //затем ищем среди линий
            for (int i = handler.ComponentsInProj.Count - 1; i >= 0; i--)
                if (handler.ComponentsInProj[i] is Line && handler.ComponentsInProj[i].PointIsInside(p))
                    return handler.ComponentsInProj[i];
            return null;
        }

        public void AddFigure<FigureType>(PointF location) where FigureType : SimpleRectangle, new()
        {
            
            FigureType figure = new FigureType();
            figure.Location = location;
            if (handler != null)
                handler.ComponentsInProj.Add(figure);
            Invalidate();
        }

        public void SelectedBringToFront()
        {
            if (selectedFigure != null)
            {
                handler.ComponentsInProj.Remove(selectedFigure);
                handler.ComponentsInProj.Add(selectedFigure);
                Invalidate();
            }
        }


        public void SelectedSendToBack()
        {
            if (selectedFigure != null)
            {
                handler.ComponentsInProj.Remove(selectedFigure);
                handler.ComponentsInProj.Insert(0, selectedFigure);
                Invalidate();
            }
        }

        public void SelectedBeginEditText(string text)
        {
            if (selectedFigure != null && (selectedFigure is SimpleRectangle))
            {
                SimpleRectangle figure = (selectedFigure as RectangleComponent);
                TextBox textBox = new TextBox();
                textBox.Parent = this;
                textBox.SetBounds(figure.TextBounds.Left, figure.TextBounds.Top, figure.TextBounds.Width, figure.TextBounds.Height);
                textBox.Text = text;
                //textBox.Text = figure.Text.TextFields;
                textBox.Multiline = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                (selectedFigure as SimpleRectangle).Text.TextFields = textBox.Text;
                textBox.Focus();
                //textBox.LostFocus += new EventHandler(textBox_LostFocus);
            }
        }


        public void SelectedAddLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SimpleRectangle))
            {
                Line line = new Line();
                line.From = (selectedFigure as SimpleRectangle);
                EndLineMarker marker = new EndLineMarker(handler, 1);
                marker.Location = line.From.Location;
                marker.Location = marker.Location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                handler.ComponentsInProj.Add(line);
                selectedFigure = line;
                CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedAddDashLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SimpleRectangle))
            {
                AssociationArrow line = new AssociationArrow();
                line.From = (selectedFigure as SimpleRectangle);
                EndLineMarker marker = new EndLineMarker(handler, 1);
                marker.Location = line.From.Location;
                marker.Location = marker.Location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                handler.ComponentsInProj.Add(line);
                selectedFigure = line;
                CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedDelete()
        {
            if (selectedFigure != null)
            {
                handler.ComponentsInProj.Remove(selectedFigure);
                selectedFigure = null;
                draggedFigure = null;
                CreateMarkers();

                Invalidate();
            }
        }

        //public Bitmap GetImage()
        //{
        //    selectedFigure = null;
        //    draggedFigure = null;
        //    CreateMarkers();

        //    Bitmap bmp = new Bitmap(Bounds.Width, Bounds.Height);
        //    DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

        //    return bmp;
        //}


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (SelectedFigure == null || !(SelectedFigure is SimpleRectangle))
                return;
            int dx = 0;
            int dy = 0;
            if (e.KeyData == Keys.Right)
                dx = +1;
            if (e.KeyData == Keys.Left)
                dx = -1;
            if (e.KeyData == Keys.Up)
                dy = -1;
            if (e.KeyData == Keys.Down)
                dy = +1;

            if (e.KeyData == (Keys.Delete))
                SelectedDelete();
            
            if (e.KeyData == (Keys.Right | Keys.Shift))
                dx = +15;
            if (e.KeyData == (Keys.Left | Keys.Shift))
                dx = -15;
            if (e.KeyData == (Keys.Up | Keys.Shift))
                dy = -15;
            if (e.KeyData == (Keys.Down | Keys.Shift))
                dy = +15;

            if (dx != 0 || dy != 0)
            {
                (SelectedFigure as SimpleRectangle).Offset(dx, dy);
                UpdateMarkers();
                CalcAutoScrollPosition();
                Invalidate();
            }
        }
    }
}
