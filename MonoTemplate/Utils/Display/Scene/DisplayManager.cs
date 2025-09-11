
using MonoTemplate.Utils.Display.UI;

namespace MonoTemplate.Utils.Display.Scene
{

    public class DisplayManager
    {
        private DisplayManager instance;

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
        private UI_Manager ui;


        private DisplayManager() 
        { 
        

        }


    }
}
