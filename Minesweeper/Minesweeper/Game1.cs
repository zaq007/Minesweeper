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

namespace Minesweeper
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu.Menu menu;
        Core.Core core;
        int Heigth;
        int Width;
        int Mines;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferMultiSampling = false;
            //graphics.ToggleFullScreen();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Menu.Extensions.TextureLoader.Initialize(this.Content);
            Core.Extensions.TextureLoader.Initialize(this.Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (GameState.getState() == "Menu")
            {
                if (menu == null)
                    menu = new Menu.Menu();
                switch (menu.Update(gameTime))
                {
                    case "Exit": this.Exit(); break;
                    case "New Game": 
                        GameState.setState("Game"); 
                        Heigth = menu.GetHeigth(); 
                        Width = menu.GetWidth(); 
                        Mines = menu.GetMines(); 
                        graphics.PreferredBackBufferHeight = Heigth * Core.Map.Ground.CellSize;
                        graphics.PreferredBackBufferWidth = Width * Core.Map.Ground.CellSize;
                        graphics.ApplyChanges();
                        menu = null; break;
                }
            } else
                if (GameState.getState() == "Game")
                {
                    if (core == null)
                    {
                        //IsMouseVisible = false;
                        core = new Core.Core(this, spriteBatch, Heigth, Width, Mines);
                    }
                    switch (core.Update(gameTime))
                    {
                        case "Game Over": GameState.setState("Menu"); core = null; break;
                        case "Exit": this.Exit(); break;
                        case "Retry": core=null; break;
                        default: break;
                    }
                }
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            if (GameState.getState() == "Menu" && menu != null)
            {
                spriteBatch.Begin();
                menu.Draw(spriteBatch);
                spriteBatch.End();
            }
            else
                if (GameState.getState() == "Game" && core != null)
                    core.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
