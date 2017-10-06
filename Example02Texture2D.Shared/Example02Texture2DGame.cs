using Impression;
using Impression.Graphics;
using Impression.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Example02Texture2D
{
    public class Example02Texture2DGame : Impression.Game
    {
		GraphicsDeviceManager graphics;

		SpriteBatch spriteBatch;
		Texture2D texture;

        public Example02Texture2DGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						this.IsMouseVisible = true;
					}
					break;
                case PlatformType.WindowsStore:
                case PlatformType.WindowsMobile:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
				case PlatformType.Android:
				case PlatformType.iOS:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
			}

            this.View.Title = "Example02Texture2D";
        }

        protected override void Initialize()
        { 
            base.Initialize();

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            texture = this.Content.Load<Texture2D>("Textures/Impression");
        }

        protected override void UnloadContent()
        {
            // do something

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Escape))
							this.Exit();
					}
					break;
				default:
					{
						// do nothings
					}
					break;
			}

			// do something
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			graphics.GraphicsDevice.Clear(Color.White);

			spriteBatch.Begin();

			// Draw texture at center of screen
			spriteBatch.Draw(
				texture, 
				new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2), 
				null, 
				Color.White, 
				0, 
				new Vector2(texture.Width / 2, texture.Height / 2), 
				1, 
				SpriteEffects.None, 
				0);
			
			spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}