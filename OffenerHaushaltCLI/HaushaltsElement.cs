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
using System.Globalization;
using System.Collections.Generic;

#endregion

namespace de.OffenesJena.OffenerHaushalt
{

    /// <summary>
    /// Eine Zeile des Haushalts-CSV-Exports.
    /// </summary>
    public class HaushaltsElement
    {

        #region Data

        private static readonly Char[] DefaultSplitCharacters = new Char[] { '_' };

        #endregion

        #region Properties

        #region Haushaltsstelle

        private readonly MajorMinor _Haushaltsstelle;

        /// <summary>
        /// Die unterste Ebene bilden sogenannte "Haushaltsstellen", um die man sich nicht weiter kümmern muss.
        /// Dies hier ist die (für Spezialisten) sprechende Nummerierung dieser Dinger.
        /// Bitte mitführen, falls wir mal gemeinsam Fehler suchen.
        /// </summary>
        public MajorMinor Haushaltsstelle
        {
            get
            {
                return _Haushaltsstelle;
            }
        }

        #endregion

        #region HaushaltsstelleId

        private readonly UInt32 _HaushaltsstelleId;

        /// <summary>
        /// Die ID der "Haushaltsstellen", bitte ebenfalls mitführen.
        /// </summary>
        public UInt32 HaushaltsstelleId
        {
            get
            {
                return _HaushaltsstelleId;
            }
        }

        #endregion

        #region ErtragOderAufwand

        private readonly ErtragOderAufwand _ErtragOderAufwand;

        /// <summary>
        /// Ertrag/Aufwand bzw. Einzahlung/Auszahlung.
        /// </summary>
        public ErtragOderAufwand ErtragOderAufwand
        {
            get
            {
                return _ErtragOderAufwand;
            }
        }

        #endregion

        #region ProduktOderLeistungsnummer

        private readonly UInt32 _ProduktOderLeistungsnummer;

        /// <summary>
        /// Nummer des Produkts bzw. der Leistung.
        /// </summary>
        public UInt32 ProduktOderLeistungsnummer
        {
            get
            {
                return _ProduktOderLeistungsnummer;
            }
        }

        #endregion

        #region ProduktOderLeistungsbezeichnung

        private readonly String _ProduktOderLeistungsbezeichnung;

        /// <summary>
        /// Bezeichnung des Produkts bzw. der Leistung.
        /// </summary>
        public String ProduktOderLeistungsbezeichnung
        {
            get
            {
                return _ProduktOderLeistungsbezeichnung;
            }
        }

        #endregion

        #region ProduktOderLeistungsart

        private readonly ProduktOderLeistung _ProduktOderLeistungsart;

        /// <summary>
        /// Art des Produkts bzw. der Leistung.
        /// 7=Produkt, 8=Leistung
        /// </summary>
        public ProduktOderLeistung ProduktOderLeistungsart
        {
            get
            {
                return _ProduktOderLeistungsart;
            }
        }

        #endregion

        #region Kostenstelle

        private readonly UInt32 _Kostenstelle;

        /// <summary>
        /// Kostenstelle/Organisationseinheit.
        /// </summary>
        public UInt32 Kostenstelle
        {
            get
            {
                return _Kostenstelle;
            }
        }

        #endregion

        #region Kostenstellenbezeichnung

        private readonly String _Kostenstellenbezeichnung;

        /// <summary>
        /// Bezeichnung der Kostenstelle/Organisationseinheit.
        /// </summary>
        public String Kostenstellenbezeichnung
        {
            get
            {
                return _Kostenstellenbezeichnung;
            }
        }

        #endregion

        #region SachkontoErgebnisrechnung

        private readonly UInt32 _SachkontoErgebnisrechnung;

        /// <summary>
        /// Sachkonto in der Ergebnisrechnung.
        /// </summary>
        public UInt32 SachkontoErgebnisrechnung
        {
            get
            {
                return _SachkontoErgebnisrechnung;
            }
        }

        #endregion

        #region BezeichnungSachkontoErgebnisrechnung

        private readonly String _BezeichnungSachkontoErgebnisrechnung;

        /// <summary>
        /// Bezeichnung des Sachkontos in der Ergebnisrechnung.
        /// </summary>
        public String BezeichnungSachkontoErgebnisrechnung
        {
            get
            {
                return _BezeichnungSachkontoErgebnisrechnung;
            }
        }

        #endregion

        #region PositionSachkontoErgebnisplan

        private readonly String _PositionSachkontoErgebnisplan;

        /// <summary>
        /// Position des Sachkontos im Ergebnisplan.
        /// </summary>
        public String PositionSachkontoErgebnisplan
        {
            get
            {
                return _PositionSachkontoErgebnisplan;
            }
        }

        #endregion

        #region BezeichnungSachkontoErgebnisplan

        private readonly String _BezeichnungSachkontoErgebnisplan;

        /// <summary>
        /// Bezeichnung des Sachkontos im Ergebnisplan.
        /// </summary>
        public String BezeichnungSachkontoErgebnisplan
        {
            get
            {
                return _BezeichnungSachkontoErgebnisplan;
            }
        }

