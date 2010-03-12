//********************************************************************************************************
// Product Name: MapWindow.Interfaces Alpha
// Description:  The core libraries for the MapWindow 6.0 project.
//
//********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http://www.mozilla.org/MPL/ 
//
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either expressed or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
//
// The Original Code is MapWindow.dll for the MapWindow 6.0 project
//
// The Initial Developer of this Original Code is Ted Dunsford. Created in August, 2007.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MapWindow.Geometries
{
    /// <summary>
    /// <c>Geometry</c> classes support the concept of applying a
    /// coordinate filter to every coordinate in the <c>Geometry</c>. A
    /// coordinate filter can either record information about each coordinate or
    /// change the coordinate in some way. Coordinate filters implement the
    /// interface <c>ICoordinateFilter</c>. 
    /// <c>ICoordinateFilter</c> is an example of the Gang-of-Four Visitor pattern. 
    /// Coordinate filters can be
    /// used to implement such things as coordinate transformations, centroid and
    /// envelope computation, and many other functions.
    /// </summary>
    public interface ICoordinateFilter
    {
        /// <summary>
        /// Performs an operation with or on <c>coord</c>.
        /// </summary>
        /// <param name="coord"><c>Coordinate</c> to which the filter is applied.</param>
        void Filter(Coordinate coord);
    }
}
