using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monotemplate.Utils.Display
{
    public interface IVisible
    {
        /// <summary>
        /// Permet d'appeler la fonction correspondante au type du spécifique de l'élément sans faire de cast // nécessite I_VisibleVisitor
        /// </summary>
        /// <param name="v"></param>
        public void Accept(IVisibleVisitor v);
        public Texture2D GetCurrentTexture();
        public Rectangle GetAbsoluteRectangle();
        public Color GetCurrentColor();
    }
}
