using Monotemplate.Utils.Display;
using MonoTemplate.Utils.Display.UI;

namespace MonoTemplate.Utils.Display
{

    public class DisplayManager
    {
        private DisplayManager instance;

        private Camera _cam;
        public DisplayManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DisplayManager ();
                return instance;
            }
        }


        private Scene scene;
        private UserInterface ui;


        private DisplayManager() 
        { 
        

        }


    }
}
