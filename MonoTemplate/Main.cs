using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monotemplate.Utils.Display;
using MonoTemplate.Utils.Display;

namespace MonoTemplate;

public class Main : Game
{
    private DisplayUtils displayUtils;
    private UpdateEvents events;
    private DisplayManager _displayManager;


    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        displayUtils = DisplayUtils.Instance;
        displayUtils.width = 1200;
        displayUtils.height = 800;

        events = UpdateEvents.Instance;
    }

    protected override void Initialize()
    {
        base.Initialize();


        displayUtils.SetContent(Content);

        displayUtils.blank = new Texture2D(GraphicsDevice, 1, 1);
        Color[] colorData = { Color.White };
        displayUtils.blank.SetData(colorData);

        //displayUtils.defaultFont = Content.LoadLocalized<SpriteFont>("DefaultFont");


        _graphics.PreferredBackBufferWidth = displayUtils.width;
        _graphics.PreferredBackBufferHeight = displayUtils.height;
        _graphics.IsFullScreen = false;

        _graphics.ApplyChanges();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        events.PreUpdate?.Invoke(gameTime);
        events.Update?.Invoke(gameTime);
        base.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _displayManager.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

}
