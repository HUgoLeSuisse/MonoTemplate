using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monotemplate.Utils;
using Monotemplate.Utils.Display;

namespace MonoTemplate.Utils.Display.UI.Element
{
    /// <summary>
    /// Element d'interface utilisateur
    /// </summary>
    public class UI_Element : IVisible, ICleanable
    {
        protected DisplayUtils displayUtils;

        private UI_Pannel parent;

        private Rectangle rectRelative;
        private Color color;
        public Texture2D texture;

        /// <summary>
        /// Pannaux dans lequel il est contenu
        /// </summary>
        public UI_Pannel Parent { get { return parent; } set { parent = value; } }

        /// <summary>
        /// Rectangle absolue à la Position du parent
        /// </summary>
        public Rectangle Absoulute
        {
            get
            {
                Rectangle abs = rectRelative;
                if (parent != null)
                {
                    abs.Location += parent.GetAbsoluteRectangle().Location;
                }
                return abs;
            }

            set
            {
                Rectangle abs = value;
                if (parent != null)
                {
                    abs.Location -= parent.GetAbsoluteRectangle().Location;
                }
                rectRelative = abs;
            }
        }

        /// <summary>
        /// Rectangle relatif à la Position du parent
        /// </summary>
        public Rectangle Relative
        {
            get
            {
                return rectRelative;
            }

            set
            {
                rectRelative = value;
            }
        }


        #region SetRelativePos

        /// <summary>
        /// Alignement sur l'axe horizontal (0 : à gauche ; 1 : $ droite)
        /// </summary>
        public virtual float xAlign
        {
            set
            {
                if (parent != null)
                {
                    float x = 0;

                    x = parent.rectRelative.Width * value - rectRelative.Width * value;
                    Rectangle rect = new Rectangle(new Point((int)x, rectRelative.Y), rectRelative.Size);
                    rectRelative = rect;
                }
            }

        }
        /// <summary>
        /// Alignement sur l'axe vertical (0 : en haut ; 1 : en bas)
        /// </summary>
        public virtual float yAlign
        {
            set
            {
                if (parent != null)
                {
                    float y = 0;

                    y = parent.rectRelative.Height * value - rectRelative.Height * value;
                    Rectangle rect = new Rectangle(new Point(rectRelative.X, (int)y), rectRelative.Size);
                    rectRelative = rect;
                }
            }
        }

        #endregion
        /// <summary>
        /// Couleur de l'element
        /// </summary>
        public Color ColorBG
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        /// <summary>
        /// Texture de fond de l'element
        /// </summary>
        public Texture2D TextureBG
        {
            get { return texture; }
            set
            {
                texture = value ?? DisplayUtils.Instance.blank;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">Rectangle relatif à la Position du parent</param>
        /// <param name="color">Couleur de l'element</param>
        /// <param name="texture">TextureBG de l'element (par defaut 1x1 blanc)</param>
        public UI_Element(Rectangle rect, Color? color, Texture2D texture)
        {
            displayUtils = DisplayUtils.Instance;
            Relative = rect;
            ColorBG = color ?? Color.Transparent;
            TextureBG = texture;
        }



        /// <summary>
        /// Permet à VisibleVistor de fonctionner
        /// </summary>
        /// <param name="v"></param>
        public virtual void Accept(IVisibleVisitor v)
        {
            v.Visit(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>TextureBG acctuelle</returns>
        public virtual Texture2D GetCurrentTexture()
        {
            return texture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Le Rectangle absolue</returns>
        public virtual Rectangle GetAbsoluteRectangle()
        {
            return Absoulute;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Couleur acctuellle</returns>
        public virtual Color GetCurrentColor()
        {
            return color;
        }

        public virtual void Destroy()
        {
            if(parent != null)
            {
                parent.Remove(this);
            }
        }

    }
}
