using Microsoft.Xna.Framework;
using BuildAndDestroy.GameComponents.Utils;
using Monotemplate.Utils.Display;
using Monotemplate.Utils;
using MonoTemplate.Utils.Display.UI.Element;

namespace MonoTemplate.Utils.Display.UI
{
    /// <summary>
    /// Permet de géré une interface utilisateur
    /// </summary>
    public abstract class UserInterface : ICleanable
    {
        protected DisplayUtils displayUtils;

        /// <summary>
        /// Ensemble des éléments contenant l'interface
        /// </summary>
        protected Pannel content;

        protected UserInterface()
        {
            displayUtils = DisplayUtils.Instance;
        }


        /// <summary>
        /// Permet d'obtenir l'ensemble des élements
        /// </summary>
        /// <returns>L'ensemble des élements</returns>
        public virtual Pannel GetContent()
        {
            return content;
        }


        public void Destroy()
        {
            content.Destroy();
        }
    }
}
