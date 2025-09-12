using Microsoft.Xna.Framework;
using MonoTemplate.Utils.Display.UI;
using MonoTemplate.Utils.Display.UI.Element;

namespace MonoTemplate.TestingClass
{
    internal class Menu : UserInterface
    {
        public Menu()
        {
            Pannel main = new Pannel(new Rectangle(0, 0, displayUtils.width, displayUtils.height), Color.Black, displayUtils.blank);
            Label title = new Label(position: new Point(50, 50), text: "Agrougrou", fontColor: Color.White);
            content = (main);
            content.Add(title);
        }
    }
}
