using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monotemplate.Utils.Display;
using MonoTemplate.TestingClass;
using MonoTemplate.Utils.Display.Scene;
using MonoTemplate.Utils.Display.UI;
using MonoTemplate.Utils.Display.UI.Element;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MonoTemplate.Utils.Display
{

    public class DisplayManager : IVisibleVisitor
    {

        private SpriteBatch _spriteBatch;
        private Camera _cam;

        private DefaultScene scene;
        private UserInterface ui;

        public DisplayManager(SpriteBatch spriteBatch) 
        {
            _spriteBatch = spriteBatch;
            _cam = new Camera(); 
            //scene = new DefaultScene();
            ui = new Menu();
        }

        public void Draw()
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            IVisible[] visibles= _cam.GetVisibles(scene);

            ui.GetContent().Accept(this);
            _spriteBatch.End();
        }

        public void Visit(IVisible v)
        {
            _spriteBatch.Draw(v.GetCurrentTexture(), v.GetAbsoluteRectangle(),v.GetCurrentColor());
        }
        public void Visit(Pannel v)
        {
            Visit((IVisible) v);
            foreach (var item in v.GetChilds())
            {
                item.Accept(this);
            }
        }

        public void Visit(Label v)
        {
            _spriteBatch.Draw(v.GetCurrentTexture(),
                new Rectangle(
                    v.GetAbsoluteRectangle().X - v.GetAbsoluteRectangle().Width / 10,
                    v.GetAbsoluteRectangle().Y - v.GetAbsoluteRectangle().Height / 10,
                    (int)(v.GetAbsoluteRectangle().Width * 1.2f),
                    (int)(v.GetAbsoluteRectangle().Height * 1.2f)
                   ), v.GetCurrentColor());

            Vector2 pos = v.GetAbsoluteRectangle().Location.ToVector2();
            _spriteBatch.DrawString(
                v.font,
                v.text,
                pos,
                v.fontColor,
                0,
                Vector2.Zero,
                v.GetFontSize(),
                SpriteEffects.None,
                1
                );
        }
    }
}
