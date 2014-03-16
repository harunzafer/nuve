namespace Nuve.Test.Analysis
{
    public sealed class SpecialCase
    {
        #region string[] FiilDemekYemek

        public static string[] FiilDemekYemek =
        {
            "de",
            "ye",
            "deyiş",
            "yiyiş",
            "deme",
            "yeme",
            "demek",
            "yemek",
            "diyecek",
            "yiyecek",
            "diyen",
            "yiyen",
            "diyesi",
            "yiyesi",
            "diyesice",
            "yiyesice",
            "dedik",
            "yedik",
            "demez",
            "yemez",
            "demiş",
            "yemiş",
            "diye",
            "yiye",
            "diyeli",
            "yiyeli",
            "diyerek",
            "yiyerek",
            "diyesiye",
            "yiyesiye",
            "deyip",
            "yiyip",
            "deyince",
            "yiyince",
            "dedikçe",
            "yedikçe",
            "demeden",
            "yemeden",
            "yedir",
            "dedir",
            "yedirt",
            "dedirt",
            "yedirtiyor",
            "dedirtiyor",
            "deyiver",
            "yiyiver",
        };

        #endregion

        #region string[] GecersizFiilDemekYemek

        public static string[] GecersizFiilDemekYemek =
        {
            "di",
            "yi",
            "diyiş",
            "yeyiş",
            "deyecek",
            "yeyecek",
            "deyen",
            "yeyen",
            "deyesi",
            "yeyesi",
            "deye",
            "yeye",
            "deyerek",
            "diyip",
            "yeyip",
            "diyince",
            "diyiver",
            "yeyiver",
        };

        #endregion

        #region string[] IsimSu

        public static string[] IsimSu =
        {
            "su",
            "suyu",
            "sulu",
            "suya",
            "suda",
            "sudan",
            "suyun",
            "suyla",
            "sular",
            "suyum",
            "suyumuz",
            "suyumsu",
            "suymuş",
            "suydu",
            "suysa",
            "suyken",
        };

        #endregion

        #region string[] GecersizIsimSu

        public static string[] GecersizIsimSu =
        {
            "suysuz",
            "susu",
            "suylu",
            "suylar"
        };

        #endregion

        /// <summary>
        /// Todo: Bu grup ayrıca çallışılacak
        /// </summary>

        #region string[] ZamirSoruNe
        public static string[] ZamirSoruNe =
        {
            "ne",
            "neyi",
            "neye",
            "neden",
            "neyin",
            "neyle",
            "neler",
            "neyim",
            "neyimiz",
            "nesi",
            "neymiş",
            "neydi",
            "neyse",
            "neyken",
            "nen",
            "nem",
            "neniz",
            "nemiz",
            "nesi",
            "nenin",
            "nende",
            "nenize"
        };

        #endregion

        #region string[] GecersizZamirSoruNe

        public static string[] GecersizZamirSoruNe =
        {
            "nede",
        };

        #endregion

        #region string[] UnluIncelmesi

        public static string[] UnluIncelmesi =
        {
            "saate",
            "gole",
            "alkolü",
            "ampulde",
            "kabulden",
        };

        #endregion

        #region string[] GecersizUnluIncelmesi

        public static string[] GecersizUnluIncelmesi =
        {
            "saata",
            "gola",
            "alkolu",
            "ampulda",
            "kabuldan",
        };

        #endregion

        #region string[] Yumuşama_K_G_Ğ

        public static string[] Yumuşama_K_G_Ğ =
        {
            "cenkle",
            "cenge",
            "çelengine",
            "psikologla",
            "psikoloğa",
        };

        #endregion

        /// <summary>
        /// todo şapkasız kullanımı da doğru kabul etmişiz. Bunun için de kökleri sözlüğe şapkalı ve şapkasız versiyon
        /// olmak üzere iki defa girmişiz. 
        /// </summary>

        #region string[] Şapkalı

        public static string[] Şapkalı =
        {
            "inkar",
            "inkardır",
            "inkâr",
            "inkârdır",
            "yar",
            "yâr",
            "yarim",
            "yârim",
            "yârım",
            "yarım",
        };

        #endregion
    }
}