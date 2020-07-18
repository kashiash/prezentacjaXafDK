using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Osoba : XPObject
    {
        public Osoba(Session session) : base(session)
        { }


        string uwagi;
        string adresEmail;
        string nrTelefonu;
        string nazwisko;
        string imie;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Imie
        {
            get => imie;
            set => SetPropertyValue(nameof(Imie), ref imie, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nazwisko
        {
            get => nazwisko;
            set => SetPropertyValue(nameof(Nazwisko), ref nazwisko, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrTelefonu
        {
            get => nrTelefonu;
            set => SetPropertyValue(nameof(NrTelefonu), ref nrTelefonu, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AdresEmail
        {
            get => adresEmail;
            set => SetPropertyValue(nameof(AdresEmail), ref adresEmail, value);
        }
        
        [Size(SizeAttribute.Unlimited)]
        public string Uwagi
        {
            get => uwagi;
            set => SetPropertyValue(nameof(Uwagi), ref uwagi, value);
        }
    }
}
