using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monotemplate.Utils.Display;
using MonoTemplate.Utils.Display;

namespace MonoTemplate;

public class Main : Game
{
    private DisplayUtils _displayUtils;
    private UpdateEvents _events;
    private DisplayManager _displayManager;
    public DisplayManager DisplayManager { get { return _displayManager; } }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private static Main _instance;
    public static Main Instance { get 
        {
            if (_instance == null)
            {
                _instance = new Main();   
            }
            return _instance; }
    }
    private Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        _displayUtils = DisplayUtils.Instance;
        _displayUtils.width = 1200;
        _displayUtils.height = 800;

        _events = UpdateEvents.Instance;
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.IsMouseVisible = true;

        _displayUtils.SetContent(Content);

        _displayUtils.blank = new Texture2D(GraphicsDevice, 1, 1);
        Color[] colorData = { Color.White };
        _displayUtils.blank.SetData(colorData);

        _displayUtils.defaultFont = Content.LoadLocalized<SpriteFont>("DefaultFont");


        _graphics.PreferredBackBufferWidth = _displayUtils.width;
        _graphics.PreferredBackBufferHeight = _displayUtils.height;
        _graphics.IsFullScreen = false;
        
        _graphics.ApplyChanges();
        

        _displayManager = new DisplayManager(_spriteBatch);

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

        _events.PreUpdate?.Invoke(gameTime);
        _events.Update?.Invoke(gameTime);
        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _displayManager.Draw();
        base.Draw(gameTime);
    }

}
