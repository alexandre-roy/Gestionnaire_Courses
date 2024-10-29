using System.ComponentModel;

namespace _420_14B_FX_A24_TP2.enums
{
    /// <summary>
    /// Représente la province / le territoire d'un coureur.
    /// </summary> 
    public enum Province
    {
        #region ÉNUMÉRATION

        /// <summary>
        /// La province d'Alberta au Canada.
        /// </summary> 
        Alberta,

        /// <summary>
        /// La province de la Colombie-Britannique au Canada.
        /// </summary> 
        [Description("Colombie-Britannique")]
        ColombieBritannique,

        /// <summary>
        /// La province de l'Île-du-Prince-Édouard au Canada.
        /// </summary> 
        [Description("Île-du-Prince-Édouard")]
        IlePrinceEdouard,

        /// <summary>
        /// La province du Manitoba au Canada.
        /// </summary> 
        Manitoba,

        /// <summary>
        /// La province du Nouveau-Brunswick au Canada.
        /// </summary> 
        [Description("Nouveau-Brunswick")]
        NouveauBrunswick,

        /// <summary>
        /// La province de la Nouvelle-Écosse au Canada.
        /// </summary> 
        [Description("Nouvelle-Écosse")]
        NouvelleEcosse,

        /// <summary>
        /// Le territoire Nunavut au Canada.
        /// </summary> 
        Nunavut,

        /// <summary>
        /// La province d’Ontario au Canada.
        /// </summary> 
        Ontario,

        /// <summary>
        /// La province de Québec au Canada.
        /// </summary> 
        [Description("Québec")]
        Quebec,

        /// <summary>
        /// La province de la Saskatchewan au Canada.
        /// </summary> 
        Saskatchewan,

        /// <summary>
        /// La province de Terre-Neuve-et-Labrador au Canada.
        /// </summary> 
        [Description("Terre-Neuve-et-Labrador")]
        TerreNeuveLabrador,

        /// <summary>
        /// Les Territoires du Nord-Ouest au Canada.
        /// </summary> 
        [Description("Territoires du Nord-Ouest")]
        TerritoiresNordOuest,

        /// <summary>
        /// Le territoire de Yukon au Canada.
        /// </summary> 
        Yukon

        #endregion
    }
}
