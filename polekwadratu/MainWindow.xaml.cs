﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace polekwadratu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dlugoscBoku.Text == "")
            {
                MessageBox.Show("Pole nie moze byc puste");
                schowajwynik();
                return;
            }
            else if(!int.TryParse(dlugoscBoku.Text, out _))
            {
                MessageBox.Show("Tekst musi byc liczbą");
                schowajwynik();
                return;
            }
            else if(Convert.ToInt64(dlugoscBoku.Text) <= 0)
            {
                MessageBox.Show("Liczba nie moze byc równa lub mniejsza niż zero");
                schowajwynik();
                return;
            }
            var a = Convert.ToInt32(dlugoscBoku.Text);
            long pole  = a * a; 
            long obwod = 4 * a;
            if (wynikLabel.Visibility == Visibility.Hidden)
            {
                wynikLabel.Visibility = Visibility.Visible;
                poleWynik.Visibility = Visibility.Visible;
                poleWynikLabel.Visibility = Visibility.Visible;
                obwodWynik.Visibility = Visibility.Visible;
                obwodWynikLabel.Visibility = Visibility.Visible;
            }
            poleWynik.Content = pole.ToString() + "cm^2";
            obwodWynik.Content = obwod.ToString() + "cm";


            //Rysowanie

            double bok;
            if(double.TryParse(dlugoscBoku.Text, out bok) && bok <= 195)
            {
                rysunek.Height = bok;
                rysunek.Width = bok;
                SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString(kolory.Text);
                rysunek.Stroke = color;
                rysunek.Fill = color;
                rysunek.Opacity = (przezroczystosc.IsChecked.Value) ? 0.5 : 1;
            }
            else
            {
                MessageBox.Show("Brak Danych lub za duzy blok");
            }




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            schowajwynik();
            dlugoscBoku.Text = "";
        }
        private void schowajwynik()
        {
            if (wynikLabel.Visibility == Visibility.Visible)
            {
                wynikLabel.Visibility = Visibility.Hidden;
                poleWynik.Visibility = Visibility.Hidden;
                poleWynikLabel.Visibility = Visibility.Hidden;
                obwodWynik.Visibility = Visibility.Hidden;
                obwodWynikLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
