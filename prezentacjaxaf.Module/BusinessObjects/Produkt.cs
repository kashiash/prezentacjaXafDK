using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(NazwaProduktu))]
    public class Produkt : XPObject
    {
        public Produkt(Session session) : base(session)
        { }



        decimal cenaSprzedazy;
        string nazwaProduktu;
        string kodProduktu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodProduktu
        {
            get => kodProduktu;
            set => SetPropertyValue(nameof(KodProduktu), ref kodProduktu, value);
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaProduktu
        {
            get => nazwaProduktu;
            set => SetPropertyValue(nameof(NazwaProduktu), ref nazwaProduktu, value);
        }


        public decimal CenaSprzedazy
        {
            get => cenaSprzedazy;
            set => SetPropertyValue(nameof(CenaSprzedazy), ref cenaSprzedazy, value);
        }
    }
}
