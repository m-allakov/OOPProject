using System;
using System.Collections.Generic;

namespace EvLib
{
    interface IEvBilgileri
    {
        byte oda_sayisi { get; set; }
        byte kat_sayisi { get; set; }
        string semt { get; set; }
        string cephe { get; set; }

    }

    public abstract class Ev : IEvBilgileri
    {
        public byte oda_sayisi { get; set; }
        public byte kat_sayisi { get; set; }
        public string semt { get; set; }
        public string cephe { get; set; }

        public override string ToString()
        {
            return $"Evin Oda Sayısı:{oda_sayisi}\nEvin Kat Sayısı:{kat_sayisi}\nEvin Semti:{semt}"
                ;
        }

        public abstract void Delete();

    }

    public class SatilikEv : Ev
    {
        public double satis_fiyati { get; set; }

        public override void Delete()
        {

        }

        public override string ToString()
        {
            return $"{base.ToString()}\nSatış Fiyatı: {satis_fiyati}\n************";
        }
    }

    public class KiralikEv : Ev
    {
        public double kira_fiyati { get; set; }
        public double depozito { get; set; }
        public override void Delete()
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nDepozito Ücreti: {depozito}\nKira Fiyatı: {kira_fiyati}\n************";
        }
    }

}


