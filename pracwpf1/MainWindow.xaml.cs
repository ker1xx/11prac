using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace pracwpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image[] allimages = new Image[] { };
        private int user_figura;
        private int number_of_button;
        private List<int> avalible_buttons = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private List<int> busy_user_buttons = new List<int>();
        private List<int> busy_enemy_buttons = new List<int>();

        private int wins_count = 0;
        private int loses_count = 0;
        public MainWindow()
        {
            InitializeComponent();
            allimages = new Image[] { image1, image2, image3, image4, image5, image6, image7, image8, image9 };
            allbuttons_click();
        }

        private void allbuttons_click()
        {
            Button[] allbuttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            int i = 0;
            if (avalible_buttons.Count > 0)
            {
                foreach (Image but in allimages)
                {
                    if (i + 1 == number_of_button)
                    {
                        BitmapImage bi3 = new();
                        bi3.BeginInit();
                        if (user_figura == (int)krestik_ili_nolik.krestik)
                            bi3.UriSource = new Uri("Без названия.png", UriKind.Relative);
                        else
                            bi3.UriSource = new Uri("png-clipart-circle-area-angle-circle-red-s-text-circle.png", UriKind.Relative);
                        bi3.EndInit();
                        but.Source = bi3;
                        avalible_buttons.Remove(i + 1);
                        busy_user_buttons.Add(number_of_button);
                        i = 0;
                        break;
                    }
                    else
                        i++;
                }
            }
            win_check();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.first;
            allbuttons_click();
            enemy();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.second;
            allbuttons_click();
            enemy();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.third;
            allbuttons_click();
            enemy();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.fourth;
            allbuttons_click();
            enemy();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.fifth;
            allbuttons_click();
            enemy();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.sixth;
            allbuttons_click();
            enemy();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.seventh;
            allbuttons_click();
            enemy();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.eightth;
            allbuttons_click();
            enemy();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            number_of_button = (int)numberofbutton.ningth;
            allbuttons_click();
            enemy();
        }

        private void chose_noliki_Checked(object sender, RoutedEventArgs e)
        {
            user_figura = (int)krestik_ili_nolik.nolik;
            chose.Visibility = Visibility.Hidden;
            chose.IsEnabled = false;
            chose.Visibility = Visibility.Hidden;
            chose_krestiki.IsEnabled = false;
            chose_krestiki.Visibility = Visibility.Hidden;
            chose_noliki.IsEnabled = false;
            chose_noliki.Visibility = Visibility.Hidden;
            game_desk.IsEnabled = true;
            game_desk.Visibility = Visibility.Visible;
        }

        private void chose_krestiki_Checked(object sender, RoutedEventArgs e)
        {
            user_figura = (int)krestik_ili_nolik.krestik;
            chose.IsEnabled = false;
            chose.Visibility = Visibility.Hidden;
            chose_krestiki.IsEnabled = false;
            chose_krestiki.Visibility = Visibility.Hidden;
            chose_noliki.IsEnabled = false;
            chose_noliki.Visibility = Visibility.Hidden;
            game_desk.IsEnabled = true;
            game_desk.Visibility = Visibility.Visible;
        }
        private void enemy()
        {
            if (avalible_buttons.Count != 0)
            {
                Random rand = new();
                int chose = rand.Next(1, 10);
                int i = 0;
                int done = 0;
                while (done == 0)
                {
                    foreach (int isfine in avalible_buttons)
                    {
                        if (isfine == chose)
                        {
                            done = 1;
                            break;
                        }
                    }
                    if (done == 0)
                        chose = rand.Next(1, 10);
                }
                foreach (int free_number in avalible_buttons)
                {
                    if (free_number == chose)
                    {
                        BitmapImage bi3 = new();
                        bi3.BeginInit();
                        if (user_figura == (int)krestik_ili_nolik.krestik)
                            bi3.UriSource = new Uri("png-clipart-circle-area-angle-circle-red-s-text-circle.png", UriKind.Relative);
                        else
                            bi3.UriSource = new Uri("Без названия.png", UriKind.Relative);
                        bi3.EndInit();
                        int currentedeliting = avalible_buttons[i];
                        allimages[currentedeliting - 1].Source = bi3;
                        avalible_buttons.RemoveAt(i);
                        busy_enemy_buttons.Add(free_number);
                        break;
                    }
                    else
                        i++;
                }
                win_check();
            }
            else
                draw();
        }
        private void win_check()
        {
            if (avalible_buttons.Count != 0)
            {
                foreach (int but in busy_enemy_buttons)
                {
                    if (but == 1)
                        foreach (int butt in busy_enemy_buttons)
                        {
                            if (butt == 2)
                            {
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 3)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                            }
                            else if (butt == 5)
                            {
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                            }
                            else if (butt == 6)
                            {
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 9)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                            }
                        }
                    else if (but == 2)
                    {
                        foreach (int butt in busy_enemy_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 8)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                        }
                    }
                    else if (but == 3)
                    {
                        foreach (int butt in busy_enemy_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 9)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                            else if (butt == 4)
                            {
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        lose();
                                        return;
                                    };
                                }
                            }
                        }
                    }
                    else if (but == 6)
                    {
                        foreach (int butt in busy_enemy_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 4)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                        }
                    }
                    else if (but == 9)
                    {
                        foreach (int butt in busy_enemy_buttons)
                        {
                            if (butt == 8)
                                foreach (int buttt in busy_enemy_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        lose();
                                        return;
                                    }
                                }
                        }
                    }
                }
                /*user_check*/
                foreach (int but in busy_user_buttons)
                {
                    if (but == 1)
                        foreach (int butt in busy_user_buttons)
                        {
                            if (butt == 2)
                            {
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 3)
                                    {
                                        win();
                                        return;
                                    }
                                }
                            }
                            else if (butt == 5)
                            {
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        win();
                                        return;
                                    }
                                }
                            }
                            else if (butt == 6)
                            {
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 9)
                                    {
                                        win();
                                        return;
                                    }
                                }
                            }
                        }
                    else if (but == 2)
                    {
                        foreach (int butt in busy_user_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 8)
                                    {
                                        win();
                                        return;
                                    }
                                }
                        }
                    }
                    else if (but == 3)
                    {
                        foreach (int butt in busy_user_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 9)
                                    {
                                        win();
                                        return;
                                    }
                                }
                            else if (butt == 4)
                            {
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        win();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else if (but == 6)
                    {
                        foreach (int butt in busy_user_buttons)
                        {
                            if (butt == 5)
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 4)
                                    {
                                        win();
                                        return;
                                    }
                                }
                        }
                    }
                    else if (but == 9)
                    {
                        foreach (int butt in busy_user_buttons)
                        {
                            if (butt == 8)
                                foreach (int buttt in busy_user_buttons)
                                {
                                    if (buttt == 7)
                                    {
                                        win();
                                        return;
                                    }
                                }
                        }
                    }

                }
            }
            else
                draw();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            finish.IsEnabled = false;
            finish.Visibility = Visibility.Hidden;
            restart.IsEnabled = false;
            restart.Visibility = Visibility.Hidden;
            logout.IsEnabled = false;
            logout.Visibility = Visibility.Hidden;
            chose.IsEnabled = true;
            chose.Visibility = Visibility.Visible;
            chose_krestiki.IsChecked = false;
            chose_krestiki.Visibility = Visibility.Hidden;
            chose_noliki.IsChecked = false;
            chose_noliki.Visibility = Visibility.Hidden;
            chose_krestiki.IsEnabled = true;
            chose_krestiki.Visibility = Visibility.Visible;
            chose_noliki.IsEnabled = true;
            chose_noliki.Visibility = Visibility.Visible;
            foreach (Image but in allimages)
            {
                BitmapImage bi3 = new();
                bi3.BeginInit();
                bi3.UriSource = new Uri("", UriKind.Relative);
                bi3.EndInit();
                but.Source = bi3;
            }
            wins_loses.Content = ("Счёт:\n   " + wins_count/2 + ":" + loses_count);
            avalible_buttons.Add(1);
            avalible_buttons.Add(2);
            avalible_buttons.Add(3);
            avalible_buttons.Add(4);
            avalible_buttons.Add(5);
            avalible_buttons.Add(6);
            avalible_buttons.Add(7);
            avalible_buttons.Add(8);
            avalible_buttons.Add(9);
            busy_enemy_buttons.Clear();
            busy_user_buttons.Clear();
        }
        private void win()
        {
            game_desk.IsEnabled = false;
            game_desk.Visibility = Visibility.Hidden;
            finish.Content = "Вы победили!. Хотите сыграть еще раз?";
            finish.IsEnabled = true;
            finish.Visibility = Visibility.Visible;
            restart.IsEnabled = true;
            restart.Visibility = Visibility.Visible;
            logout.IsEnabled = true;
            logout.Visibility = Visibility.Visible;
            wins_count++;
        }
        private void lose()
        {
            game_desk.IsEnabled = false;
            game_desk.Visibility = Visibility.Hidden;
            finish.Content = "Вы проиграли!. Хотите сыграть еще раз?";
            finish.IsEnabled = true;
            finish.Visibility = Visibility.Visible;
            restart.IsEnabled = true;
            restart.Visibility = Visibility.Visible;
            logout.IsEnabled = true;
            logout.Visibility = Visibility.Visible;
            loses_count++;
        }
        private void draw()
        {
            game_desk.IsEnabled = false;
            game_desk.Visibility = Visibility.Hidden;
            finish.Content = "Ничья. Хотите сыграть еще раз?";
            finish.IsEnabled = true;
            finish.Visibility = Visibility.Visible;
            restart.IsEnabled = true;
            restart.Visibility = Visibility.Visible;
            logout.IsEnabled = true;
            logout.Visibility = Visibility.Visible;
        }
    }
}
