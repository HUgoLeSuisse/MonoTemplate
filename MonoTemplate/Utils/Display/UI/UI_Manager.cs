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
    public abstract class UI_Manager : ICleanable
    {
        protected DisplayUtils displayUtils;
        protected Camera _cam;

        /// <summary>
        /// Ensemble des éléments contenant l'interface
        /// </summary>
        protected UI_Pannel content;

        protected UI_Manager(Camera cam)
        {
            displayUtils = DisplayUtils.Instance;
            _cam = cam;
        }


        /// <summary>
        /// Permet d'obtenir l'ensemble des élements
        /// </summary>
        /// <returns>L'ensemble des élements</returns>
        public virtual UI_Pannel GetContent()
        {
            return content;
        }
        public void Destroy()
        {
            content.Destroy();
        }
    }
}
