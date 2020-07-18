using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(NazwaWyswietlana))]
    public class Kontrahent : XPObject
    {
        public Kontrahent(Session session) : base(session)
        { }

        public string NazwaWyswietlana => $"{Nazwa} {NIP}";

        string uwagi;
        string miejscowosc;
        string kodPocztowy;
        string nrMieszkania;
        string nrDomu;
        string ulica;
        string nIP;
        string nazwa;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nazwa
        {
            get => nazwa;
            set => SetPropertyValue(nameof(Nazwa), ref nazwa, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NIP
        {
            get => nIP;
            set => SetPropertyValue(nameof(NIP), ref nIP, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Ulica
        {
            get => ulica;
            set => SetPropertyValue(nameof(Ulica), ref ulica, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrDomu
        {
            get => nrDomu;
            set => SetPropertyValue(nameof(NrDomu), ref nrDomu, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrMieszkania
        {
            get => nrMieszkania;
            set => SetPropertyValue(nameof(NrMieszkania), ref nrMieszkania, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodPocztowy
        {
            get => kodPocztowy;
            set => SetPropertyValue(nameof(KodPocztowy), ref kodPocztowy, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Miejscowosc
        {
            get => miejscowosc;
            set => SetPropertyValue(nameof(Miejscowosc), ref miejscowosc, value);
        }

       // [Association("Kontrahent-Kontakty")]
        [Association("Kontrahent-OsobyKontaktowe"), DevExpress.Xpo.Aggregated]
        public XPCollection<OsobaKontaktowa> Kontakty
        {
            get
            {
                return GetCollection<OsobaKontaktowa>(nameof(Kontakty));
            }
        }

        [Association("Kontrahent-Faktury")]
        public XPCollection<Faktura> Faktury
        {
            get
            {
                return GetCollection<Faktura>(nameof(Faktury));
            }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Uwagi
        {
            get => uwagi;
            set => SetPropertyValue(nameof(Uwagi), ref uwagi, value);
        }
    }
}
