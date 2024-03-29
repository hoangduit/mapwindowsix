//********************************************************************************************************
// Product Name: MapWindow.dll Alpha
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
// Modified to do 3D in January 2008 by Ted Dunsford
//********************************************************************************************************


namespace MapWindow.Drawing
{
    
    /// <summary>
    /// This is a specialized FeatureLayer that specifically handles point drawing
    /// </summary>
    public interface IPointLayer: IFeatureLayer
    {
        
       
        #region Methods


        #endregion


        #region Properties

       
        /// <summary>
        /// Gets or sets the FeatureSymbolizerOld determining the shared properties.  This is actually still the PointSymbolizerOld
        /// and should not be used directly on Polygons or Lines.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Unable to assign a non-point symbolizer to a PointLayer</exception>
        new IPointSymbolizer Symbolizer
        {
            get;
          
            set;
           
        }

        /// <summary>
        /// Gets or sets the pointSymbolizer characteristics to use for the selected features.
        /// </summary>
        new IPointSymbolizer SelectionSymbolizer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the currently applied scheme.  Because setting the scheme requires a processor intensive
        /// method, we use the ApplyScheme method for assigning a new scheme.  This allows access
        /// to editing the members of an existing scheme directly, however.
        /// </summary>
        new IPointScheme Symbology
        {
            get;
            set;
        }
        
        
  

        #endregion


    }
}
