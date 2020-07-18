using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    public class PozycjaFaktury : XPObject
    {
        public PozycjaFaktury(Session session) : base(session)
        { }



        Faktura faktura;
        decimal wartosc;
        decimal ilosc;
        Produkt produkt;


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Ilosc = 1;
         //   StawkaVat = Session.FindObject<StawkaVat>(CriteriaOperator.Parse("Domyslna = True"));

        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

            [ImmediatePostData]
        public Produkt Produkt
        {
            get => produkt;
            set
            {
                var modified = SetPropertyValue(nameof(Produkt), ref produkt, value);
                if (!IsLoading && !IsSaving && modified)
                {
                    if (Produkt != null)
                    {
                        Wartosc = Produkt.CenaSprzedazy * Ilosc;
                    }
                }
            }
        }

        public decimal Ilosc
        {
            get => ilosc;
            set 
                {
                var modified = SetPropertyValue(nameof(Ilosc), ref ilosc, value);
                if (!IsLoading && !IsSaving && modified)
                {
                    if (Produkt != null)
                    {
                        Wartosc = Produkt.CenaSprzedazy * Ilosc;
                    }
                }
            }
        }


        public decimal Wartosc
        {
            get => wartosc;
            set
            {
                var modified = SetPropertyValue(nameof(Wartosc), ref wartosc, value);
                if (!IsLoading && !IsSaving && Faktura != null && modified)
                {


                    Faktura.WyliczSumyFaktury(true);

                }
            }

        }


        [Association("Faktura-PozycjeFaktury")]
        public Faktura Faktura
        {
            get => faktura;
            set => SetPropertyValue(nameof(Faktura), ref faktura, value);
        }
    }
}
