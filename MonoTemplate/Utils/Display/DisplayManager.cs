using Microsoft.Xna.Framework.Graphics;
using Monotemplate.Utils.Display;
using MonoTemplate.Utils.Display.Scene;
using MonoTemplate.Utils.Display.UI;
using System;

namespace MonoTemplate.Utils.Display
{

    public class DisplayManager
    {

        private Camera _cam;

        private DefaultScene scene;
        private UserInterface ui;


        public DisplayManager() 
        {

            //scene = new DefaultScene();
            //ui = new UserInterface();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _cam.GetVisibles(scene);
        }
    }
}
