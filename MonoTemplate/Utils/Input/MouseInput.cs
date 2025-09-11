using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Monotemplate.Utils.Display;

namespace Monotemplate.Utils.Input
{
    /// <summary>
    /// Permet de connaitre les actions de la souris utile au personnage
    /// </summary>
    public class MouseInput : ICleanable
    {
        private static MouseInput instance;
        Camera camera;
        public static MouseInput Instance { 
            get 
            {
                if (instance == null)
                {
                    instance = new MouseInput();
                }
                return instance; 
            } 
        }
        private bool isLeftDown = false;
        private bool isRightDown = false;


        public delegate void OnButtonAction(Point onScreenPos, MouseButtons buttons);
        public OnButtonAction buttonUp;
        public OnButtonAction buttonDown;

        private MouseInput()
        {
            camera = Camera.Instance;
            UpdateEvents.Instance.PreUpdate += PreUpdate;
        }

        protected virtual void PreUpdate(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            // Bouton Gauche
            if (mouse.LeftButton.HasFlag(ButtonState.Pressed))
            {
                if (!isLeftDown)
                {
                    isLeftDown = true;
                    buttonDown?.Invoke(mouse.Position, MouseButtons.Left);
                }
            }
            else if (mouse.LeftButton.HasFlag(ButtonState.Released))
            {
                if (isLeftDown)
                {
                    isLeftDown = false;
                    buttonUp?.Invoke(mouse.Position, MouseButtons.Left);
                }
            }

            // Bouton Droit
            if (mouse.RightButton.HasFlag(ButtonState.Pressed))
            {
                if (!isRightDown)
                {
                    isRightDown = true;
                    buttonDown?.Invoke(mouse.Position, MouseButtons.Right);
                }
            }
            else if (mouse.RightButton.HasFlag(ButtonState.Released))
            {
                if (isRightDown)
                {
                    isRightDown = false;
                    buttonUp?.Invoke(mouse.Position, MouseButtons.Right);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>la Position acctuel de la souris</returns>
        public Point GetMousePosition()
        {
            return Mouse.GetState().Position + camera.Position;
        }

        public void Destroy()
        {
            UpdateEvents.Instance.PreUpdate -= PreUpdate;
        }

    }
}