        #endregion

        #region IstImErgebnisplan

        private readonly Boolean _IstImErgebnisplan;

        /// <summary>
        /// 1=ist in Ergebnisplan für Jahre 2014 ff., 0=nicht.
        /// </summary>
        public Boolean IstImErgebnisplan
        {
            get
            {
                return _IstImErgebnisplan;
            }
        }

        #endregion

        #region SachkontoFinanzrechnung

        private readonly UInt32 _SachkontoFinanzrechnung;

        /// <summary>
        /// Sachkonto in der Finanzrechnung.
        /// </summary>
        public UInt32 SachkontoFinanzrechnung
        {
            get
            {
                return _SachkontoFinanzrechnung;
            }
        }

        #endregion

        #region BezeichnungSachkontoFinanzrechnung

        private readonly String _BezeichnungSachkontoFinanzrechnung;

        /// <summary>
        /// Bezeichnung des Sachkontos in der Finanzrechnung.
        /// </summary>
        public String BezeichnungSachkontoFinanzrechnung
        {
            get
            {
                return _BezeichnungSachkontoFinanzrechnung;
            }
        }

        #endregion

        #region IstImFinanzplan

        private readonly Boolean _IstImFinanzplan;

        /// <summary>
        /// 1=ist in Finanzplan für Jahre 2014 ff., 0=nicht.
        /// </summary>
        public Boolean IstImFinanzplan
        {
            get
            {
                return _IstImFinanzplan;
            }
        }

        #endregion

        #region Projekt

        private readonly String _Projekt;

        /// <summary>
        /// Projekt (bei Investitionen).
        /// </summary>
        public String Projekt
        {
            get
            {
                return _Projekt;
            }
        }

        #endregion

        #region Projektbezeichnung

        private readonly String _Projektbezeichnung;

        /// <summary>
        /// Projektbezeichnung (bei Investitionen).
        /// </summary>
        public String Projektbezeichnung
        {
            get
            {
                return _Projektbezeichnung;
            }
        }

        #endregion

        #region Ergebnisrechnung

        private Dictionary<UInt16, Double> _Ergebnisrechnung;

        /// <summary>
        /// Ergebnisrechnung
        /// </summary>
        public IEnumerable<KeyValuePair<UInt16, Double>> Ergebnisrechnungen
        {
            get
            {
                return _Ergebnisrechnung.OrderBy(item => item.Key);
            }
        }

        /// <summary>
        /// Ergebnisrechnung für das angegebene Jahr.
        /// </summary>
        /// <param name="Jahr">Das Jahr.</param>
        public Double Ergebnisrechnung(UInt16 Jahr)
        {
            return _Ergebnisrechnung[Jahr];
        }

        #endregion

        #region Finanzrechnung

        private Dictionary<UInt16, Double> _Finanzrechnung;

        /// <summary>
        /// Finanzrechnung
        /// </summary>
        public IEnumerable<KeyValuePair<UInt16, Double>> Finanzrechnungen
        {
            get
            {
                return _Finanzrechnung.OrderBy(item => item.Key);
            }
        }

        /// <summary>
        /// Finanzrechnung für das angegebene Jahr.
        /// </summary>
        /// <param name="Jahr">Das Jahr.</param>
        public Double Finanzrechnung(UInt16 Jahr)
        {
            return _Finanzrechnung[Jahr];
        }

        #endregion

        #region Finanzplanung

        private Dictionary<UInt16, Double> _Finanzplanung;

        /// <summary>
        /// Finanzplanung
        /// </summary>
        public IEnumerable<KeyValuePair<UInt16, Double>> Finanzplanungen
        {
            get
            {
                return _Finanzplanung.OrderBy(item => item.Key);
            }
        }

