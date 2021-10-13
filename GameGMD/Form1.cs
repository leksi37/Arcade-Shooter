using GameGMD.Enemies;
using GameGMD.EnemyPool;
using GameGMD.Flyweight;
using GameGMD.Input_CommandPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGMD
{
    public partial class Form1 : Form
    {
        #region player
        private Player player;
        private int moveDistance;
        #endregion

        #region main loop
        public bool isRunning;
        private bool gameOn;
        #endregion

        #region shooting and enemies
        bool shot = false;
        private float fallRate;
        private int spawnRate;
        private bool startedSpawn = false;
        private List<Bullet> bullets = new List<Bullet>();
        private EnemySpawner enemySpawner = new EnemySpawner();
        private List<IEnemy> enemies = new List<IEnemy>();
        #endregion

        #region sparkles flyweight
        private ISparkle sparkle;
        #endregion

        #region graphics list
        private List<GraphicsObject> graphicsObjs = new List<GraphicsObject>();
        #endregion

        #region score display
        private int playerScore;
        #endregion

        #region input
        private readonly List<Keys> input = new List<Keys>();
        #region Command pattern NOT FINISHED
        Command buttonSpace;
        Command buttonA;
        Command buttonD;
        #endregion
        #endregion

        public Form1()
        {
            InitializeComponent();
            buttonSpace = new Fire();
            buttonA = new MoveLeft();
            buttonD = new MoveRight();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            input.Add(e.KeyCode);
        }

        public void RunGameLoop()
        {     
            isRunning = true;
            gameOn = true;
            Load();
            //SpawnSparkles();
            if(!startedSpawn)
                SpawnMonsters();
            
            

            DateTime prevTime = DateTime.Now;
            while (isRunning)
            {
                TimeSpan GameTime = DateTime.Now - prevTime;
                prevTime = prevTime + GameTime;
                if (gameOn)
                {
                    HandleInput();
                    Update(GameTime);
                    Render();
                }
            }
        }

        public void Load()
        {
            playerScore = 0;
            player = new Player();
            player.UpdatePosition(300, 450);
            player.Velocity = 3500;

            spawnRate = 3000;
            fallRate = 0.1f;

            graphicsObjs.Add(player);
        }

        private void HandleInput()
        {
            List<Keys> tempInput = new List<Keys>(input);
            input.Clear();

            foreach (Keys key in tempInput)
            {
                switch (key)
                {
                    case Keys.A:
                        {
                            // buttonA.Execute();
                            buttonA.Execute(player, moveDistance);
                            //player.MoveLeft(moveDistance);
                            break;
                        }
                    case Keys.D:
                        {
                            buttonD.Execute(player, moveDistance);
                            break;
                        }
                    case Keys.Space:
                        {
                            if (shot == false)
                            {
                                Shoot();
                                shot = true;
                            }
                            break;
                        }
                }
            }
        }

        private void Update(TimeSpan time)
        {
            double timeElapsed = time.TotalMilliseconds / 1000;
            moveDistance = (int)(player.Velocity * timeElapsed);
            if (gameOn)
            {
                CheckForCollision();
                GC.Collect();
            } 
        }

        private void Render()
        {
            if (gameOn)
            {
                Bitmap bitmap = new Bitmap(playerCanvas.Width, playerCanvas.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.FillRectangle(new SolidBrush(Color.LightPink), new Rectangle(0, 0, playerCanvas.Width, playerCanvas.Height));

                //sparkle.Sparkle(graphics);
                foreach (Bullet bullet in bullets)
                { 
                    if (bullet.shouldDestroy())
                        bullet.isDirty = true;
                }

                foreach (GraphicsObject graphic in graphicsObjs)
                {
                    graphic.Render(graphics);
                }

                playerCanvas.Image = bitmap;
                Application.DoEvents();
            }   
        }

        private async void SpawnMonsters()
        {
            startedSpawn = true;
            while (isRunning)
            {
                var enemy = enemySpawner.Spawn();
                enemy.SetFallRate(fallRate);
                enemies.Add(enemy);
                graphicsObjs.Add((GraphicsObject)enemy);

                await Task.Delay(spawnRate);
            }
        }   
        //private async void SpawnSparkles()
        //{
        //    while (isRunning)
        //    {
        //        sparkle = SparkleFactory.GetSparkleObject(Randomizer.Instance.GetRandomNumberBetween(1, 4));
        //        sparkle.ChangeSize();
        //        await Task.Delay(2000);
        //    }
        //}

        private void CheckForCollision()
        {
            foreach(IEnemy enemy in enemies.ToList())
            {
                if(enemy.ShouldEndGame())
                {
                    gameOn = false;
                    ShowEndGamePanel();
                }
            }


            foreach(Bullet bullet in bullets.ToList())
            {
                
                foreach(IEnemy enemy in enemies.ToList())
                {
                    if (bullet.CollidesWith(enemy.GetObjectsPhysics()))
                    {

                        UpdateScore();

                        int deadEnemy = enemies.IndexOf(enemy);
                        int brokenBullet = bullets.IndexOf(bullet);
                        enemy.DestroyEnemy();
                        enemySpawner.Remove(enemy);
                        bullet.isDirty = true;
                        graphicsObjs.Remove(bullet);
                    }
                }
            }

            if(enemies.FindAll((enemy) => enemy.ShouldDestroy()).Count > 0)
                RemoveHit();
            DestroyBullets();
        }

        private void UpdateScore()
        {
            playerScore++;
            score.Text = "score: " + playerScore;
            fallRate += 0.007f;
            spawnRate -= 5;
        }

        private void RemoveHit()
        {
            var tempArr = enemies.FindAll((IEnemy enemy) => enemy.ShouldDestroy());
            graphicsObjs.RemoveAll((GraphicsObject enemy) => enemy is IEnemy && ((IEnemy)enemy).ShouldDestroy());
            enemies.RemoveAll((IEnemy enemy) => enemy.ShouldDestroy());
            tempArr.ForEach((enemy) => enemy.Reset());
        }

        private void DestroyBullets()
        {
            graphicsObjs.RemoveAll((GraphicsObject graphics) => (graphics is Bullet) && ((Bullet)graphics).isDirty == true);
                //((Bullet)bullet).isDirty == true));

            bullets.RemoveAll((Bullet bullet) => bullet.isDirty == true);
        }

        private void Shoot()
        {
            Bullet bullet = new Bullet();
            bullet.SpawnBullet(player.GetLocation());
            bullets.Add(bullet);
            graphicsObjs.Add(bullet);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (shot == true)
            {
                shot = false;
            }
        }

        private void RestartGame()
        {
            enemies.Clear();
            bullets.Clear();
            Load();
            UpdateScore();
            gameOn = true;
        }

        private void ShowEndGamePanel()
        {
           Button retry = new Button();
           retry.Text = "Start";
           DialogResult result = MessageBox.Show("Game Over! Your score is " + playerScore + " Try again?",
           "Game Over",
           MessageBoxButtons.YesNo);
           if (result == DialogResult.No)
           {
                isRunning = false;
           }
           if (result == DialogResult.Yes)
           {
               RestartGame();
           }
        }
    }
}
