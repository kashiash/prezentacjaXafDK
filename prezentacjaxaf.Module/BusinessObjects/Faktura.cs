using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Faktura : XPObject
    {
        public Faktura(Session session) : base(session)
        { }


        RodzajeFaktury rodzaj;
        decimal wartoscVAT;
        decimal wartoscBrutto;
        decimal wartoscNetto;
        Kontrahent platnik;
        DateTime dataWystawienia;
        string nrFaktury;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrFaktury
        {
            get => nrFaktury;
            set => SetPropertyValue(nameof(NrFaktury), ref nrFaktury, value);
        }

        
        public RodzajeFaktury Rodzaj
        {
            get => rodzaj;
            set => SetPropertyValue(nameof(Rodzaj), ref rodzaj, value);
        }
        public DateTime DataWystawienia
        {
            get => dataWystawienia;
            set => SetPropertyValue(nameof(DataWystawienia), ref dataWystawienia, value);
        }


        [Association("Kontrahent-Faktury")]
        public Kontrahent Platnik
        {
            get => platnik;
            set => SetPropertyValue(nameof(Platnik), ref platnik, value);
        }



        public decimal WartoscNetto
        {
            get => wartoscNetto;
            set => SetPropertyValue(nameof(WartoscNetto), ref wartoscNetto, value);
        }

        public decimal WartoscBrutto
        {
            get => wartoscBrutto;
            set => SetPropertyValue(nameof(WartoscBrutto), ref wartoscBrutto, value);
        }

        public decimal WartoscVAT
        {
            get => wartoscVAT;
            set => SetPropertyValue(nameof(WartoscVAT), ref wartoscVAT, value);
        }

        [Association("Faktura-PozycjeFaktury"), DevExpress.Xpo.Aggregated]
        public XPCollection<PozycjaFaktury> PozycjeFaktury
        {
            get
            {
                return GetCollection<PozycjaFaktury>(nameof(PozycjeFaktury));
            }
        }

        public void WyliczSumyFaktury(bool forceChangeEvents)
        {
            //decimal? oldWkwotaNetto = wartoscNetto;
            //decimal? oldWkwotaVAT = wartoscVAT;
            decimal? oldWkwotaBrutto = wartoscBrutto;


            //decimal kwotaNettoTotal = 0m;
            //decimal kwotaVATTotal = 0m;
            decimal kwotaBruttoTotal = 0m;

            foreach (var detail in PozycjeFaktury)
            {
                kwotaBruttoTotal += detail.Wartosc;
                //kwotaNettoTotal += detail.WartoscNetto;
                //kwotaVATTotal += detail.WartoscVat;
            }
            wartoscBrutto = kwotaBruttoTotal;
            //wartoscNetto = kwotaNettoTotal;
            //wartoscVAT = kwotaVATTotal;

            if (forceChangeEvents)
            {
                OnChanged(nameof(WartoscBrutto), nameof(oldWkwotaBrutto), nameof(wartoscBrutto));
                //OnChanged("KwotaNetto", oldWkwotaNetto, kwotaNetto);
                //OnChanged("KwotaVAT", oldWkwotaVAT, kwotaVAT);
            }

        }
    }

    public enum RodzajeFaktury
    {
        [XafDisplayName("Wynajem OC")]
    
        WynajemOC,
        [XafDisplayName("Wynajem gotówka")]
        WynajemGotowka,
        [XafDisplayName("Transport")]
        Transport,
        [XafDisplayName("Obciążenia")]
        Obciazenia,
        [XafDisplayName("Noty obciążeniowe")]
        NotyObciazeniowe,
        [XafDisplayName("Sprzedaż pojazdu")]
        SprzedazPojazdu,
        [XafDisplayName("Zbiorcza za wynajem OC")]
        WynajemOCZbiorcza

    }
}
