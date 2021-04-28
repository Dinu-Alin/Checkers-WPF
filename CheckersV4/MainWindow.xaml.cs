using CheckersV4.Services;
using CheckersV4.Models;
using CheckersV4.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using CheckersV4.Views;

namespace CheckersV4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            BoardVM.CurentWindows = this;
            InitializeComponent();
        }


        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            SplashNewGame newGame = new SplashNewGame();
            newGame.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();

                    OldGame oldGame = new OldGame();
                    oldGame.Pieces = (DataContext as BoardVM).Pieces;
                    oldGame.Player1Serialize = BoardVM.Player1;
                    oldGame.Player2Serialize = BoardVM.Player2;

                    SerializeAndDeserialize.SerializeObjectToXML<OldGame>(oldGame, saveFileDialog1.FileName);
                }
            }
        }


        private void open_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "(*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    if (filePath.Length > 0)
                    {
                        OldGame oldGame = new OldGame();
                        oldGame = SerializeAndDeserialize.DeserializeObjectToXML<OldGame>(filePath);
                        var temp = new BoardVM(oldGame);

                        DataContext = temp;
                    }
                }
            }
        }
        private void history_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Show();
            
        }
        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Checkers, also called draughts, board game, one of the world’s oldest games. Checkers is played by two persons who oppose each other across a board of 64 light and dark squares, the same as a chessboard. The 24 playing pieces are disk-shaped and of contrasting colours (whatever their colours, they are identified as black and white). At the start of the game, each contestant has 12 pieces arranged on the board. While the actual playing is always done on the dark squares, the board is often shown in reverse for clarity. The notation used in describing the game is based on numbering the squares on the board. The black pieces always occupy squares 1 to 12, and the white pieces invariably rest on squares 21 to 32.\nGroup number: 10LF292\nName:Dinu Ionut-Alin");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            SerializeAndDeserialize.SerializeObjectToXML<HashSet<Player>>((DataContext as BoardVM).Players, @"../../Resources/players.xml");
            Close();
        }

        public void StartNewGame()
        {
            newGame_Click(null, null);
        }
    }
}
