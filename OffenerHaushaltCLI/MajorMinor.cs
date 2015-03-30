/*
 * Copyright (c) 2015, Achim 'ahzf' Friedland <achim@offenes-jena.de>
 * This file is part of Offener Haushalt Jena <http://www.github.com/OffenesJena/OffenerHaushalt>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Linq;
using System.Collections.Generic;

#endregion

namespace de.OffenesJena.OffenerHaushalt
{

    /// <summary>
    /// An unqiue identification having a major and minor number;
    /// </summary>
    public class MajorMinor
    {

        #region Properties

        #region Major

        private readonly UInt32 _Major;

        /// <summary>
        /// The major number of the identification.
        /// </summary>
        public UInt32 Major
        {
            get
            {
                return _Major;
            }
        }

        #endregion

        #region Minor

        private readonly UInt32 _Minor;

        /// <summary>
        /// The minor number of the identification.
        /// </summary>
        public UInt32 Minor
        {
            get
            {
                return _Minor;
            }
        }

        #endregion

        #endregion

        #region Constructor(s)

        #region MajorMinor(Major, Minor)

        public MajorMinor(UInt32 Major, UInt32 Minor)
        {
            this._Major  = Major;
            this._Minor  = Minor;
        }

        #endregion

        #region MajorMinor(Enumeration)

        public MajorMinor(IEnumerable<UInt32> Enumeration)
        {

            var Enumerator = Enumeration.GetEnumerator();

            Enumerator.MoveNext();
            this._Major = Enumerator.Current;

            Enumerator.MoveNext();
            this._Minor = Enumerator.Current;

        }

        #endregion

        #region MajorMinor(Array)

        public MajorMinor(UInt32[] Array)
        {
            this._Major = Array[0];
            this._Minor = Array[1];
        }

        #endregion

        #endregion

        #region Parse(Text)

        public static MajorMinor Parse(String Text, Char[] SplitCharacters = null)
        {

            return new MajorMinor(Text.Split (SplitCharacters,
                                              StringSplitOptions.None).
                                       Select(item => UInt32.Parse(item)).
                                       ToArray());

        }

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Return a string representation of this object.
        /// </summary>
        public override String ToString()
        {
            return _Major + " / " + _Minor;
        }

        #endregion

    }

}
