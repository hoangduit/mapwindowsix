//********************************************************************************************************
// Product Name: MapWindow.dll Alpha
// Description:  The basic module for MapWindow version 6.0
//********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http://www.mozilla.org/MPL/ 
//
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either expressed or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
//
// The Original Code is from MapWindow.dll version 6.0
//
// The Initial Developer of this Original Code is Ted Dunsford. Created 5/1/2009 12:24:43 PM
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************

using System.Drawing;
using MapWindow.Main;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using MapWindow.Forms;
namespace MapWindow.Components
{


    /// <summary>
    /// DashSlider
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DashSlider
    {
        #region Private Variables

        private Image _image;
        private Orientation _orientation;
        private Color _color;
        private PointF _position;
        private SizeF _size;
        private bool _visible;
        private bool _isDragging;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of DashSlider
        /// </summary>
        public DashSlider(Orientation sliderOrientation)
        {
            _orientation = sliderOrientation;
            _visible = true;
            _size = new SizeF(20F, 20F);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the current control
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRectangle"></param>
        /// <returns></returns>
        public virtual void Draw(Graphics g, Rectangle clipRectangle)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (_visible == false) return;
            if (_image != null)
            {
                g.DrawImage(_image, Position);
            }
            else
            {
                LinearGradientBrush br = CreateGradientBrush(Color, Bounds.Location, new PointF(Bounds.Right, Bounds.Bottom));
                g.FillRectangle(br, Bounds);
                br.Dispose();
                g.DrawRectangle(Pens.Black, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
            }
        }

     



        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets an image that can be used instead of the default triangular drawing
        /// </summary>
        [Description("Gets or sets an image that can be used instead of the default drawing")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Creates a Gradient Brush
        /// </summary>
        /// <param name="color"></param>
        /// <param name="topLeft"></param>
        /// <param name="bottomRight"></param>
        /// <returns></returns>
        protected LinearGradientBrush CreateGradientBrush(Color color, PointF topLeft, PointF bottomRight)
        {
            float b = color.GetBrightness();
            b += .3F;
            if (b > 1F) b = 1F;
            Color light = Global.ColorFromHSL(color.GetHue(), color.GetSaturation(), b);
            float d = color.GetBrightness();
            d -= .3F;
            if (b < 0F) b = 0F;
            Color dark = Global.ColorFromHSL(color.GetHue(), color.GetSaturation(), d);
            return new LinearGradientBrush(topLeft, bottomRight, light, dark);
        }

        /// <summary>
        /// Gets or sets whether this control is vertical or horizontal
        /// </summary>
        [Description("Gets or sets whether this control is vertical or horizontal")]
        public Orientation Orientation
        {
            get { return _orientation; }
        }

        /// <summary>
        /// Gets the bounds of this slider.
        /// </summary>
        [Browsable(false)]
        public virtual RectangleF Bounds
        {
            get
            {
                return new RectangleF(_position, _size);
            }

        }

        

        /// <summary>
        /// Gets or sets the color for this control if it is not using a custom image.
        /// </summary>
        [Description("Gets or sets the color for this control if it is not using a custom image.")]
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Gets or sets whether or not this slider is in the process of being adjusted
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDragging
        {
            get { return _isDragging; }
            set { _isDragging = value; }
        }

        /// <summary>
        /// Gets or sets the position.  Whether the X or Y coordinate is used depends on the orientation.
        /// </summary>
        [Description("Gets or sets the position.  Whether the X or Y coordinate is used depends on the orientation."),
        TypeConverter(typeof(PointFConverter))]
        public PointF Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Gets or sets the size of this slider.  This is only used when the slider is not based on an image.
        /// </summary>
        [Description("Gets or sets the size of this slider.  This is only used when the slider is not based on an image."),
        TypeConverter(typeof(ExpandableObjectConverter))]
        public SizeF Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Gets or sets a boolean indicating whether this slider will draw itself.
        /// </summary>
        [Description("Gets or sets a boolean indicating whether this slider will draw itself.")]
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

       

        #endregion

    }
}
