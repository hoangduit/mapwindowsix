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
// The Initial Developer of this Original Code is Ted Dunsford. Created 2/18/2010 3:33:47 PM
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************

using System;
using System.IO;


namespace MapWindow.Data
{


    /// <summary>
    /// PngHeader
    /// </summary>
    public class PngHeader
    {

        

        #region Private Variables

        private int _width;
        private int _height;
        private BitDepths _bitdepth;
        private ColorTypes _colortype;
        private InterlaceMethods _interlaceMethod;


        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of PngHeader
        /// </summary>
        public PngHeader(int width, int height)
        {
            _width = width;
            _height = height;
            _bitdepth = BitDepths.Eight;
            _colortype = ColorTypes.TruecolorAlpha;
            _interlaceMethod = InterlaceMethods.NoInterlacing;
        
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the byte-format of this png image header chunk to 
        /// </summary>
        /// <param name="stream"></param>
        public void Write(Stream stream)
        {
            byte[] head = ToBytes();
            stream.Write(head, 0, head.Length);
        }

        /// <summary>
        /// Returns the image header in bytes.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] vals = new byte[25];
           
            Write(vals, 0, 13);
            vals[4] = 73; //I
            vals[5] = 72; //H
            vals[6] = 68; //D
            vals[7] = 82; //R
            Write(vals, 8, _width);
            Write(vals, 12, _height);
            vals[16] = (byte)_bitdepth;
            vals[17] = (byte)_colortype;
            vals[18] = CompressionMethod;
            vals[19] = FilterMethod;
            vals[20] = (byte)_interlaceMethod;

            // CRC check is calculated on the chunk type and chunk data, but not the length.
            
            byte[] data = new byte[13];
            Array.Copy(vals, 8, data, 0, 13);
            byte[] crcData = new byte[17];
            Array.Copy(vals, 4, crcData, 0, 4);
            Array.Copy(data, 0, crcData, 4, 13);
            Write(vals, 21, Crc32.ComputeChecksum(crcData)); // this should be ok
            return vals;
        }

        /// <summary>
        /// Writes an integer in Big-endian Uint format.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        public void Write(byte[] array, int offset, uint value)
        {
            byte[] arr = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(arr);
            Array.Copy(arr, 0, array, offset, 4);


        }

        /// <summary>
        /// Writes an integer in Big-endian Uint format.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        public void Write(byte[] array, int offset, int value)
        {
            byte[] arr = BitConverter.GetBytes((uint) value);
            if(BitConverter.IsLittleEndian)Array.Reverse(arr);
            Array.Copy(arr, 0, array, offset, 4);
            

        }


        /// <summary>
        /// Reads the important content from the stream of bytes
        /// </summary>
        /// <param name="stream"></param>
        public static PngHeader FromBytes(Stream stream)
        {
            
            byte[] vals = new byte[25];
            stream.Read(vals, 0, 25);
            int w = (int)BitConverter.ToUInt32(vals, 9);
            int h = (int)BitConverter.ToUInt32(vals, 13);

            PngHeader result = new PngHeader(w, h);
            result.BitDepth = (BitDepths)vals[17];
            result.ColorType = (ColorTypes) vals[18];
            result.InterlaceMethod = (InterlaceMethods) vals[21];
            return result;
        }
        

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the bit depth.  Depending on the Color Type, not all are allowed:
        /// Greyscale - 1, 2, 4, 8, 16
        /// Truecolor - 8, 16
        /// Indexed - 1, 2, 4, 8
        /// Greyscale/alpha - 8, 16
        /// TrueColor/alpha - 8, 16
        /// </summary>
        public BitDepths BitDepth
        {
            get { return _bitdepth; }
            set { _bitdepth = value; }
        }

        /// <summary>
        /// Gets or sets the color type.
        /// </summary>
        public ColorTypes ColorType
        {
            get { return _colortype; }
            set { _colortype = value; }
        }

        /// <summary>
        /// Gets or sets the width
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Gets or sets the interlacing method used for this image.
        /// </summary>
        public InterlaceMethods InterlaceMethod
        {
            get { return _interlaceMethod; }
            set { _interlaceMethod = value; }
        }

        /// <summary>
        /// At this time, the only compression method recognized is 0 - deflate/inflate with a 
        /// sliding window of at most 32768 bytes
        /// </summary>
        public const byte CompressionMethod = (byte) 0;

        /// <summary>
        /// At this time, only filter method 0 is outlined in the international standards.
        /// (adaptive filtering with 5 basic filter types)
        /// </summary>
        public const byte FilterMethod = (byte) 0;

        #endregion



    }
}