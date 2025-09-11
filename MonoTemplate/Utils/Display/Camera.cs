
using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using MonoTemplate.Utils.Display.Scene;
using System;

namespace Monotemplate.Utils.Display
{
    /// <summary>
    /// S'occupe de ce qu'il faut afficher
    /// </summary>
    public class Camera
    {
        private DisplayUtils displayUtils;
        private static Camera instance;
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera();
                }
                return instance;
            }
        }


        public Rectangle rect;
        /// <summary>
        /// la position et la taille de la caméra
        /// </summary>
        public Rectangle Rectangle { get { return rect; } set { rect = value; } }

        public Camera()
        {
            displayUtils = DisplayUtils.Instance ;
            Rectangle = new Rectangle(0, 0, displayUtils.width, displayUtils.height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle">Définie la position et la taille de la caméra</param>
        public Camera(Rectangle rectangle)
        {
            displayUtils = DisplayUtils.Instance;
            Rectangle = rectangle;
        }

        public IVisible[] GetVisibles(DefaultScene scene)
        {

            return [];
        }
    }
}
