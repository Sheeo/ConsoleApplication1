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
using NLog;

namespace Tss.WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public Logger Logger = LogManager.GetLogger("Game1");
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Game state members
        private float zoom = 100.0f;
        private int mouseSrollLevel = 0;
        private Matrix worldMatrix, projectionMatrix;
        private Vector3 cameraPosition;
        private Matrix cameraLookAt;

        private VertexPositionNormalTexture[] cubeVertices;

        private VertexDeclaration[] vertexDeclaration;
        private VertexBuffer vertexBuffer;
        private BasicEffect basicEffect;

        private float tilt;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            cameraPosition = new Vector3(0, 5, 2);
            tilt = MathHelper.ToRadians(0);  // 0 degree angle
            // Use the world matrix to tilt the cube along x and y axes.
            worldMatrix = Matrix.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);
            cameraLookAt = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45),  // 45 degree angle
                (float)GraphicsDevice.Viewport.Width /
                (float)GraphicsDevice.Viewport.Height,
                1.0f, 100.0f);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            // Initialize effect
            basicEffect = new BasicEffect(graphics.GraphicsDevice)
                              {
                                  View = cameraLookAt,
                                  Projection = projectionMatrix,
                                  World = worldMatrix,
                                  AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f),
                                  DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f),
                                  SpecularColor = new Vector3(0.25f, 0.25f, 0.25f),
                                  SpecularPower = 5.0f,
                                  Alpha = 1.0f,
                                  LightingEnabled = true
                              };

            basicEffect.DirectionalLight0.Enabled = true; // enable each light individually
            if (basicEffect.DirectionalLight0.Enabled)
            {
                // x direction
                basicEffect.DirectionalLight0.DiffuseColor = new Vector3(1, 0, 0); // range is 0 to 1
                basicEffect.DirectionalLight0.Direction = Vector3.Normalize(new Vector3(-1, 0, 0));
                // points from the light to the origin of the scene
                basicEffect.DirectionalLight0.SpecularColor = Vector3.One;
            }
            basicEffect.DirectionalLight1.Enabled = true;
            if (basicEffect.DirectionalLight1.Enabled)
            {
                // y direction
                basicEffect.DirectionalLight1.DiffuseColor = new Vector3(0, 0.75f, 0);
                basicEffect.DirectionalLight1.Direction = Vector3.Normalize(new Vector3(0, -1, 0));
                basicEffect.DirectionalLight1.SpecularColor = Vector3.One;
            }
            basicEffect.DirectionalLight2.Enabled = true;
            if (basicEffect.DirectionalLight2.Enabled)
            {
                // z direction
                basicEffect.DirectionalLight2.DiffuseColor = new Vector3(0, 0, 0.5f);
                basicEffect.DirectionalLight2.Direction = Vector3.Normalize(new Vector3(0, 0, -1));
                basicEffect.DirectionalLight2.SpecularColor = Vector3.One;
            }

            // Buffer
            vertexBuffer = new VertexBuffer(graphics.GraphicsDevice, typeof(VertexPositionNormalTexture), cubeVertices.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionNormalTexture>(cubeVertices);
            graphics.GraphicsDevice.SetVertexBuffer(vertexBuffer);
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
            Logger.Trace("Update() called gametime: {0}", gameTime.TotalGameTime);
            acceptInput();
            updateFullscreen();
            updateZoom();
            base.Update(gameTime);
        }

        private void updateZoom()
        {
            // No zoom
        }

        private void acceptInput()
        {
            foreach(var k in Keyboard.GetState().GetPressedKeys())
            {
                if (k == Keys.Q)
                    Exit();
                else if (k == Keys.W)
                {
                    tilt += 0.1f;
                    Logger.Info("Tilting: {0}", tilt);
                }

            }
        }

        private void updateFullscreen()
        {
            var keystate = Keyboard.GetState();
            if(keystate.IsKeyDown(Keys.LeftAlt) && keystate.IsKeyDown(Keys.Enter))
            {
                Logger.Info("Toggling fullscreen");
                graphics.ToggleFullScreen();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Logger.Trace("Draw() called gametime: {0}", gameTime.TotalGameTime);
            worldMatrix = Matrix.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);
            GraphicsDevice.Clear(Color.Black);
            drawWorld();

            base.Draw(gameTime);
        }

        private void drawWorld()
        {
            GraphicsDevice.Clear(Color.Black);

            var rasterizerState = new RasterizerState {CullMode = CullMode.None};
            graphics.GraphicsDevice.RasterizerState = rasterizerState;

            foreach (var pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphics.GraphicsDevice.DrawPrimitives(
                    PrimitiveType.TriangleList,
                    0,
                    12
                );
            }
        }
    }
}
