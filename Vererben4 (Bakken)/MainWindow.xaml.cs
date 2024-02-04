using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace Vererben4__Bakken_
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Aether aether = new Aether();
        private Albedo albedo = new Albedo();
        private RadienShogun radienShogun = new RadienShogun();
        private YaeMiko yaeMiko = new YaeMiko();
        private GameOver gameover = new GameOver();
        private Bombe bombe = new Bombe();
        private DispatcherTimer timer = new DispatcherTimer();
        private double counter;
        private int xchange = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.05);
            timer.Tick += Timer_Tick;
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            Counter_Tick.Content = Convert.ToString(counter);

            aether.Posy = (double)aether.CanvasSpieler.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt
            
           if(aether.Posy <= 273)
            {
                aether.CanvasSpieler.SetValue(Canvas.TopProperty, aether.Posy + aether.Gravity);
            }

            albedo.Posy = (double)albedo.CanvasSpieler.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

            if (albedo.Posy <= 273)
            {
                albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy + albedo.Gravity);
            }

            yaeMiko.Posy = (double)yaeMiko.CanvasSpieler.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

            if (yaeMiko.Posy <= 273)
            {
                yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy + yaeMiko.Gravity);
            }

            radienShogun.Posy = (double)radienShogun.CanvasSpieler.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

            if (radienShogun.Posy <= 273)
            {
                radienShogun.CanvasSpieler.SetValue(Canvas.TopProperty, radienShogun.Posy + radienShogun.Gravity);
            }

            bombe.Posx = (double)bombe.CanvasSpieler.GetValue(Canvas.LeftProperty);
            bombe.Posy = (double)bombe.CanvasSpieler.GetValue(Canvas.TopProperty);
            bombe.CanvasSpieler.SetValue(Canvas.LeftProperty, bombe.Posx + bombe.Speed);//bombe läüft

            //Hier wurde Position von Bombo geändert
            if (bombe.Posx == 740)   
            {
                bombe.CanvasSpieler.SetValue(Canvas.LeftProperty, bombe.Posx=0);
                
                if(xchange == 1)
                {
                    bombe.CanvasSpieler.SetValue(Canvas.TopProperty, bombe.Posy = 20);
                    xchange = 2;
                }
                else if (xchange == 2)
                {
                    bombe.CanvasSpieler.SetValue(Canvas.TopProperty, bombe.Posy = 120);
                    xchange = 3;
                }
                else if (xchange == 3)
                {
                    bombe.CanvasSpieler.SetValue(Canvas.TopProperty, bombe.Posy = 250);
                    xchange = 1;
                }
                

            }

            # region Wenn bombe mit Spieler berührt, dann gameover 
            if (Canvas.GetLeft(aether.CanvasSpieler) + aether.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            && Canvas.GetLeft(aether.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            && Canvas.GetTop(aether.CanvasSpieler) + aether.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            && Canvas.GetTop(aether.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            {

                timer.Stop();
                CanvesSpielerContainer.Children.Clear();
                CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
              
            }
            if (Canvas.GetLeft(albedo.CanvasSpieler) + albedo.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            && Canvas.GetLeft(albedo.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            && Canvas.GetTop(albedo.CanvasSpieler) + albedo.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            && Canvas.GetTop(albedo.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            {

                timer.Stop();
                CanvesSpielerContainer.Children.Clear();
                CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
            }
            if (Canvas.GetLeft(radienShogun.CanvasSpieler) + radienShogun.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            && Canvas.GetLeft(radienShogun.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            && Canvas.GetTop(radienShogun.CanvasSpieler) + radienShogun.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            && Canvas.GetTop(radienShogun.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            {

                timer.Stop();
                CanvesSpielerContainer.Children.Clear();
                CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
            }
            if (Canvas.GetLeft(yaeMiko.CanvasSpieler) + yaeMiko.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            && Canvas.GetLeft(yaeMiko.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            && Canvas.GetTop(yaeMiko.CanvasSpieler) + yaeMiko.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            && Canvas.GetTop(yaeMiko.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            {

                timer.Stop();
                CanvesSpielerContainer.Children.Clear();
                CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
            }
           #endregion

        }
        #region KeyControl erstellt
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (CanvesSpielerContainer.Children.Contains(aether.CanvasSpieler))
            {
                aether.Posy = (double)aether.CanvasSpieler.GetValue(Canvas.TopProperty);
                aether.Posx = (double)aether.CanvasSpieler.GetValue(Canvas.LeftProperty);//aktuelle Wert wird ermittelt

                if (e.Key == Key.Up)
                {
                    aether.CanvasSpieler.SetValue(Canvas.TopProperty, aether.Posy + aether.Speed);
                }
                if (e.Key == Key.Down)
                {
                    aether.CanvasSpieler.SetValue(Canvas.TopProperty, aether.Posy - aether.Speed);
                }
                if (e.Key == Key.Left)
                {
                    aether.CanvasSpieler.SetValue(Canvas.LeftProperty, aether.Posx + aether.Speed);
                }
                if (e.Key == Key.Right)
                {
                    aether.CanvasSpieler.SetValue(Canvas.LeftProperty, aether.Posx - aether.Speed);
                }
                
                if (aether.Posx < 0)//links
                {
                    aether.CanvasSpieler.SetValue(Canvas.LeftProperty, aether.Posx = 0);
                }
                if (aether.Posx > 720)//recht
                {
                    aether.CanvasSpieler.SetValue(Canvas.LeftProperty, aether.Posx = 720);
                }
                if (aether.Posy < 0)//oben
                {
                    aether.CanvasSpieler.SetValue(Canvas.TopProperty, aether.Posy = 0);
                }
                if (aether.Posy > 275)//unten
                {
                    aether.CanvasSpieler.SetValue(Canvas.TopProperty, aether.Posy = 275);
                }
                if (aether.Posy > 270 && aether.Posx < 300)
                {
                    timer.Stop();
                    CanvesSpielerContainer.Children.Clear();
                    CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);      
                }
            }
            if (CanvesSpielerContainer.Children.Contains(albedo.CanvasSpieler))
            {
                albedo.Posy = (double)albedo.CanvasSpieler.GetValue(Canvas.TopProperty);
                albedo.Posx = (double)albedo.CanvasSpieler.GetValue(Canvas.LeftProperty);

                if (e.Key == Key.Up)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy + albedo.Speed);
                }
                if (e.Key == Key.Down)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy - albedo.Speed);
                }
                if (e.Key == Key.Left)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx + albedo.Speed);
                }
                if (e.Key == Key.Right)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx - albedo.Speed);
                }
                if (albedo.Posx < 10)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx = 10);
                }
                if (albedo.Posx > 720)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx = 720);
                }
                if (albedo.Posy < 0)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy = 0);
                }
                if (albedo.Posy > 275)
                {
                    albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy = 275);
                }
                if (albedo.Posy > 270 && albedo.Posx < 300)
                {
                    timer.Stop();
                    CanvesSpielerContainer.Children.Clear();
                    CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
                }
            }
            if (CanvesSpielerContainer.Children.Contains(radienShogun.CanvasSpieler))
            {
                radienShogun.Posy = (double)radienShogun.CanvasSpieler.GetValue(Canvas.TopProperty);
                radienShogun.Posx = (double)radienShogun.CanvasSpieler.GetValue(Canvas.LeftProperty);

                if (e.Key == Key.Up)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.TopProperty, radienShogun.Posy + radienShogun.Speed);
                }
                if (e.Key == Key.Down)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.TopProperty, radienShogun.Posy - radienShogun.Speed);
                }
                if (e.Key == Key.Left)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, radienShogun.Posx + radienShogun.Speed);
                }
                if (e.Key == Key.Right)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, radienShogun.Posx - radienShogun.Speed);
                }
                if (radienShogun.Posx < 10)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, radienShogun.Posx = 10);
                }
                if (radienShogun.Posx > 720)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, radienShogun.Posx = 720);
                }
                if (radienShogun.Posy < 0)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.TopProperty, radienShogun.Posy = 0);
                }
                if (radienShogun.Posy > 275)
                {
                    radienShogun.CanvasSpieler.SetValue(Canvas.TopProperty, radienShogun.Posy = 275);
                }
                if (radienShogun.Posy > 270 && radienShogun.Posx < 300)
                {
                    timer.Stop();
                    CanvesSpielerContainer.Children.Clear();
                    CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
                }
            }
            if (CanvesSpielerContainer.Children.Contains(yaeMiko.CanvasSpieler))
            {
                yaeMiko.Posy = (double)yaeMiko.CanvasSpieler.GetValue(Canvas.TopProperty);
                yaeMiko.Posx = (double)yaeMiko.CanvasSpieler.GetValue(Canvas.LeftProperty);

                if (e.Key == Key.Up)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy + yaeMiko.Speed);
                }
                if (e.Key == Key.Down)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy - yaeMiko.Speed);
                }
                if (e.Key == Key.Left)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx + yaeMiko.Speed);
                }
                if (e.Key == Key.Right)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx - yaeMiko.Speed);
                }
                if (yaeMiko.Posx < 10)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx = 10);
                }
                if (yaeMiko.Posx > 720)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx = 720);
                }
                if (yaeMiko.Posy < 0)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy = 0);
                }
                if (yaeMiko.Posy > 275)
                {
                    yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy = 275);
                }
                if (yaeMiko.Posy > 270 && yaeMiko.Posx < 300)
                {
                    timer.Stop();
                    CanvesSpielerContainer.Children.Clear();
                    CanvesSpielerContainer.Children.Add(gameover.CanvasSpieler);
                }
            }
            #endregion
        }


        private void LblAether_MD(object sender, MouseButtonEventArgs e)
        {
            aether.Zeichnen();
            CanvesSpielerContainer.Children.Clear();//löschte vorherige Figur und bombe
            CanvesSpielerContainer.Children.Add(aether.CanvasSpieler);
        }

        private void LblAlbedo_MD(object sender, MouseButtonEventArgs e)
        {
            albedo.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
            CanvesSpielerContainer.Children.Add(albedo.CanvasSpieler);

        }

        private void LblRadienShogun_MD(object sender, MouseButtonEventArgs e)
        {
            radienShogun.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
            CanvesSpielerContainer.Children.Add(radienShogun.CanvasSpieler);


        }

        private void LblYaeMiko_MD(object sender, MouseButtonEventArgs e)
        {
            yaeMiko.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
            CanvesSpielerContainer.Children.Add(yaeMiko.CanvasSpieler);

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            bombe.Zeichnen();
            CanvesSpielerContainer.Children.Add(bombe.CanvasSpieler);


            if (CanvesSpielerContainer.Children.Count > 0)
            { 
            Container.Children.Remove(LblAether);
            Container.Children.Remove(LblAlbedo);
            Container.Children.Remove(LblRaidenShogun);
            Container.Children.Remove(LblYaeMiko);
            Name.Visibility = Visibility.Hidden;
            Loch.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Visible;
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    
    }
}
