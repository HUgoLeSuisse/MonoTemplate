
using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;

namespace Monotemplate.Utils.Display
{
    /// <summary>
    /// S'occupe de ce qu'il faut afficher
    /// </summary>
    public class Camera
    {
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

        public IVisible[] Visibles { get {return []; } }

        public Point Position { get; set; }

        public Camera()
        {
            UpdateEvents.Instance.Update += Update;
        }

        protected void Update(GameTime gameTime)
        {
           
        }



    }
}
