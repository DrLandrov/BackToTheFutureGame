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
        public int score;
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
        public int onCanvasX;
        public int onCanvasY;
        public Direction direction;
        public void Animate()
        {
            
        }
    }
    class Barrel1
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Barrel2
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Barrel3
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Barrel4
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Pepsi1
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Pepsi2
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Pepsi3
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
    }
    class Almanac
    {
        public double posY;
        public double posX;
        public int sizeX, sizeY;
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
        public static Barrel1 Barrel1;
        public static Barrel2 Barrel2;
        public static Barrel3 Barrel3;
        public static Barrel4 Barrel4;
        public static Pepsi1 Pepsi1;
        public static Pepsi2 Pepsi2;
        public static Pepsi3 Pepsi3;
        public static Almanac Almanac;
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
        private int jump_multiplier = 3;
        private int time_multiplier = 1;
        private int tick_counter = 0;
        private int window_width;
        private int window_height;
        private int ScorePoints = 0;

        
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

            GameStatus.Almanac = new Almanac();
            GameStatus.Almanac.posX = 10;
            GameStatus.Almanac.posY = 341;
            GameStatus.Almanac.sizeX = 40;
            GameStatus.Almanac.sizeY = 40;
            Canvas.SetTop(this.Almanac, 341);
            Canvas.SetLeft(this.Almanac, 10);
            Almanac.Width = 60;
            Almanac.Height = 60;

            GameStatus.Barrel1 = new Barrel1();
            GameStatus.Barrel1.posX = 1406;
            GameStatus.Barrel1.posY = 381;
            GameStatus.Barrel1.sizeX = 40;
            GameStatus.Barrel1.sizeY = 40;
            Canvas.SetTop(this.Barrel1, 381);
            Canvas.SetLeft(this.Barrel1, 1406);
            Barrel1.Width = 60;
            Barrel1.Height = 60;

            GameStatus.Barrel2 = new Barrel2();
            GameStatus.Barrel2.posX = 260;
            GameStatus.Barrel2.posY = 381;
            GameStatus.Barrel2.sizeX = 40;
            GameStatus.Barrel2.sizeY = 40;
            Canvas.SetTop(this.Barrel2, 381);
            Canvas.SetLeft(this.Barrel2, 260);
            Barrel2.Width = 60;
            Barrel2.Height = 60;

            GameStatus.Barrel3 = new Barrel3();
            GameStatus.Barrel3.posX = 486;
            GameStatus.Barrel3.posY = 50;
            GameStatus.Barrel3.sizeX = 40;
            GameStatus.Barrel3.sizeY = 40;
            Canvas.SetTop(this.Barrel3, 50);
            Canvas.SetLeft(this.Barrel3, 486);
            Barrel3.Width = 60;
            Barrel3.Height = 60;

            GameStatus.Barrel4 = new Barrel4();
            GameStatus.Barrel4.posX = 1026;
            GameStatus.Barrel4.posY = 50;
            GameStatus.Barrel4.sizeX = 40;
            GameStatus.Barrel4.sizeY = 40;
            Canvas.SetTop(this.Barrel4, 50);
            Canvas.SetLeft(this.Barrel4, 1026);
            Barrel4.Width = 60;
            Barrel4.Height = 60;

            GameStatus.Pepsi1 = new Pepsi1();
            GameStatus.Pepsi1.posX = 1499;
            GameStatus.Pepsi1.posY = 533;
            GameStatus.Pepsi1.sizeX = 40;
            GameStatus.Pepsi1.sizeY = 40;
            Canvas.SetTop(this.Pepsi1, 533);
            Canvas.SetLeft(this.Pepsi1, 1499);
            Pepsi1.Width = 60;
            Pepsi1.Height = 60;

            GameStatus.Pepsi2 = new Pepsi2();
            GameStatus.Pepsi2.posX = 810;
            GameStatus.Pepsi2.posY = 237;
            GameStatus.Pepsi2.sizeX = 40;
            GameStatus.Pepsi2.sizeY = 40;
            Canvas.SetTop(this.Pepsi2, 237);
            Canvas.SetLeft(this.Pepsi2, 810);
            Pepsi2.Width = 60;
            Pepsi2.Height = 60;

            GameStatus.Pepsi3 = new Pepsi3();
            GameStatus.Pepsi3.posX = 260;
            GameStatus.Pepsi3.posY = 10;
            GameStatus.Pepsi3.sizeX = 40;
            GameStatus.Pepsi3.sizeY = 40;
            Canvas.SetTop(this.Pepsi3, 10);
            Canvas.SetLeft(this.Pepsi3, 260);
            Pepsi3.Width = 60;
            Pepsi3.Height = 60;
            

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

                int jumpHeightIndex = (int)Math.Floor(GameStatus.Player.JumpProgress / speed_multiplier);
                int extraJumpHeight = 10 * GameStatus.Player.JumpHeight[jumpHeightIndex];
                Canvas.SetTop(Player, GameStatus.Player.posY - extraJumpHeight);
                if (GameStatus.Player.JumpProgress > 0)
                {
                    GameStatus.Player.JumpProgress += (double)speed_multiplier / jump_multiplier;
                    if (GameStatus.Player.JumpProgress >= speed_multiplier * GameStatus.Player.JumpHeight.Length)
                    {
                        GameStatus.Player.JumpProgress = 0;
                    }
                }


                // collision detection

                Rect player = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), GameStatus.Player.sizeX, GameStatus.Player.sizeY);
                Rect dk = new Rect(Canvas.GetLeft(DonkeyKong), Canvas.GetTop(DonkeyKong), GameStatus.DonkeyKong.sizeX, GameStatus.DonkeyKong.sizeY);
                Rect bullet1 = new Rect(Canvas.GetLeft(Barrel1), Canvas.GetTop(Barrel1), GameStatus.Barrel1.sizeX, GameStatus.Barrel1.sizeY);
                Rect bullet2 = new Rect(Canvas.GetLeft(Barrel2), Canvas.GetTop(Barrel2), GameStatus.Barrel2.sizeX, GameStatus.Barrel2.sizeY);
                Rect bullet3 = new Rect(Canvas.GetLeft(Barrel3), Canvas.GetTop(Barrel3), GameStatus.Barrel3.sizeX, GameStatus.Barrel3.sizeY);
                Rect bullet4 = new Rect(Canvas.GetLeft(Barrel4), Canvas.GetTop(Barrel4), GameStatus.Barrel4.sizeX, GameStatus.Barrel4.sizeY);
                Rect pepsi1 = new Rect(Canvas.GetLeft(Pepsi1), Canvas.GetTop(Pepsi1), GameStatus.Pepsi1.sizeX, GameStatus.Pepsi1.sizeY);
                Rect pepsi2 = new Rect(Canvas.GetLeft(Pepsi2), Canvas.GetTop(Pepsi2), GameStatus.Pepsi2.sizeX, GameStatus.Pepsi2.sizeY);
                Rect pepsi3 = new Rect(Canvas.GetLeft(Pepsi3), Canvas.GetTop(Pepsi3), GameStatus.Pepsi3.sizeX, GameStatus.Pepsi3.sizeY);
                Rect almanac = new Rect(Canvas.GetLeft(Almanac), Canvas.GetTop(Almanac), GameStatus.Almanac.sizeX, GameStatus.Almanac.sizeY);
                if (player.IntersectsWith(dk) || player.IntersectsWith(bullet1) || player.IntersectsWith(bullet2) || player.IntersectsWith(bullet3) || player.IntersectsWith(bullet4))
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
                if (player.IntersectsWith(pepsi1))
                {
                    GameStatus.Pepsi1.posX = 3499;
                    Canvas.SetTop(this.Pepsi1, 1533);
                    ScorePoints = ScorePoints + 100;
                    Pepsi1.Visibility = System.Windows.Visibility.Hidden;
                }
                if (player.IntersectsWith(pepsi2))
                {
                    GameStatus.Pepsi2.posX = 3499;
                    Canvas.SetTop(this.Pepsi2, 1533);
                    ScorePoints = ScorePoints + 100;
                    Pepsi2.Visibility = System.Windows.Visibility.Hidden;
                }
                if (player.IntersectsWith(pepsi3))
                {
                    GameStatus.Pepsi3.posX = 3499;
                    Canvas.SetTop(this.Pepsi3, 1533);
                    ScorePoints = ScorePoints + 100;
                    Pepsi3.Visibility = System.Windows.Visibility.Hidden;
                }
                if (player.IntersectsWith(almanac))
                {
                    MainWindow win2 = new MainWindow();
                    win2.Show();
                    this.Close();
                }
                lblScore.Content = ScorePoints;
                this.tick_counter++;
                

                this.tick.Start();
            }));
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