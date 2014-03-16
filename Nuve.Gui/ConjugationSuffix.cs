namespace Nuve.Gui
{
    class ConjugationSuffix
    {
        private string id;
        private string name;

        private ConjugationSuffix(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static readonly ConjugationSuffix GecmisDi = 
            new ConjugationSuffix("FC_ZAMAN_GECMIS_DU", "Görülen Geçmiş Zaman");

        public static readonly ConjugationSuffix GecmisMis =
            new ConjugationSuffix("FC_ZAMAN_GECMIS_mUş", "Duyulan Geçmiş Zaman");

        public static readonly ConjugationSuffix Gelecek =
            new ConjugationSuffix("FC_ZAMAN_GELECEK_(y)AcAK", "Gelecek Zaman");

        public static readonly ConjugationSuffix Simdiki =
            new ConjugationSuffix("FC_ZAMAN_SIMDIKI_(U)yor", "Şimdiki Zaman");

        public static readonly ConjugationSuffix Genis =
            new ConjugationSuffix("FC_ZAMAN_GENIS_(U)r", "Geniş Zaman");

        public static readonly ConjugationSuffix Emir =
            new ConjugationSuffix("FC_ZAMAN_GENIS_(U)r", "Geniş Zaman");

        
    }
}
