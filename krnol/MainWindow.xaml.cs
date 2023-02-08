using System;
using System.Windows;
using System.Windows.Controls;

namespace krnol
{
    public partial class MainWindow : Window
    {
        private Button[,] buttons;
        private int turn = 0;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[,] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
            DisB();
        }

        private void ButC(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (turn % 2 == 0)
            {
                button.Content = "X";
                button.IsEnabled = false;

                if (ChW("X"))
                {
                    MessageBox.Show("X выиграл!");
                    DisB();
                    NewGameButton_Click.IsEnabled = true;
                }

                else if (ChD())
                {
                    MessageBox.Show("Ничья!");
                    DisB();
                    NewGameButton_Click.IsEnabled = true;
                }
                
                else
                {
                    turn++;
                    CompM();
                }
            }
        }

        private void Cl()
        {
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }

            turn = 0;
        }

        private void DisB()
        {
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        private void CompM()
        {
            Random random = new Random();
            int row, column;
            
            do
            {
                row = random.Next(0, 3);
                column = random.Next(0, 3);
            } 
            
            while (buttons[row, column].IsEnabled == false);
            buttons[row, column].Content = "O";
            buttons[row, column].IsEnabled = false;

            if (ChW("O"))
            {
                MessageBox.Show("O выиграл!");
                DisB();
                NewGameButton_Click.IsEnabled = true;
            }
            else if (ChD())
            {
                MessageBox.Show("Ничья!");
                DisB();
                NewGameButton_Click.IsEnabled = true;
            }

            else
            {
                turn++;
            }
        }
        private bool ChW(string symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content.ToString() == symbol && buttons[i, 1].Content.ToString() == symbol && buttons[i, 2].Content.ToString() == symbol)
                {
                    return true;
                }
                
                if (buttons[0, i].Content.ToString() == symbol && buttons[1, i].Content.ToString() == symbol && buttons[2, i].Content.ToString() == symbol)
                {
                    return true;
                }
            }
            
            if (buttons[0, 0].Content.ToString() == symbol && buttons[1, 1].Content.ToString() == symbol && buttons[2, 2].Content.ToString() == symbol)
            {
                return true;
            }
            
            if (buttons[0, 2].Content.ToString() == symbol && buttons[1, 1].Content.ToString() == symbol && buttons[2, 0].Content.ToString() == symbol)
            {
                return true;
            }
            
            return false;
        }
        private bool ChD()
        {
            foreach (Button button in buttons)
            {
                if (button.IsEnabled)
                {
                    return false;
                }
            }
            return true;
        }

        private void NG(object sender, RoutedEventArgs e)
        {
            NewGameButton_Click.IsEnabled = false;
            Cl();
        }
    }
}