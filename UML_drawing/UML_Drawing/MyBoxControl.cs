using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Helpers;
using UML_Logic_Library.Markers;
using UML_Logic_Library.StructuralEntities;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing
{
    public sealed partial class MyBoxControl : UserControl
    {
        private Handler _handler;
        //выделенная фигура
        private Component _selectedFigure = null;
        //фигура или маркер, который тащится мышью
        private Component _draggedFigure = null;

        public List<Marker> Markers = new List<Marker>();
        private readonly Pen _selectRectPen;
        private Point _startDragPoint;

        public MyBoxControl()
        {
            InitializeComponent();

            AutoScroll = true;

            DoubleBuffered = true;
            ResizeRedraw = true;

            _selectRectPen = new Pen(Color.Red, 1f);
            _selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public event EventHandler SelectedChanged;

        public Component SelectedFigure
        {
            get { return _selectedFigure; }
            set
            {
                _selectedFigure = value;
                CreateMarkers();
                Invalidate();
                SelectedChanged?.Invoke(this, new EventArgs());
            }
        }


        // Тут типа все элементики в списочке
        public Handler Handler
        {
            get { return _handler; }
            set
            {
                _handler = value;
                _selectedFigure = null;
                _draggedFigure = null;
                Markers.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; 
            gr.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (_handler != null)
            {
                foreach (Component f in _handler.ComponentsInProj)
                    if (f is Arrows)
                        f.Draw(gr);
                foreach (Component f in _handler.ComponentsInProj)
                    if (f is SimpleRectangle)
                        f.Draw(gr);
            }

            // Это выделение блока
            if (_selectedFigure is SimpleRectangle)
            {
                if (_selectedFigure is SimpleRectangle figure)
                {
                    RectangleF bounds = figure.Bounds;
                    gr.DrawRectangle(
                        _selectRectPen, bounds.Left - 2, 
                        bounds.Top - 2, 
                        bounds.Width + 4, 
                        bounds.Height + 4
                    );
                }
            }
            //рисуем маркеры
            foreach (Marker m in Markers)
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
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);

            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _draggedFigure = FindFigureByPoint(location);
                if (!(_draggedFigure is Marker))
                {
                    _selectedFigure = _draggedFigure;
                    CreateMarkers();
                }
                else
                {
                    Cursor.Hide();
                }

                _startDragPoint = location;
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }

        private void CreateMarkers()
        {
            Markers = new List<Marker>();
            if (_selectedFigure != null)
            {
                foreach (Marker m in _selectedFigure.GetMarkers(_handler))
                    Markers.Add(m);
                UpdateMarkers();
            }
        }

        private void UpdateMarkers()
        {
            foreach (Marker m in Markers)
                if (_draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_draggedFigure is SimpleRectangle rectangle)
                {
                    rectangle.Offset(location.X - _startDragPoint.X, 
                        location.Y - _startDragPoint.Y);
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

            _startDragPoint = location;
        }

        private void CalcAutoScrollPosition()
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            
            // Перебираем все фигуры, ищем максимальные координаты
            
            foreach (Component f in _handler.ComponentsInProj)
                if (f != null && f is SimpleRectangle)
                    r = RectangleF.Union(r, (f as SimpleRectangle).Bounds);

            Size size = new Size((int)r.Width + 100, (int)r.Height + 100);
            if (size != AutoScrollMinSize)
                AutoScrollMinSize = size;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor.Show();
            _draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        // Поиск фигуры по точке
        public Component FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            for (int i = Markers.Count - 1; i >= 0; i--)
                if (Markers[i].PointIsInside(p))
                    return Markers[i];
            //затем ищем среди плоских фигур
            for (int i = _handler.ComponentsInProj.Count - 1; i >= 0; i--)
                if (_handler.ComponentsInProj[i] is SimpleRectangle && _handler.ComponentsInProj[i].PointIsInside(p))
                    return _handler.ComponentsInProj[i];
            //затем ищем среди линий
            for (int i = _handler.ComponentsInProj.Count - 1; i >= 0; i--)
                if (_handler.ComponentsInProj[i] is Arrows && _handler.ComponentsInProj[i].PointIsInside(p))
                    return _handler.ComponentsInProj[i];
            return null;
        }
        
        public void AddFigure<FigureType>(PointF location) where FigureType : SimpleRectangle, new()
        {
            
            FigureType figure = new FigureType();
            figure.Location = location;
            if (_handler != null)
                _handler.ComponentsInProj.Add(figure);
            Invalidate();
        }

        public void SelectedBringToFront()
        {
            if (_selectedFigure != null)
            {
                _handler.ComponentsInProj.Remove(_selectedFigure);
                _handler.ComponentsInProj.Add(_selectedFigure);
                Invalidate();
            }
        }


        public void SelectedSendToBack()
        {
            if (_selectedFigure != null)
            {
                _handler.ComponentsInProj.Remove(_selectedFigure);
                _handler.ComponentsInProj.Insert(0, _selectedFigure);
                Invalidate();
            }
        }

        public void SelectedAddLedgeLine(UML_Logic_Library.Arrows.ArrowsTypes type)
        {
            if (_selectedFigure != null && (_selectedFigure is SimpleRectangle))
            {
                Arrows arrows = new Arrows(type);
                arrows.From = (_selectedFigure as SimpleRectangle);
                EndLineMarker marker = new EndLineMarker(_handler, 1);
                var temp = (SimpleRectangle)arrows.From;
                marker.Location = new PointF(temp.Location.X + temp.Size.Width/2, temp.Location.Y + temp.Size.Height);
                marker.Location = marker.Location.Offset(0, temp.Size.Height/2);
                arrows.To = marker;
                _handler.ComponentsInProj.Add(arrows);
                _selectedFigure = arrows;
                CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedDelete()
        {
            if (_selectedFigure != null || _selectedFigure is Arrows)
            {
                _handler.ComponentsInProj.Remove(_selectedFigure);
                _selectedFigure = null;
                _draggedFigure = null;
                CreateMarkers();

                Invalidate();
            }
        }

        public Bitmap GetImage()
        {
            _selectedFigure = null;
            _draggedFigure = null;
            CreateMarkers();

            Bitmap bmp = new Bitmap(Bounds.Width, Bounds.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        private bool frontFlag = false;
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyData == (Keys.Delete))
                SelectedDelete();
            
            if (SelectedFigure == null || !(SelectedFigure is SimpleRectangle))
                return;
            
            if (e.KeyData == (Keys.Enter))
            {
                if (!frontFlag)
                {
                    SelectedBringToFront();
                }
                else
                {
                    SelectedSendToBack();
                }

                frontFlag = !frontFlag;
            }
            
            

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
