using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace prezentacjaxaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class OsobaKontaktowa : Osoba
    {
        public OsobaKontaktowa(Session session) : base(session)
        { }


        Kontrahent kontrahent;

        [Association("Kontrahent-OsobyKontaktowe")]
        public Kontrahent Kontrahent
        {
            get => kontrahent;
            set => SetPropertyValue(nameof(Kontrahent), ref kontrahent, value);
        }
    }
}
