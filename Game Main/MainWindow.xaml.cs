using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game_Main;

namespace SnakeTest
{

    public enum Direction { Stop, Up, Down, Left, Right }

    class Player 
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
        public double JumpProgress; // 0 - no jump, JumpProgress / speed_multiplier gives 1-9 
        public int[] JumpHeight = new int[10] { 0, 4, 7, 9, 12, 13, 12, 9, 7, 4 };
        public Image image;
        public int lifes;
        public Direction direction;
        public void Animate()
        {
        }
    }

    class Barrel
    {
        public int posY;
        public int posX;
        public int sizeX, sizeY;
        public Image image;
        public Direction direction;
        public void Animate()
        {
            
        }
    }

    class DonkeyKong
    {
        public double posX;
        public double posY;
        public int sizeX, sizeY;
        public Image image;
        public Direction direction;
        public void Animate()
        {

        }
    }

    class GameStatus {
    // state of the game
        public static Player Player;
        public static DonkeyKong DonkeyKong;
        public static List<Barrel> BarrelList;
        public int ScorePoints;
        public string PlayerName;

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        


        private Timer tick { get; set; }
        private Random rnd;

        private int speed_multiplier = 7;
        private int jump_multiplier = 2;
        private int time_multiplier = 1;
        private int tick_counter = 0;
        private int window_width;
        private int window_height;

        
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            GameStatus.Player = new Player();
            GameStatus.Player.posX = 10;
            GameStatus.Player.posY = 680;
            GameStatus.Player.sizeX = 40;
            GameStatus.Player.sizeY = 40;
            Canvas.SetTop(this.Player, 680);
            Canvas.SetLeft(this.Player, 10);
            Player.Width = 80;
            Player.Height = 80;
            GameStatus.Player.lifes = 3;

            GameStatus.DonkeyKong = new DonkeyKong();
            GameStatus.DonkeyKong.posX = 500;
            GameStatus.DonkeyKong.posY = 700;
            GameStatus.DonkeyKong.sizeX = 40;
            GameStatus.DonkeyKong.sizeY = 40;
            Canvas.SetTop(this.DonkeyKong, 700);
            Canvas.SetLeft(this.DonkeyKong, 500);
            DonkeyKong.Width = 60;
            DonkeyKong.Height = 60;

            this.time_multiplier = 10;
            this.rnd = new Random();
            Image pepsi = new Image();
            this.window_height = (Int32)this.Height;
            this.window_width = (Int32)this.Width;
            this.KeyDown += new KeyEventHandler(image_KeyDown);
            
            
            this.tick = new Timer();
            this.tick.Interval = 100 / this.time_multiplier;
            this.tick.Elapsed += tick_Elapsed;
            this.tick.Start();

        }
        
        private void tick_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            
            this.tick.Stop();
            this.tick.Interval = 100 / this.time_multiplier;

            this.Dispatcher.Invoke((Action)(() =>
            {

                switch (GameStatus.Player.direction)
                {
                    case Direction.Up:
                        if (GameStatus.Player.posY > 360)
                        {
                            GameStatus.Player.posY -= 1 * speed_multiplier;

                        }
                        break;
                    case Direction.Right:
                        GameStatus.Player.posX += 1 * speed_multiplier;
                        if (GameStatus.Player.posX > 1530)
                        {
                            GameStatus.Player.posX = 1530;
                            GameStatus.Player.direction = Direction.Stop;
                        }
                        break;
                    case Direction.Left:
                        GameStatus.Player.posX -= 1 * speed_multiplier;
                        if (GameStatus.Player.posX < 0)
                        {
                            GameStatus.Player.posX = 0;
                            GameStatus.Player.direction = Direction.Stop;
                        }
                        break;
                    default:
                        break;
                }

                Canvas.SetLeft(Player, GameStatus.Player.posX);

                int jumpHeightIndex = (int) Math.Floor(GameStatus.Player.JumpProgress / speed_multiplier);
                int extraJumpHeight = 10* GameStatus.Player.JumpHeight[jumpHeightIndex];
                Canvas.SetTop(Player, GameStatus.Player.posY - extraJumpHeight);
                if (GameStatus.Player.JumpProgress > 0)
                {
                    GameStatus.Player.JumpProgress += (double) speed_multiplier / jump_multiplier;
                    if (GameStatus.Player.JumpProgress >= speed_multiplier * GameStatus.Player.JumpHeight.Length)
                    {
                        GameStatus.Player.JumpProgress = 0;
                    }
                }


                // collision detection

                Rect rect1 = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), GameStatus.Player.sizeX, GameStatus.Player.sizeY);
                Rect rect2 = new Rect(Canvas.GetLeft(DonkeyKong), Canvas.GetTop(DonkeyKong), GameStatus.DonkeyKong.sizeX, GameStatus.DonkeyKong.sizeY);
                if (rect1.IntersectsWith(rect2))
                {
                    Canvas.SetTop(this.Player, 680);
                    Canvas.SetLeft(this.Player, 10);
                    GameStatus.Player.posX = 10;
                    GameStatus.Player.posY = 680;
                    GameStatus.Player.lifes--;
                    GameStatus.Player.direction = Direction.Stop;
                }
                if (GameStatus.Player.lifes == 0)
                {
                    Canvas.SetTop(this.Player, 680);
                    Canvas.SetLeft(this.Player, 10);
                    GameStatus.Player.posX = 10;
                    GameStatus.Player.posY = 680;
                    GameStatus.Player.direction = Direction.Stop;
                    ScoreWindow scoreWindow = new ScoreWindow();
                    scoreWindow.Show();
                    this.Close();
                    GameStatus.Player.lifes = 3;

                }




                this.tick_counter++;
                

                this.tick.Start();
            }));
        }
        private void AteAPepsi()
        {
            //add pts to score
        }
        
      


        private void image_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
               case Key.Up:
                    if (GameStatus.Player.posX > 1200 && GameStatus.Player.posX < 1250)
                    {
                        GameStatus.Player.direction = Direction.Up;
                    }
                    if (GameStatus.Player.posX > 270 && GameStatus.Player.posX < 320 && GameStatus.Player.posY == 360)
                    {
                        GameStatus.Player.direction = Direction.Up;
                    }
                    break;
                //case Key.W:
                   // direction = 0;
                  //  break;
               // case Key.Down:
                   // direction = 1;
                    //break;
                //case Key.S:
                   // direction = 1;
                  //  break;
                case Key.Right:
                   
                    GameStatus.Player.direction = Direction.Right;
                    break;
                case Key.Left:
                    
                    GameStatus.Player.direction = Direction.Left;
                    break;
                case Key.Space:
                    if (GameStatus.Player.JumpProgress == 0)
                    {
                        GameStatus.Player.JumpProgress = 1;
                    }
                    break;
                default:
                    break;
            }
        }
        
        private void image_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(Player);
        }
        public void MoveCharacter(int x, int y)
        {
            Canvas.SetTop(Player, x);
            Canvas.SetLeft(Player, y);
        }

        private void paintCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void image_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}