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


namespace AIproject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GameWorld world = GameWorld.GetInstance();
        
        
        int speed = 2;
        Vehicle playerVehicle = new Vehicle(new Vector2(5f,5f));

        Vector2 cannonOrigin = new Vector2(24,24);
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch spriteCar;
        float circle = MathHelper.Pi;

        TileMap myMap = new TileMap();
        int squaresAcross = 30;
        int squaresDown = 20;

        float RotationAngle;
        float RotationAngle2;
        Vector2 screenpos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 1300;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            
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
            screenpos.X = 50;
            screenpos.Y = 50;
            RotationAngle = 0;
            RotationAngle2 = RotationAngle / 180;
            RotationAngle2 = RotationAngle2 * circle;
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
            spriteCar   = new SpriteBatch(GraphicsDevice);
            Tile.TileSetTexture = Content.Load<Texture2D>("part2_tileset");
            GameWorld.texture = Content.Load<Texture2D>("part2_tileset");
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

            KeyboardState ks = Keyboard.GetState();
            //exit game by pressing the escape button
            if (ks.IsKeyDown(Keys.Escape))
                this.Exit();

            if (ks.IsKeyDown(Keys.Left))
            {
                /*Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 2, 0, (myMap.MapWidth - squaresAcross) * Tile.TileWidth);*/
               
                RotationAngle -= (1 * speed);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                /*Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0, (myMap.MapWidth - squaresAcross) * Tile.TileWidth);*/
                RotationAngle += (1 * speed);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                double RotationAngle3 ;
                RotationAngle3 = (RotationAngle) / 180;
                RotationAngle3 = RotationAngle3 * circle;
                double x = Math.Cos(RotationAngle3);
                double y = Math.Sin(RotationAngle3);
                screenpos.Y += (float)(y * speed);
                screenpos.X += (float)(x * speed);
               
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                double RotationAngle3;
                RotationAngle3 = (RotationAngle) / 180;
                RotationAngle3 = RotationAngle3 * circle;
                double x = Math.Cos(RotationAngle3);
                double y = Math.Sin(RotationAngle3);
                screenpos.Y -= (float)(y * speed);
                screenpos.X -= (float)(x * speed);
                
            }


            RotationAngle2 = RotationAngle / 180;
            RotationAngle2 = RotationAngle2 * circle;

            // TODO: Add your update logic here

            world.Update(0.1f);
            if (ks.IsKeyDown(Keys.Enter))
                ((Vehicle)world.gameobjects[0]).steeringBehaviour.SetTarget(world.gameobjects[9].pos);
            else
                ((Vehicle)world.gameobjects[0]).steeringBehaviour.SetTarget(screenpos);
            for (int i = 1; i < 10; i++)
            {
                ((Vehicle)world.gameobjects[i]).steeringBehaviour.SetTarget(world.gameobjects[i-1].pos);
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

            spriteBatch.Begin();

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileWidth, Camera.Location.Y / Tile.TileHeight);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileWidth, Camera.Location.Y % Tile.TileHeight);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles)
                    {
                        spriteBatch.Draw(Tile.TileSetTexture,new Rectangle((x * Tile.TileWidth) - offsetX, (y * Tile.TileHeight) - offsetY, Tile.TileWidth, Tile.TileHeight), Tile.GetSourceRectangle(tileID),Color.White);
                    }
                }
            }
          

            spriteBatch.End();

            
            spriteCar.Begin();
            spriteCar.Draw(GameWorld.texture, screenpos, world.gameobjects[1].GetSourceRectangle(), Color.White, RotationAngle2, cannonOrigin, 1.0f, SpriteEffects.None, 0f);

            
            foreach (BaseGameEntity entity in world.gameobjects)
            {
                 float angle = (float)Math.Atan2(entity.rotation.Y, entity.rotation.X);
                 spriteCar.Draw(GameWorld.texture, entity.pos, entity.GetSourceRectangle(), Color.White, angle, cannonOrigin, 1.0f, SpriteEffects.None, 0f);
            }
            
            spriteCar.End();
            // TODO: Add your drawing code here
            world.Render();
            base.Draw(gameTime);
        }
    }
}
