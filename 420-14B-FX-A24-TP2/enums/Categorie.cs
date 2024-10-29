using System.ComponentModel;

namespace _420_14B_FX_A24_TP2.enums
{
    /// <summary>
    /// Représente la catégorie d'une course dans le système de gestion de courses.
    /// </summary> 
    public enum Categorie
    {
        #region ÉNUMÉRATION

        /// <summary>
        /// Catégorie M20-29.
        /// </summary>
        [Description("M20-29")]
        M2029,

        /// <summary>
        /// Catégorie M20-39.
        /// </summary>
        [Description("M30-39")]
        M3039,

        /// <summary>
        /// Catégorie M20-49.
        /// </summary>
        [Description("M40-49")]
        M4049,

        /// <summary>
        /// Catégorie M20-59.
        /// </summary>
        [Description("M50-59")]
        M5059,

        /// <summary>
        /// Catégorie M20-69.
        /// </summary>
        [Description("M60-69")]
        M6069,

        /// <summary>
        /// Catégorie F20-29.
        /// </summary>
        [Description("F20-29")]
        F2029,

        /// <summary>
        /// Catégorie F20-39.
        /// </summary>
        [Description("F30-39")]
        F3039,

        /// <summary>
        /// Catégorie F40-49.
        /// </summary>
        [Description("F40-49")]
        F4049,

        /// <summary>
        /// Catégorie F50-59.
        /// </summary>
        [Description("F50-59")]
        F5059,

        /// <summary>
        /// Catégorie F60-69.
        /// </summary>
        [Description("F60-69")]
        F6069

        #endregion
    }
}
