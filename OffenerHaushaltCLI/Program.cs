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
using System.IO;
using System.Linq;
using System.Text;

using org.GraphDefined.Vanaheimr.Styx;

#endregion

namespace de.OffenesJena.OffenerHaushalt.OffenerHaushaltCLI
{

    public class Program
    {

        public static void Main(String[] Arguments)
        {

            var AllLines = File.ReadLines("HH2015-2019.csv", Encoding.UTF8).
                                CreatePipe().
                                ToCSV(Seperators:                  new String[] { "|" },
                                      ExpectedNumberOfColumns:     30,
                                      FailOnWrongNumberOfColumns:  true).
                                Select(line => new HaushaltsElement(line)).
                                ToArray();

            var Index_ProduktOderLeistungsbezeichnung       = AllLines.GroupBy(item => item.ProduktOderLeistungsbezeichnung).      Select(group => group.Key).ToArray();
            var Index_Kostenstellenbezeichnung              = AllLines.GroupBy(item => item.Kostenstellenbezeichnung).             Select(group => group.Key).ToArray();
            var Index_BezeichnungSachkontoErgebnisrechnung  = AllLines.GroupBy(item => item.BezeichnungSachkontoErgebnisrechnung). Select(group => group.Key).ToArray();
            var Index_BezeichnungSachkontoErgebnisplan      = AllLines.GroupBy(item => item.BezeichnungSachkontoErgebnisplan).     Select(group => group.Key).ToArray();
            var Index_BezeichnungSachkontoFinanzrechnung    = AllLines.GroupBy(item => item.BezeichnungSachkontoFinanzrechnung).   Select(group => group.Key).ToArray();
            var Index_Projektbezeichnung                    = AllLines.GroupBy(item => item.Projektbezeichnung).                   Select(group => group.Key).ToArray();

            File.WriteAllLines(@"ProduktOderLeistungen.idx",      Index_ProduktOderLeistungsbezeichnung);
            File.WriteAllLines(@"Kostenstellen.idx",              Index_Kostenstellenbezeichnung);
            File.WriteAllLines(@"SachkontoErgebnisrechnung.idx",  Index_BezeichnungSachkontoErgebnisrechnung);
            File.WriteAllLines(@"SachkontoErgebnisplan.idx",      Index_BezeichnungSachkontoErgebnisplan);
            File.WriteAllLines(@"SachkontoFinanzrechnung.idx",    Index_BezeichnungSachkontoFinanzrechnung);
            File.WriteAllLines(@"Projektbezeichnungen.idx",       Index_Projektbezeichnung);

        }

    }

}
