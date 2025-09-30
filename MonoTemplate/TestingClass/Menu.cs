using Microsoft.Xna.Framework;
using MonoTemplate.Utils.Display.UI;
using MonoTemplate.Utils.Display.UI.Element;

namespace MonoTemplate.TestingClass
{
    internal class Menu : UserInterface
    {
        public Button Start { get; }

        public Button Exit {  get;  }
        public Menu()
        {
            Pannel main = new Pannel(new Rectangle(0, 0, displayUtils.width, displayUtils.height), Color.Black, displayUtils.blank);
            content = main;

            Label title = new Label( text: "Template", fontColor: Color.White,fontSize:1.2f);
            content.Add(title);
            title.xAlign = 0.5f;
            title.yAlign = 0.1f;

            Pannel btn = new Pannel(new Rectangle(0, 0, displayUtils.width / 2, displayUtils.height / 2), Color.Transparent, displayUtils.blank);
            content.Add(btn);
            btn.xAlign = 0.5f;
            btn.yAlign = 1f;

            Button Start = new Button(
                size: new Point (300,150),
                text:"Start",
                fontColor : Color.Black,
                color: Color.White, 
                overColor: new Color(180, 180, 180), 
                pressedColor: new Color(130, 130, 130), 
                disabledColor: new Color(50, 50, 50));
            Button Exit = new Button(
                size: new Point(300, 150), 
                text: "Exit", 
                fontColor: Color.Black, 
                color: Color.White, 
                overColor: new Color(180, 180, 180), 
                pressedColor: new Color(130, 130, 130), 
                disabledColor: new Color(50, 50, 50));

            btn.Add(Start);
            Start.xAlign = 0.5f;

            btn.Add(Exit);
            Exit.xAlign = 0.5f;
            Exit.yAlign = 0.7f;
            this.Start = Start;
            this.Exit = Exit;

            Exit.onClick += (x) =>
            {
                Main.Instance.Exit();
            };

            Start.onClick += (x) =>
            {
                Main.Instance.DisplayManager.ChangeView(null,null);
            };
        }
    }
}
