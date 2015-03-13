using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GorillaGame
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        float moveValue = 1.5f;
        int rectangleLength = 50;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            base.Window.Title = "Gorilla Game";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData<Color>(new Color[]{
                Color.Black
            });
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (position.X < GraphicsDevice.PresentationParameters.BackBufferWidth - rectangleLength)
                {
                    position.X += moveValue;
                }
            }
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                if(position.X > 0.0f)
                {
                    position.X -= moveValue;
                }
            }       

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

         protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle((int)position.X, GraphicsDevice.PresentationParameters.BackBufferHeight - rectangleLength, rectangleLength, rectangleLength), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
