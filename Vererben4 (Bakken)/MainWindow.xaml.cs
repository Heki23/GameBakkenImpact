using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Vererben4__Bakken_;

namespace Vererben4__Bakken_
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Aether aether = new Aether();
        private Albedo albedo = new Albedo();
        private RaidenShogun raidenShogun = new RaidenShogun();
        private YaeMiko yaeMiko = new YaeMiko();
        private Bombe bombe = new Bombe();
        private DispatcherTimer timer = new DispatcherTimer();
        private double counter;
        private double timerCounter;
        private GameOver gameOver = new GameOver();
        private int mcounter = 0;
        private object currentCharacter; // Hier speichern wir das aktuelle Charakterobjekt
        private string currentCharacterName;
        private bool charakterInfoPostionChange = false;
   
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            musicPlayer.Play();
            musicPlayer.Source = new Uri("LoadingScreen.mp3", UriKind.Relative);
            timerCounter = 0;
            
        }
  

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            // Überprüfe, ob 1 Sekunde (10 * 0,1 Sekunden)=1 vergangen ist
            if (timerCounter == 10)
            {
                // Setze den Timer-Zähler zurück
                timerCounter = 0;

                // Erhöhe den Counter und aktualisiere das UI
                counter++;
                Counter_Tick.Content = Convert.ToString(counter);
            }

             (((Spieler)currentCharacter)).Posy = (double)((Spieler)currentCharacter).CanvasSpieler.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

                if (((Spieler)currentCharacter).Posy <= 273)
                {
                ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.TopProperty, ((Spieler)currentCharacter).Posy + ((Spieler)currentCharacter).Gravity);
                }


                bombe.Posx = (double)bombe.CanvasSpieler.GetValue(Canvas.LeftProperty);
                bombe.Posy = (double)bombe.CanvasSpieler.GetValue(Canvas.TopProperty);
                
                bombe.CanvasSpieler.SetValue(Canvas.LeftProperty, bombe.Posx + bombe.Speed);//bombe läüft

                //Hier wurde Position von Bombo geändert und Speed erhöht
                if (bombe.Posx >= 740)
                {
                    bombe.CanvasSpieler.SetValue(Canvas.LeftProperty, bombe.Posx = 0);

                    Random random = new Random();
                    int randomTopValue = random.Next(0, 250); // Generiert eine zufällige Ganzzahl im Bereich von 0 bis 250

                    bombe.CanvasSpieler.SetValue(Canvas.TopProperty, bombe.Posy = randomTopValue);
                    bombe.Speed += 0.1;

                }

                #region Wenn bombe mit Spieler berührt, dann gameover 
                if (Canvas.GetLeft(((Spieler)currentCharacter).CanvasSpieler) + ((Spieler)currentCharacter).CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
                && Canvas.GetLeft(((Spieler)currentCharacter).CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
                && Canvas.GetTop(((Spieler)currentCharacter).CanvasSpieler) + ((Spieler)currentCharacter).CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
                && Canvas.GetTop(((Spieler)currentCharacter).CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
                {

                    timer.Stop();
                    //Fehler mit bereits ein untergeordnetes Element zu beheben
                    MainGrid.Children.Remove(gameOver.GameOverFenster);
                    CanvesSpielerContainer.Children.Clear();
                    MainGrid.Children.Add(gameOver.GameOverFenster);
                    replayButtonErstellen();

            }
            //    if (Canvas.GetLeft(albedo.CanvasSpieler) + albedo.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            //    && Canvas.GetLeft(albedo.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            //    && Canvas.GetTop(albedo.CanvasSpieler) + albedo.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            //    && Canvas.GetTop(albedo.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            //    {

            //        timer.Stop();
            //        MainGrid.Children.Remove(gameOver.GameOverFenster);
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //}
            //    if (Canvas.GetLeft(raidenShogun.CanvasSpieler) + raidenShogun.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            //    && Canvas.GetLeft(raidenShogun.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            //    && Canvas.GetTop(raidenShogun.CanvasSpieler) + raidenShogun.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            //    && Canvas.GetTop(raidenShogun.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            //    {

            //        timer.Stop();
            //        MainGrid.Children.Remove(gameOver.GameOverFenster);
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //}
            //    if (Canvas.GetLeft(yaeMiko.CanvasSpieler) + yaeMiko.CanvasSpieler.ActualWidth >= Canvas.GetLeft(bombe.CanvasSpieler)
            //    && Canvas.GetLeft(yaeMiko.CanvasSpieler) <= Canvas.GetLeft(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualWidth
            //    && Canvas.GetTop(yaeMiko.CanvasSpieler) + yaeMiko.CanvasSpieler.ActualHeight >= Canvas.GetTop(bombe.CanvasSpieler)
            //    && Canvas.GetTop(yaeMiko.CanvasSpieler) <= Canvas.GetTop(bombe.CanvasSpieler) + bombe.CanvasSpieler.ActualHeight)
            //    {

            //        timer.Stop();
            //        MainGrid.Children.Remove(gameOver.GameOverFenster);
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //}
            #endregion
            #region Wenn Charakter Loch berührt
            //Methodenaufruf und bekommt name von Charakter und Ellipse
            if (IsCharacterInHole(((Spieler)currentCharacter).CanvasSpieler, Loch))
            {
                //Ohne dem kann ein unerwartet zu Fehlern mit zufälligem Game Over bei neu starten, obwohl ein anderer Charakter erzogen wurde
                if (CanvesSpielerContainer.Children.Contains(((Spieler)currentCharacter).CanvasSpieler))
                {
                    timer.Stop();
                    CanvesSpielerContainer.Children.Clear();
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(gameOver.GameOverFenster);
                    replayButtonErstellen();
                }
            }
            //if (IsCharacterInHole(albedo.CanvasSpieler, Loch))
            //{
            //    if (CanvesSpielerContainer.Children.Contains(albedo.CanvasSpieler))
            //    {
            //        timer.Stop();
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //    }
            //}
            //if (IsCharacterInHole(raidenShogun.CanvasSpieler, Loch))
            //{
            //    if (CanvesSpielerContainer.Children.Contains(raidenShogun.CanvasSpieler))
            //    {
            //        timer.Stop();
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //    }
            //}
            //if (IsCharacterInHole(yaeMiko.CanvasSpieler, Loch))
            //{
            //    if (CanvesSpielerContainer.Children.Contains(yaeMiko.CanvasSpieler))
            //    {
            //        timer.Stop();
            //        CanvesSpielerContainer.Children.Clear();
            //        MainGrid.Children.Clear();
            //        MainGrid.Children.Add(gameOver.GameOverFenster);
            //        replayButtonErstellen();
            //    }
            //}

        }
        private bool IsCharacterInHole(Canvas characterCanvas, Ellipse hole)
        {
            //Rect-Objekt besteht aus vier Koordinaten: X, Y, Width und Height
            Rect characterRect = new Rect(Canvas.GetLeft(characterCanvas), Canvas.GetTop(characterCanvas), characterCanvas.ActualWidth, characterCanvas.ActualHeight);
            Rect holeRect = new Rect(Canvas.GetLeft(hole), Canvas.GetTop(hole), hole.Width, hole.Height);

            return characterRect.IntersectsWith(holeRect);
        }
        #endregion

        #region Charakter KeyControl 
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (CanvesSpielerContainer.Children.Contains(((Spieler)currentCharacter).CanvasSpieler))
            {
                //Hier erbt currentCharacter mit Name des Character die Spieler Model -> bekommt daten von Charakter
                //Steht also (Spieler) bsp. aether.Posy
                ((Spieler)currentCharacter).Posy = (double)((Spieler)currentCharacter).CanvasSpieler.GetValue(Canvas.TopProperty);
                ((Spieler)currentCharacter).Posx = (double)((Spieler)currentCharacter).CanvasSpieler.GetValue(Canvas.LeftProperty);//aktuelle Wert wird ermittelt

                if (e.Key == Key.Up)
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.TopProperty, ((Spieler)currentCharacter).Posy + ((Spieler)currentCharacter).Speed);
                }
                if (e.Key == Key.Down)
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.TopProperty, ((Spieler)currentCharacter).Posy - ((Spieler)currentCharacter).Speed);
                }
                if (e.Key == Key.Left)
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.LeftProperty, ((Spieler)currentCharacter).Posx + ((Spieler)currentCharacter).Speed);
                }
                if (e.Key == Key.Right)
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.LeftProperty, ((Spieler)currentCharacter).Posx - ((Spieler)currentCharacter).Speed);
                }
                #region window einstellung
                if (((Spieler)currentCharacter).Posx < 0)//links
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.LeftProperty, ((Spieler)currentCharacter).Posx = 0);
                }
                if (((Spieler)currentCharacter).Posx > 755)//recht
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.LeftProperty, ((Spieler)currentCharacter).Posx = 755);
                }
                if (((Spieler)currentCharacter).Posy < 0)//oben
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.TopProperty, ((Spieler)currentCharacter).Posy = 0);
                }
                if (((Spieler)currentCharacter).Posy > 275)//unten
                {
                    ((Spieler)currentCharacter).CanvasSpieler.SetValue(Canvas.TopProperty, ((Spieler)currentCharacter).Posy = 275);
                }
                #endregion

            }
            #region gespart
            //if (CanvesSpielerContainer.Children.Contains(albedo.CanvasSpieler))
            //{
            //    albedo.Posy = (double)albedo.CanvasSpieler.GetValue(Canvas.TopProperty);
            //    albedo.Posx = (double)albedo.CanvasSpieler.GetValue(Canvas.LeftProperty);

            //    if (e.Key == Key.Up)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy + albedo.Speed);
            //    }
            //    if (e.Key == Key.Down)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy - albedo.Speed);
            //    }
            //    if (e.Key == Key.Left)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx + albedo.Speed);
            //    }
            //    if (e.Key == Key.Right)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx - albedo.Speed);
            //    }
            //    #region albedo window einstellung
            //    if (albedo.Posx < 10)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx = 10);
            //    }
            //    if (albedo.Posx > 755)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.LeftProperty, albedo.Posx = 755);
            //    }
            //    if (albedo.Posy < 0)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy = 0);
            //    }
            //    if (albedo.Posy > 275)
            //    {
            //        albedo.CanvasSpieler.SetValue(Canvas.TopProperty, albedo.Posy = 275);
            //    }
            //    #endregion
            //}
            //if (CanvesSpielerContainer.Children.Contains(raidenShogun.CanvasSpieler))
            //{
            //    raidenShogun.Posy = (double)raidenShogun.CanvasSpieler.GetValue(Canvas.TopProperty);
            //    raidenShogun.Posx = (double)raidenShogun.CanvasSpieler.GetValue(Canvas.LeftProperty);

            //    if (e.Key == Key.Up)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.TopProperty, raidenShogun.Posy + raidenShogun.Speed);
            //    }
            //    if (e.Key == Key.Down)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.TopProperty, raidenShogun.Posy - raidenShogun.Speed);
            //    }
            //    if (e.Key == Key.Left)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, raidenShogun.Posx + raidenShogun.Speed);
            //    }
            //    if (e.Key == Key.Right)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, raidenShogun.Posx - raidenShogun.Speed);
            //    }
            //    #region Radien window einstellung
            //    if (raidenShogun.Posx < 10)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, raidenShogun.Posx = 10);
            //    }
            //    if (raidenShogun.Posx > 755)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.LeftProperty, raidenShogun.Posx = 755);
            //    }
            //    if (raidenShogun.Posy < 0)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.TopProperty, raidenShogun.Posy = 0);
            //    }
            //    if (raidenShogun.Posy > 275)
            //    {
            //        raidenShogun.CanvasSpieler.SetValue(Canvas.TopProperty, raidenShogun.Posy = 275);
            //    }
            //    #endregion
            //}
            //if (CanvesSpielerContainer.Children.Contains(yaeMiko.CanvasSpieler))
            //{
            //    yaeMiko.Posy = (double)yaeMiko.CanvasSpieler.GetValue(Canvas.TopProperty);
            //    yaeMiko.Posx = (double)yaeMiko.CanvasSpieler.GetValue(Canvas.LeftProperty);

            //    if (e.Key == Key.Up)
            //    {
            //        yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy + yaeMiko.Speed);
            //    }
            //    if (e.Key == Key.Down)
            //    {
            //        yaeMiko.CanvasSpieler.SetValue(Canvas.TopProperty, yaeMiko.Posy - yaeMiko.Speed);
            //    }
            //    if (e.Key == Key.Left)
            //    {
            //        yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx + yaeMiko.Speed);
            //    }
            //    if (e.Key == Key.Right)
            //    {
            //        yaeMiko.CanvasSpieler.SetValue(Canvas.LeftProperty, yaeMiko.Posx - yaeMiko.Speed);
            //    }

            #endregion
            //}
            #endregion
        }

        #region Charkter in Canvas erstellen
        private void LblAether_MD(object sender, MouseButtonEventArgs e)
        {
            //Hier mache ich Warnung wegen
            MainGrid.Children.Clear();
            aether.Zeichnen();
            CanvesSpielerContainer.Children.Clear();//löschte vorherige Figur und bombe
            //currentCharacter = aether;
            CanvesSpielerContainer.Children.Add(aether.CanvasSpieler);
        }

        private void LblAlbedo_MD(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Children.Clear();
            albedo.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
           // currentCharacter = albedo;
            CanvesSpielerContainer.Children.Add(albedo.CanvasSpieler);
        }

        private void LblRaidenShogun_MD(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Children.Clear();
            raidenShogun.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
           // currentCharacter = raidenShogun;
            CanvesSpielerContainer.Children.Add(raidenShogun.CanvasSpieler);
        }

        private void LblYaeMiko_MD(object sender, MouseButtonEventArgs e)
        {
          //  MainGrid.Children.Clear();
            yaeMiko.Zeichnen();
            CanvesSpielerContainer.Children.Clear();
           // currentCharacter = yaeMiko;
            CanvesSpielerContainer.Children.Add(yaeMiko.CanvasSpieler);
        }
        #endregion

        #region start button
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            if (CanvesSpielerContainer.Children.Count > 0)
            {
                //Dass habe ich gemacht für die heruntergrund music nicht jedes mal neu startet bei replay
                mcounter++;
                if (mcounter == 1)
                {
                    if (musicPlayer.NaturalDuration.HasTimeSpan && !musicPlayer.Position.Equals(TimeSpan.Zero))
                    {
                        musicPlayer.Source = new Uri("battlesound.mp3", UriKind.Relative);
                    }
                }

            Spielflaech.Background = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(@"Background/background(1).jpg", UriKind.Relative)),
                    Stretch = Stretch.UniformToFill // Dies stellt sicher, dass das Bild den gesamten Button abdeckt
                };

                Counter_Tick.Content = Convert.ToString(counter);
                timer.Start();
                bombe.Zeichnen();
                CanvesSpielerContainer.Children.Remove(bombe.CanvasSpieler);
                CanvesSpielerContainer.Children.Add(bombe.CanvasSpieler);
                Container.Children.Remove(LblAether);
                Container.Children.Remove(LblAlbedo);
                Container.Children.Remove(LblRaidenShogun);
                Container.Children.Remove(LblYaeMiko);
                Name.Visibility = Visibility.Hidden;
                Loch.Visibility = Visibility.Visible;
                GridCharacterInfo.Visibility = Visibility.Hidden;
                MuteButton.Visibility = Visibility.Hidden;
                //Position von Start Button geändert mit hide geht nicht
                Canvas.SetLeft(StartButton, 1000);
                Canvas.SetTop(StartButton, 1000);
            }
            else
            {
                TextBlock CharacterChooseWarning = new TextBlock()
                {
                    Text = "Bitte wählen Sie einen Charakter aus!",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                MainGrid.Children.Add(CharacterChooseWarning);
               
               
            }
          
        }
        #endregion

        #region replay button erstellen und in MainWindow einfügen
        private void replayButtonErstellen()
        {
            MuteButton.Visibility = Visibility.Visible;

            Button replaybutton = new Button()
            {
                Width = 102,
                Height = 102,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                BorderBrush = null,
                Margin = new Thickness(0, 0, 0, 40),
            };

            // Füge das Bild als Hintergrund hinzu
            replaybutton.Background = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"replay.png", UriKind.Relative)),
                Stretch = Stretch.UniformToFill // Dies stellt sicher, dass das Bild den gesamten Button abdeckt
            };

            // Füge das Bild auch als Content hinzu, um es sichtbar zu machen
            replaybutton.Content = new Image()
            {
                Source = new BitmapImage(new Uri(@"replay.png", UriKind.Relative)),
                Width = 100,
                Height = 100
            };

            // Füge den EventHandler für den Click-Event hinzu
            replaybutton.Click += replay_Click;

            MainGrid.Children.Add(replaybutton);
        }
        #endregion
        #region replay button
        public void replay_Click(object sender, RoutedEventArgs e)
        {
            charakterInfoPostionChange = true;
            counter = 0;
            MainGrid.Children.Clear();
            Loch.Visibility = Visibility.Hidden;
            Canvas.SetLeft(Container, 250);
            Canvas.SetTop(Container, 110);
            Container.Children.Add(LblAether);
            Container.Children.Add(LblAlbedo);
            Container.Children.Add(LblRaidenShogun);
            Container.Children.Add(LblYaeMiko);

            Canvas.SetLeft(StartButton, 0);
            Canvas.SetTop(StartButton, 373);


            //Charakter Position geändert
            ((Spieler)currentCharacter).Posx = 550;
            ((Spieler)currentCharacter).Posy = 90;

            albedo.Posx = 550;
            albedo.Posy = 90;

            raidenShogun.Posx = 550;
            raidenShogun.Posy = 90;

            yaeMiko.Posx = 550;
            yaeMiko.Posy = 90;

            
        }
        #endregion


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SetCurrentCharacter(string characterName)
        {
            switch (characterName)
            {
                case "Aether":
                    currentCharacter = aether;
                    break;
                case "Albedo":
                    currentCharacter = albedo;
                    break;
                case "RaidenShogun":
                    currentCharacter = raidenShogun;
                    break;
                case "YaeMiko":
                    currentCharacter = yaeMiko;
                    break;
                default:
                    // Handle ungültige Eingaben hier
                    break;
            }
            CharcterInfoBoxUpdate();
        }

        #region Charakter Info anzeigen
        private void LblAether_MouseEnter(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Visible;
            if(charakterInfoPostionChange == false) { 
            Canvas.SetLeft(GridCharacterInfo, 435);
            Canvas.SetTop(GridCharacterInfo, 85);
            }
            else
            {
                Canvas.SetLeft(GridCharacterInfo, 220);
                Canvas.SetTop(GridCharacterInfo, 195);
            }
            currentCharacterName = "Aether";
            SetCurrentCharacter(currentCharacterName);
        }

        
        private void LblAlbedo_MouseEnter(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Visible;
            if (charakterInfoPostionChange == false)
            {
                Canvas.SetLeft(GridCharacterInfo, 520);
                Canvas.SetTop(GridCharacterInfo, 85);
            }
            else
            {
                Canvas.SetLeft(GridCharacterInfo, 294);
                Canvas.SetTop(GridCharacterInfo, 195);
            }
            currentCharacterName = "Albedo";
            SetCurrentCharacter(currentCharacterName);
        }

        private void LblRaidenShogun_MouseEnter(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Visible;
            if (charakterInfoPostionChange == false)
            {
                Canvas.SetLeft(GridCharacterInfo, 595);
            Canvas.SetTop(GridCharacterInfo, 85);
            }
            else
            {
                Canvas.SetLeft(GridCharacterInfo, 376);
                Canvas.SetTop(GridCharacterInfo, 195);
            }
            currentCharacterName = "RaidenShogun";
            SetCurrentCharacter(currentCharacterName);
        }

        private void LblYaeMiko_MouseEnter(object sender, MouseEventArgs e)
        {

            GridCharacterInfo.Visibility = Visibility.Visible;
            if (charakterInfoPostionChange == false)
            {
                Canvas.SetLeft(GridCharacterInfo, 651);
                Canvas.SetTop(GridCharacterInfo, 85);
            }
            else
            {
                Canvas.SetLeft(GridCharacterInfo, 455);
                Canvas.SetTop(GridCharacterInfo, 195);
            }
            currentCharacterName = "YaeMiko";
            SetCurrentCharacter(currentCharacterName);
        }
        #endregion

        private void CharcterInfoBoxUpdate()
        {
                // Typumwandlung, um auf die Eigenschaft zuzugreifen
                LbNameCharacterInfo.Content = currentCharacterName;
                // Hier mache ich negative zahl zu positiv
                LbSpeedCharacterInfo.Content = Math.Abs(((Spieler)currentCharacter).Speed);
                LbGravityCharacterInfo.Content = ((Spieler)currentCharacter).Gravity;
        }

        #region ChrakterInfo verstecken, wenn Maus wegen von Charakter Label ist
        private void LblAether_MouseLeave(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Hidden;

        }

        private void LblAlbedo_MouseLeave(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Hidden;
        }

        private void LblRaidenShogun_MouseLeave(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Hidden;

        }

        private void LblYaeMiko_MouseLeave(object sender, MouseEventArgs e)
        {
            GridCharacterInfo.Visibility = Visibility.Hidden;
        }
        #endregion

        private void MuteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Bei NaturalDuration wird die Dauer des Mediendatei repräsentiert.
            //HasTimeSpan auer der Mediendatei eine gültige TimeSpan hat oder nicht
            //Position wird die aktuelle Position (Wiedergabeposition) in der Mediendatei angibt.
            //Equals(TimeSpan.Zero) vergleicht die Position mit TimeSpan.Zero, was bedeutet, dass die Mediendatei nicht abgespielt wird (Position gleich Null ist).
            if (musicPlayer.NaturalDuration.HasTimeSpan && !musicPlayer.Position.Equals(TimeSpan.Zero))
            {
                // Musik stoppen
                musicPlayer.Stop();
                //Wenn Maus über Button ist dann zeigt er gar nicht deswegen habe ich mit content gemacht
                MuteButton.Content = new Image()
                { 
                    Source = new BitmapImage(new Uri(@"mute.png", UriKind.Relative)),
                    Height = 20,
                    Width = 20,
                };
            }
            else
            {
                // Wenn die Musik nicht abgespielt wird, starte sie
                musicPlayer.Play();
                MuteButton.Content = new Image()
                { 
                    Source = new BitmapImage(new Uri(@"unmute.png", UriKind.Relative)),
                    Height = 20,
                    Width = 20,
                };
            }
        }
    }
}