        /// <summary>
        /// Finanzplanung für das angegebene Jahr.
        /// </summary>
        /// <param name="Jahr">Das Jahr.</param>
        public Double Finanzplanung(UInt16 Jahr)
        {
            return _Finanzplanung[Jahr];

        }

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Parse eine Zeile des Haushalts-CSV-Exports.
        /// </summary>
        /// <param name="CSV"></param>
        public HaushaltsElement(String[] CSV)
        {

            if (CSV.Length != 30)
                throw new ArgumentException("Illegal CSV format!");

            // Hhst             Die unterste Ebene bilden sogenannte "Haushaltsstellen", um die man sich nicht weiter kümmern muss.
            //                    Dies hier ist die (für Spezialisten) sprechende Nummerierung dieser Dinger.
            //                    Bitte mitführen, falls wir mal gemeinsam Fehler suchen.
            // H id             Die ID der "Haushaltsstellen", bitte ebenfalls mitführen
            //
            // Ea               Ertrag/Aufwand bzw. Einzahlung/Auszahlung
            //
            // KTR komplett     Nummer des Produkts bzw. der Leistung
            // Ktr bez          dito Bezeichnung
            // Ktr art          7=Produkt, 8=Leistung
            // Kst              Kostenstelle = Organisationseinheit
            // Kstst bez        dito Bezeichnung
            //
            // Sk               Sachkonto in Ergebnisrechnung
            // Sk bez           dito Bezeichnung
            // Sk pos           Position im Ergebnisplan
            // Sk pos bez       dito Bezeichnung
            // Ep               1=ist in Ergebnisplan für Jahre 2014 ff., 0=nicht
            // Sk finre         Sachkonto in Finanzrechnung
            // Sk finre bez     dito Bezeichnung
            // Fp               1=ist in Finanzplan für Jahre 2014 ff., 0=nicht
            // Proj             (bei Investitionen): Projekt
            // Proj bez         dito Bezeichnung
            //
            // J2011_ERG        Ergebnisrechnung 2011
            // J2011_FINERG     Finanzrechnung 2011
            // J2012_ERG        Ergebnisrechnung 2012
            // J2012_FINERG     Finanzrechnung 2012
            // J2013_ERG        Ergebnisrechnung 2013
            // J2013_FINERG     Finanzrechnung 2013
            // J2014_PLAN       Plan 2014 (Unterscheidung Erg./Finanzplan entsprechend Feldern Ep bzw. Fp)
            // J2015_PLAN       dito Folgejahre
            // J2016_PLAN
            // J2017_PLAN
            // J2018_PLAN
            // J2019_PLAN

            this._Haushaltsstelle                       = MajorMinor.Parse(CSV[0], DefaultSplitCharacters);
            this._HaushaltsstelleId                     = UInt32.Parse(CSV[1]);

            this._ErtragOderAufwand                     = CSV[2] == "E" ? ErtragOderAufwand.Ertrag    : ErtragOderAufwand.Aufwand;

            this._ProduktOderLeistungsnummer            = UInt32.Parse(CSV[3]);
            this._ProduktOderLeistungsbezeichnung       = CSV[4];
            this._ProduktOderLeistungsart               = CSV[5] == "7" ? ProduktOderLeistung.Produkt : ProduktOderLeistung.Leistung;
            this._Kostenstelle                          = UInt32.Parse(CSV[6]);
            this._Kostenstellenbezeichnung              = CSV[7];

            this._SachkontoErgebnisrechnung             = UInt32.Parse(CSV[8]);
            this._BezeichnungSachkontoErgebnisrechnung  = CSV[9];
            this._PositionSachkontoErgebnisplan         = CSV[10];
            this._BezeichnungSachkontoErgebnisplan      = CSV[11];
            this._IstImErgebnisplan                     = CSV[12] == "1" ? true : false;
            this._SachkontoFinanzrechnung               = CSV[13] == "" ? 0 : UInt32.Parse(CSV[13]);
            this._BezeichnungSachkontoFinanzrechnung    = CSV[14];
            this._IstImFinanzplan                       = CSV[15] == "1" ? true : false;
            this._Projekt                               = CSV[16];
            this._Projektbezeichnung                    = CSV[17];

            this._Ergebnisrechnung                      = new Dictionary<UInt16, Double>();
            this._Finanzrechnung                        = new Dictionary<UInt16, Double>();
            this._Finanzplanung                         = new Dictionary<UInt16, Double>();

            this._Ergebnisrechnung.Add(2011, CSV[18] != "" ? Double.Parse(CSV[18].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzrechnung.  Add(2011, CSV[19] != "" ? Double.Parse(CSV[19].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Ergebnisrechnung.Add(2012, CSV[20] != "" ? Double.Parse(CSV[20].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzrechnung.  Add(2012, CSV[21] != "" ? Double.Parse(CSV[21].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Ergebnisrechnung.Add(2013, CSV[22] != "" ? Double.Parse(CSV[22].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzrechnung.  Add(2013, CSV[23] != "" ? Double.Parse(CSV[23].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);

            // Plan 2014 (Unterscheidung Erg./Finanzplan entsprechend Feldern Ep bzw. Fp)
            this._Finanzplanung.   Add(2014, CSV[24] != "" ? Double.Parse(CSV[24].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzplanung.   Add(2015, CSV[25] != "" ? Double.Parse(CSV[25].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzplanung.   Add(2016, CSV[26] != "" ? Double.Parse(CSV[26].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzplanung.   Add(2017, CSV[27] != "" ? Double.Parse(CSV[27].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzplanung.   Add(2018, CSV[28] != "" ? Double.Parse(CSV[28].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);
            this._Finanzplanung.   Add(2019, CSV[29] != "" ? Double.Parse(CSV[29].Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture) : 0);

        }

        #endregion


        #region (override) ToString()

        /// <summary>
        /// Return a string representation of this object.
        /// </summary>
        public override String ToString()
        {

            return "[" + _ErtragOderAufwand  + ", " + _ProduktOderLeistungsart + "] " +

                   _ProduktOderLeistungsbezeichnung       + " / " +
                   _Kostenstellenbezeichnung              + " / " +
                   _BezeichnungSachkontoErgebnisrechnung  + " / " +
                   _BezeichnungSachkontoErgebnisplan      + " / " +
                   _BezeichnungSachkontoFinanzrechnung    + " / " +
                   _Projektbezeichnung;

        }

        #endregion

    }

}
