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
// The Initial Developer of this Original Code is Ted Dunsford. Created 7/1/2008 12:50:00 PM
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************

using System;
using System.Drawing;
namespace MapWindow.Map
{


    /// <summary>
    /// DrawArgs contains the parameters necessary for 2D drawing
    /// </summary>
    public class MapDrawArgs : EventArgs
    {
        #region Private Variables

        private MapArgs _geoGraphics;
        private Graphics _graphics;
        private Rectangle _clipRectangle;
        

    
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of DrawArgs
        /// </summary>
        public MapDrawArgs(Graphics inGraphics, Rectangle clipRectangle, IMapFrame inMapFrame)
        {
            _graphics = inGraphics;
            _geoGraphics = new MapArgs(clipRectangle, inMapFrame.Extents);
           
            _clipRectangle = clipRectangle;
        }

        /// <summary>
        /// Creates a new instance of GeoDrawArgs
        /// </summary>
        /// <param name="inGraphics"></param>
        /// <param name="clipRectangle"></param>
        /// <param name="inGeoGraphics"></param>
        public MapDrawArgs(Graphics inGraphics, Rectangle clipRectangle, MapArgs inGeoGraphics)
        {
            _graphics = inGraphics;
            _clipRectangle = clipRectangle;
        }


        #endregion

     
        #region Properties

        /// <summary>
        /// Gets a Graphics object that is useful for drawing in client coordinates.  Coordinates
        /// should be specified as though they were drawn to the client rectangle, even if
        /// a clip rectangle is specified.
        /// </summary>
        public virtual Graphics Graphics
        {
            get { return _graphics; }
            protected set { _graphics = value; }
        }

        /// <summary>
        /// Gets a GeoGraphics wrapper that makes it easy to draw things in geographic coordinates.
        /// </summary>
        public virtual MapArgs GeoGraphics
        {
            get { return _geoGraphics; }
            protected set { _geoGraphics = value; }
        }

       
        /// <summary>
        /// Gets the clip rectangle that defines the area on the region in client coordinates where drawing is taking place.
        /// </summary>
        public virtual Rectangle ClipRectangle
        {
            get { return _clipRectangle; }
            set { _clipRectangle = value; }
        }

       
    

        #endregion



    }
}
