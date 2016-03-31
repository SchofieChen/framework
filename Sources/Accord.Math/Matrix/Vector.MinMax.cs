﻿// Accord Math Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2015
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Math
{
    using Accord.Math.Comparers;
    using AForge;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Matrix
    {

        #region Vector ArgMin/ArgMax

        /// <summary>
        ///   Gets the maximum element in a vector.
        /// </summary>
        /// 
        public static int ArgMax<T>(this T[] values) where T : IComparable
        {
            int imax = 0;
            T max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(max) > 0)
                {
                    max = values[i];
                    imax = i;
                }
            }

            return imax;
        }

        /// <summary>
        ///   Gets the maximum element in a vector.
        /// </summary>
        /// 
        public static int ArgMax<T>(this T[] values, out T max) where T : IComparable
        {
            int imax = 0;
            max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(max) > 0)
                {
                    max = values[i];
                    imax = i;
                }
            }

            return imax;
        }

        /// <summary>
        ///   Gets the minimum element in a vector.
        /// </summary>
        /// 
        public static int ArgMin<T>(this T[] values) where T : IComparable
        {
            int imin = 0;
            T min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(min) < 0)
                {
                    min = values[i];
                    imin = i;
                }
            }

            return imin;
        }

        /// <summary>
        ///   Gets the minimum element in a vector.
        /// </summary>
        /// 
        public static int ArgMin<T>(this T[] values, out T min) where T : IComparable
        {
            int imin = 0;
            min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(min) < 0)
                {
                    min = values[i];
                    imin = i;
                }
            }

            return imin;
        }
      
        #endregion



        #region Vector Min/Max
        /// <summary>
        ///   Gets the maximum non-null element in a vector.
        /// </summary>
        /// 
        public static Nullable<T> Max<T>(this Nullable<T>[] values, out int imax)
            where T : struct, IComparable
        {
            imax = -1;
            Nullable<T> max = null;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].HasValue)
                {
                    if (max == null || values[i].Value.CompareTo(max.Value) > 0)
                    {
                        max = values[i];
                        imax = i;
                    }
                }
            }

            return max;
        }

        /// <summary>
        ///   Gets the minimum non-null element in a vector.
        /// </summary>
        /// 
        public static Nullable<T> Min<T>(this Nullable<T>[] values, out int imin)
            where T : struct, IComparable
        {
            imin = -1;
            Nullable<T> min = null;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].HasValue)
                {
                    if (min == null || values[i].Value.CompareTo(min.Value) < 0)
                    {
                        min = values[i];
                        imin = i;
                    }
                }
            }

            return min;
        }



        /// <summary>
        ///   Gets the maximum element in a vector.
        /// </summary>
        /// 
        public static T Max<T>(this T[] values, out int imax) where T : IComparable
        {
            imax = 0;
            T max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(max) > 0)
                {
                    max = values[i];
                    imax = i;
                }
            }
            return max;
        }

        /// <summary>
        ///   Gets the maximum element in a vector.
        /// </summary>
        /// 
        public static T Max<T>(this T[] values, out int imax, bool alreadySorted) where T : IComparable
        {
            if (alreadySorted)
            {
                imax = values.Length - 1;
                return values[values.Length - 1];
            }

            return Max(values, out imax);
        }

        /// <summary>
        ///   Gets the maximum element in a vector.
        /// </summary>
        /// 
        public static T Max<T>(this T[] values) where T : IComparable
        {
            int imax;
            return Max(values, out imax);
        }



        /// <summary>
        ///   Gets the minimum element in a vector.
        /// </summary>
        /// 
        public static T Min<T>(this T[] values, out int imin) where T : IComparable
        {
            imin = 0;
            T min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].CompareTo(min) < 0)
                {
                    min = values[i];
                    imin = i;
                }
            }
            return min;
        }

        /// <summary>
        ///   Gets the minimum element in a vector.
        /// </summary>
        /// 
        public static T Min<T>(this T[] values) where T : IComparable
        {
            int imin;
            return Min(values, out imin);
        }
        #endregion



        #region limited length
        /// <summary>
        ///   Gets the maximum element in a vector up to a fixed length.
        /// </summary>
        /// 
        public static T Max<T>(this T[] values, int length, out int imax) where T : IComparable
        {
            imax = 0;
            T max = values[0];
            for (int i = 1; i < length; i++)
            {
                if (values[i].CompareTo(max) > 0)
                {
                    max = values[i];
                    imax = i;
                }
            }
            return max;
        }

        /// <summary>
        ///   Gets the maximum element in a vector up to a fixed length.
        /// </summary>
        /// 
        public static T Max<T>(this T[] values, int length) where T : IComparable
        {
            int imax;
            return Max(values, length, out imax);
        }


        /// <summary>
        ///   Gets the minimum element in a vector up to a fixed length.
        /// </summary>
        /// 
        public static T Min<T>(this T[] values, int length, out int imax) where T : IComparable
        {
            imax = 0;
            T max = values[0];
            for (int i = 1; i < length; i++)
            {
                if (values[i].CompareTo(max) < 0)
                {
                    max = values[i];
                    imax = i;
                }
            }
            return max;
        }

        /// <summary>
        ///   Gets the minimum element in a vector up to a fixed length.
        /// </summary>
        /// 
        public static T Min<T>(this T[] values, int length) where T : IComparable
        {
            int imin;
            return Min(values, length, out imin);
        }
        #endregion

    }
}
