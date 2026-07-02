using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
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
using System.Windows.Threading;

namespace Tetris.Panels
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {

        private const int GAMESPEED = 700;// millisecond
        // List for add 2 sound wav
        List<System.Media.SoundPlayer> soundList = new List<System.Media.SoundPlayer>();
        DispatcherTimer timer;
        Random shapeRandom;
        private int rowCount = 0;
        private int columnCount = 0;
        private int leftPos = 0;
        private int downPos = 0;
        private int currentTetrominoWidth;
        private int currentTetrominoHeigth;
        private int currentShapeNumber;
        private int nextShapeNumber;
        private int tetrisGridColumn;
        private int tetrisGridRow;
        private int rotation = 0;
        private bool gameActive = false;
        private bool nextShapeDrawed = false;
        private int[,] currentTetromino = null;
        private bool isRotated = false;
        private bool bottomCollided = false;
        private bool leftCollided = false;
        private bool rightCollided = false;
        private bool isGameOver = false;
        private int gameSpeed;
        private int levelScale = 60;// every 60 second increase level by 1 until 10
        private double gameSpeedCounter = 0;
        private int gameLevel = 1;
        private int gameScore = 0;
        private static Color O_TetrominoColor = Colors.GreenYellow;
        private static Color I_TetrominoColor = Colors.Red;
        private static Color T_TetrominoColor = Colors.Gold;
        private static Color S_TetrominoColor = Colors.Violet;
        private static Color Z_TetrominoColor = Colors.DeepSkyBlue;
        private static Color J_TetrominoColor = Colors.Cyan;
        private static Color L_TetrominoColor = Colors.LightSeaGreen;
        List<int> currentTetrominoRow = null;
        List<int> currentTetrominoColumn = null;

        public Tetris.Controls.BaseWindow ParentWindow { get; set; }
        public Tetris.Controls.GameButton StartStopButton { get; set; }
        public Tetris.Panels.Stats StatsPanel { get; set; }
        public Tetris.Panels.NextBloc NextBlocPanel { get; set; }


        // Color for shape tetromino
        Color[] shapeColor = {  O_TetrominoColor,I_TetrominoColor,
                                T_TetrominoColor,S_TetrominoColor,
                                Z_TetrominoColor,J_TetrominoColor,
                                L_TetrominoColor
                             };
        // ---------
        string[] arrayTetrominos = { "","O_Tetromino" , "I_Tetromino_0",
                                        "T_Tetromino_0","S_Tetromino_0",
                                        "Z_Tetromino_0","J_Tetromino_0",
                                        "L_Tetromino_0"
                                   };

        #region Array of tetrominos shape 

        // arrays of tetromino shape
        //---- O Tetromino------------
        public int[,] O_Tetromino = new int[2, 2] { { 1, 1 },  // * *
                                                    { 1, 1 }}; // * *

        //---- I Tetromino------------
        public int[,] I_Tetromino_0 = new int[2, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };// * * * *

        public int[,] I_Tetromino_90 = new int[4, 2] {{ 1,0 },   // *  
                                                       { 1,0 },  // *
                                                       { 1,0 },  // *
                                                       { 1,0 }}; // *
        //---- T Tetromino------------
        public int[,] T_Tetromino_0 = new int[2, 3] {{0,1,0},    //    * 
                                                     {1,1,1}};   //  * * *

        public int[,] T_Tetromino_90 = new int[3, 2] {{1,0},     //  * 
                                                      {1,1},     //  * *
                                                      {1,0}};    //  *  

        public int[,] T_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * *
                                                       {0,1,0}}; //   * 

        public int[,] T_Tetromino_270 = new int[3, 2] {{0,1},    //   * 
                                                       {1,1},    // * *
                                                       {0,1}};   //   *  
        //---- S Tetromino------------
        public int[,] S_Tetromino_0 = new int[2, 3] {{0,1,1},    //   * *
                                                     {1,1,0}};   // * *

        public int[,] S_Tetromino_90 = new int[3, 2] {{1,0},     // *
                                                      {1,1},     // * *
                                                      {0,1}};    //   *
        //---- Z Tetromino------------
        public int[,] Z_Tetromino_0 = new int[2, 3] {{1,1,0},    // * *
                                                     {0,1,1}};   //   * *

        public int[,] Z_Tetromino_90 = new int[3, 2] {{0,1},     //   *
                                                      {1,1},     // * *
                                                      {1,0}};    // *
        //---- J Tetromino------------
        public int[,] J_Tetromino_0 = new int[2, 3] {{1,0,0},    // * 
                                                     {1,1,1}};   // * * *

        public int[,] J_Tetromino_90 = new int[3, 2] {{1,1},     // * * 
                                                      {1,0},     // *
                                                      {1,0}};    // * 

        public int[,] J_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * * 
                                                       {0,0,1}}; //     *

        public int[,] J_Tetromino_270 = new int[3, 2] {{0,1},    //   * 
                                                       {0,1},    //   *
                                                       {1,1 }};  // * *

        //---- L Tetromino------------
        public int[,] L_Tetromino_0 = new int[2, 3] {{0,0,1},    //     * 
                                                     {1,1,1}};   // * * *

        public int[,] L_Tetromino_90 = new int[3, 2] {{1,0},     // *  
                                                      {1,0},     // *
                                                      {1,1}};    // * *

        public int[,] L_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * * 
                                                       {1,0,0}}; // *

        public int[,] L_Tetromino_270 = new int[3, 2] {{1,1},    // * * 
                                                       {0,1},    //   *
                                                       {0,1 }};  //   *

        public object Task { get; private set; }
        #endregion

        public Board()
        {
            InitializeComponent();
            this.gameSpeed = GAMESPEED;
            //created event for key press
            this.Loaded += Board_Loaded;

            // init timer
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed); // 700 millisecond
            this.timer.Tick += Timer_Tick;
            this.tetrisGridColumn = tetrisGrid.ColumnDefinitions.Count;
            this.tetrisGridRow = tetrisGrid.RowDefinitions.Count;
            this.shapeRandom = new Random();
            this.currentShapeNumber = shapeRandom.Next(1, 8);
            this.nextShapeNumber = shapeRandom.Next(1, 8);
            //this.nextTxt.Visibility = levelTxt.Visibility = GameOverTxt.Visibility = Visibility.Collapsed;
            // Add the 2 wav sound in list
           
        }

        public static readonly DependencyProperty DarkModeProperty =
  DependencyProperty.Register(nameof(DarkMode), typeof(bool),
      typeof(Board), new PropertyMetadata(false));

        public bool DarkMode
        {
            get => (bool)GetValue(DarkModeProperty);
            set => SetValue(DarkModeProperty, value);
        }

        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ParentWindow != null)
                this.ParentWindow.KeyDown += ParentWindow_KeyDown;

            if(this.StartStopButton != null)
                this.StartStopButton.Click += this.StartStopButton_Click;

            System.Windows.Resources.StreamResourceInfo collidedSoundResource = Application.GetResourceStream(new Uri("Sounds/Collided.wav", UriKind.Relative));
            System.Windows.Resources.StreamResourceInfo deleteLineSoundResource = Application.GetResourceStream(new Uri("Sounds/DeleteLine.wav", UriKind.Relative));
            if (collidedSoundResource != null && deleteLineSoundResource != null)
            {
                this.soundList.Add(new SoundPlayer(collidedSoundResource.Stream));
                this.soundList.Add(new SoundPlayer(deleteLineSoundResource.Stream));
            }

        }

        private void ParentWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer.IsEnabled) { return; }
            switch (e.Key.ToString())
            {
                case "Up":
                    rotation += 90;
                    if (rotation > 270) { rotation = 0; }
                    this.ShapeRotation(rotation);
                    break;
                case "Down":
                    downPos++;
                    break;
                case "Right":
                    // Check if collided
                    this.TetroCollided();
                    if (!rightCollided) { leftPos++; }
                    rightCollided = false;
                    break;
                case "Left":
                    // Check if collided
                    this.TetroCollided();
                    if (!leftCollided) { leftPos--; }
                    leftCollided = false;
                    break;
            }
            this.MoveShape();
        }

        private void ShapeRotation(int _rotation)
        {
            // Check if collided
            if (this.RotationCollided(rotation))
            {
                rotation -= 90;
                return;
            }

            if (arrayTetrominos[currentShapeNumber].IndexOf("I_") == 0)
            {
                if (_rotation > 90) { _rotation = rotation = 0; }
                currentTetromino = this.GetVariableByString("I_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("T_") == 0)
            {
                currentTetromino = this.GetVariableByString("T_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("S_") == 0)
            {
                if (_rotation > 90) { _rotation = rotation = 0; }
                currentTetromino = this.GetVariableByString("S_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("Z_") == 0)
            {
                if (_rotation > 90) { _rotation = rotation = 0; }
                currentTetromino = this.GetVariableByString("Z_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("J_") == 0)
            {
                currentTetromino = this.GetVariableByString("J_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("L_") == 0)
            {
                currentTetromino = this.GetVariableByString("L_Tetromino_" + _rotation);
            }
            else if (arrayTetrominos[currentShapeNumber].IndexOf("O_") == 0) // Do not rotate this
            {
                return;
            }

            isRotated = true;
            this.AddShape(currentShapeNumber, leftPos, downPos);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.downPos++;
            this.MoveShape();
            if (this.gameSpeedCounter >= levelScale)
            {
                if (this.gameSpeed >= 50)
                {
                    this.gameSpeed -= 50;
                    this.gameLevel++;
                    this.StatsPanel.levelTextBlock.Text = gameLevel.ToString();
                }
                else { gameSpeed = 50; }
                this.timer.Stop();
                this.timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
                this.timer.Start();
                this.gameSpeedCounter = 0;
            }
            this.gameSpeedCounter += (gameSpeed / 1000f);

        }

        // Button start stop clicked method
        public void StartStopButton_Click(object sender, RoutedEventArgs e)
        {

            if (isGameOver)
            {
                tetrisGrid.Children.Clear();
                this.NextBlocPanel.nextShapeCanvas.Children.Clear();
                //GameOverTxt.Visibility = Visibility.Collapsed;
                isGameOver = false;
            }
            if (!timer.IsEnabled)
            {
                if (!gameActive) { this.StatsPanel.scoreTextBlock.Text = "0"; leftPos = 3; this.AddShape(this.currentShapeNumber, leftPos); }
                //nextTxt.Visibility = levelTxt.Visibility = Visibility.Visible;
                this.StatsPanel.levelTextBlock.Text = gameLevel.ToString();
                timer.Start();
                this.StartStopButton.Content = "Stop";
                this.StartStopButton.Icon = "";
                this.StartStopButton.Background = Brushes.SlateBlue;
                gameActive = true;
            }
            else
            {
                timer.Stop();
                this.StartStopButton.Content = "Start";
                this.StartStopButton.Icon = "";
                this.StartStopButton.Background = Brushes.Green;
            }
        }

        // Add new shape tetromino in grid
        private void AddShape(int shapeNumber, int _left = 0, int _down = 0)
        {
            // Remove previous position of tetromino
            RemoveShape();
            currentTetrominoRow = new List<int>();
            currentTetrominoColumn = new List<int>();
            Rectangle square = null;
            if (!isRotated)
            {
                currentTetromino = null;
                currentTetromino = GetVariableByString(arrayTetrominos[shapeNumber].ToString());
            }
            int firstDim = currentTetromino.GetLength(0);
            int secondDim = currentTetromino.GetLength(1);
            currentTetrominoWidth = secondDim;
            currentTetrominoHeigth = firstDim;
            // This is only for I Tetromino
            if (currentTetromino == I_Tetromino_90)
            {
                currentTetrominoWidth = 1;
            }
            else if (currentTetromino == I_Tetromino_0) { currentTetrominoHeigth = 1; }
            //------------------------------------
            for (int row = 0; row < firstDim; row++)
            {
                for (int column = 0; column < secondDim; column++)
                {
                    int bit = currentTetromino[row, column];
                    if (bit == 1)
                    {
                        square = GetBasicSquare(shapeColor[shapeNumber - 1]);
                        tetrisGrid.Children.Add(square);
                        square.Name = "moving_" + Grid.GetRow(square) + "_" + Grid.GetColumn(square);
                        if (_down >= tetrisGrid.RowDefinitions.Count - currentTetrominoHeigth)
                        {
                            _down = tetrisGrid.RowDefinitions.Count - currentTetrominoHeigth;
                        }
                        Grid.SetRow(square, rowCount + _down);
                        Grid.SetColumn(square, columnCount + _left);
                        currentTetrominoRow.Add(rowCount + _down);
                        currentTetrominoColumn.Add(columnCount + _left);

                    }
                    columnCount++;
                }
                columnCount = 0;
                rowCount++;
            }
            columnCount = 0;
            rowCount = 0;
            if (!nextShapeDrawed)
            {
                this.DrawNextShape(nextShapeNumber);
            }
        }

        // Add new shape in new location
        private void MoveShape()
        {
            leftCollided = false;
            rightCollided = false;

            // Check if collided
            this.TetroCollided();
            if (leftPos > (tetrisGridColumn - currentTetrominoWidth))
            {
                leftPos = (tetrisGridColumn - currentTetrominoWidth);
            }
            else if (leftPos < 0) { leftPos = 0; }

            if (bottomCollided)
            {
                this.ShapeStoped();
                return;
            }
            AddShape(currentShapeNumber, leftPos, downPos);
        }

        // Check collided if rotated tetromino 
        private bool RotationCollided(int _rotation)
        {
            if (this.CheckCollided(0, currentTetrominoWidth - 1)) { return true; }//Bottom collision 
            else if (this.CheckCollided(0, -(currentTetrominoWidth - 1))) { return true; }// Top collision
            else if (this.CheckCollided(0, -1)) { return true; }// Top collision
            else if (this.CheckCollided(-1, currentTetrominoWidth - 1)) { return true; }// Left collision
            else if (this.CheckCollided(1, currentTetrominoWidth - 1)) { return true; }// Right collision
            return false;
        }

        // Check if collided in sides , bottom and other shapes 
        private void TetroCollided()
        {
            bottomCollided = this.CheckCollided(0, 1);
            leftCollided = this.CheckCollided(-1, 0);
            rightCollided = this.CheckCollided(1, 0);
        }

        //Check collided
        private bool CheckCollided(int _leftRightOffset, int _bottomOffset)
        {
            Rectangle movingSquare;
            int squareRow = 0;
            int squareColumn = 0;
            for (int i = 0; i <= 3; i++)
            {
                squareRow = currentTetrominoRow[i];
                squareColumn = currentTetrominoColumn[i];
                try
                {
                    movingSquare = (Rectangle)tetrisGrid.Children
                    .Cast<UIElement>()
                    .FirstOrDefault(e => Grid.GetRow(e) == squareRow + _bottomOffset && Grid.GetColumn(e) == squareColumn + _leftRightOffset);
                    if (movingSquare != null)
                    {
                        if (movingSquare.Name.IndexOf("arrived") == 0)
                        {
                            return true;
                        }
                    }
                }
                catch { }
            }
            if (downPos > (tetrisGridRow - currentTetrominoHeigth)) { return true; }
            return false;
        }

        // Draw next shape tetromino in nextShapeCanvas 
        private void DrawNextShape(int shapeNumber)
        {
            this.NextBlocPanel.nextShapeCanvas.Children.Clear();
            int[,] nextShapeTetromino = null;
            nextShapeTetromino = GetVariableByString(arrayTetrominos[shapeNumber]);
            int firstDim = nextShapeTetromino.GetLength(0);
            int secondDim = nextShapeTetromino.GetLength(1);
            int x = 0;
            int y = 0;
            Rectangle square;
            for (int row = 0; row < firstDim; row++)
            {
                for (int column = 0; column < secondDim; column++)
                {
                    int bit = nextShapeTetromino[row, column];
                    if (bit == 1)
                    {
                        square = GetBasicSquare(shapeColor[shapeNumber - 1]);
                        this.NextBlocPanel.nextShapeCanvas.Children.Add(square);
                        Canvas.SetLeft(square, x);
                        Canvas.SetTop(square, y);
                    }
                    x += 25;
                }
                x = 0;
                y += 25;
            }
            nextShapeDrawed = true;
        }


        // This method called when shape it arrives at the bottom or collided
        private void ShapeStoped()
        {
            timer.Stop();
            playSound(0);
            // Game over condition
            if (downPos <= 2)
            {
                GameOver();
                return;
            }

            int index = 0;
            while (index < tetrisGrid.Children.Count)
            {
                UIElement element = tetrisGrid.Children[index];
                if (element is Rectangle)
                {
                    Rectangle square = (Rectangle)element;
                    if (square.Name.IndexOf("moving_") == 0)
                    {
                        // Replace the name of squares arrived tetromino
                        string newName = square.Name.Replace("moving_", "arrived_");
                        square.Name = newName;
                    }
                }
                index++;
            }
            // Check if line  is complete  and descend down the other shapes
            CheckComplete();
            Reset();
            timer.Start();

        }
        // Method for check if complete line
        private void CheckComplete()
        {
            int gridRow = tetrisGrid.RowDefinitions.Count;
            int gridColumn = tetrisGrid.ColumnDefinitions.Count;
            int squareCount = 0;
            for (int row = gridRow; row >= 0; row--)
            {
                squareCount = 0;
                for (int column = gridColumn; column >= 0; column--)
                {
                    Rectangle square;
                    square = (Rectangle)tetrisGrid.Children
                   .Cast<UIElement>()
                   .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
                    if (square != null)
                    {
                        if (square.Name.IndexOf("arrived") == 0)
                        {
                            squareCount++;
                        }
                    }
                }

                // If squareCount == gridColumn this means tha the line is completed and must to be delete
                if (squareCount == gridColumn)
                {
                    playSound(1);
                    DeleteLine(row);
                    this.StatsPanel.scoreTextBlock.Text = GetScore().ToString();
                    CheckComplete();
                }
            }
        }

        // Delete complete square line
        private void DeleteLine(int row)
        {
            // Delete complete line
            for (int i = 0; i < tetrisGrid.ColumnDefinitions.Count; i++)
            {
                Rectangle square;
                try
                {
                    square = (Rectangle)tetrisGrid.Children
                   .Cast<UIElement>()
                   .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == i);
                    tetrisGrid.Children.Remove(square);
                }
                catch { }

            }
            // Move down the rest shape
            foreach (UIElement element in tetrisGrid.Children)
            {
                Rectangle square = (Rectangle)element;
                if (square.Name.IndexOf("arrived") == 0 && Grid.GetRow(square) <= row)
                {
                    Grid.SetRow(square, Grid.GetRow(square) + 1);
                }
            }
        }
        // Get the score
        private int GetScore()
        {
            gameScore += 50 * gameLevel;
            return gameScore;
        }

        // Some reset
        public void Reset()
        {
            downPos = 0;
            leftPos = 3;
            isRotated = false;
            rotation = 0;
            currentShapeNumber = nextShapeNumber;
            if (!isGameOver) { this.AddShape(currentShapeNumber, leftPos); }
            nextShapeDrawed = false;
            shapeRandom = new Random();
            nextShapeNumber = shapeRandom.Next(1, 8);
            bottomCollided = false;
            leftCollided = false;
            rightCollided = false;
        }
        // The game over reset
        private void GameOver()
        {
            isGameOver = true;
            Reset();
            this.StartStopButton.Content = "Start";
            this.StartStopButton.Icon = "";
            this.StartStopButton.Background = Brushes.Green;
            Tetris.Messages.FailureGame failureGame = new Messages.FailureGame(this);
            failureGame.Owner = this.ParentWindow;
            failureGame.ShowDialog();
            rowCount = 0;
            columnCount = 0;
            leftPos = 0;
            gameSpeedCounter = 0;
            gameSpeed = GAMESPEED;
            gameLevel = 1;
            gameActive = false;
            gameScore = 0;
            nextShapeDrawed = false;
            currentTetromino = null;
            currentShapeNumber = shapeRandom.Next(1, 8);
            nextShapeNumber = shapeRandom.Next(1, 8);
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);

        }


        // Remove shape from grid   
        private void RemoveShape()
        {
            int index = 0;
            while (index < tetrisGrid.Children.Count)
            {
                UIElement element = tetrisGrid.Children[index];
                if (element is Rectangle)
                {
                    Rectangle square = (Rectangle)element;
                    if (square.Name.IndexOf("moving_") == 0)
                    {
                        tetrisGrid.Children.Remove(element);
                        index = -1;
                    }
                }
                index++;
            }

        }

        // Created the basic square for tetris shape
        private Rectangle GetBasicSquare(Color rectColor)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 25;
            rectangle.Height = 25;
            rectangle.StrokeThickness = 1;
            rectangle.Stroke = Brushes.White;
            rectangle.Fill = GetGradientColor(rectColor);
            return rectangle;
        }

        // Get the gradient color for basic square
        private LinearGradientBrush GetGradientColor(Color clr)
        {
            LinearGradientBrush gradientColor = new LinearGradientBrush();
            gradientColor.StartPoint = new Point(0, 0);
            gradientColor.EndPoint = new Point(1, 1.5);
            GradientStop black = new GradientStop();
            black.Color = Colors.Black;
            black.Offset = -1.5;
            gradientColor.GradientStops.Add(black);
            GradientStop other = new GradientStop();
            other.Color = clr;
            other.Offset = 0.70;
            gradientColor.GradientStops.Add(other);
            return gradientColor;
        }

        // Access variable by string name
        private int[,] GetVariableByString(string variable)
        {
            return (int[,])this.GetType().GetField(variable).GetValue(this);
        }
        // Play sound. index=0 is for collided.wav and index=1 for deleteLine.wav
        private void playSound(int index)
        {
            //soundList[index].Play();
        }

    }
}
