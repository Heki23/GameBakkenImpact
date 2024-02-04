using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;

public class GameOver
{
    protected Grid gameOverFenster;
    public Grid GameOverFenster
    {
        get { return gameOverFenster; }
        set { gameOverFenster = value; }
    }
    //notwendig, wenn man auf Elemente oder Eigenschaften der MainWindow zugreifen möchtest 
    public GameOver()
    {
        gameOverFenster = new Grid();

        Rectangle rec = new Rectangle()
        {
            Fill = Brushes.White,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Opacity = 0.8,
        };
        // Erstelle ein TextBlock mit dem gewünschten Text
        TextBlock textBlock = new TextBlock()
        {
            Text = "Game Over",
            FontSize = 50,
            FontWeight = FontWeights.Bold,
            Foreground = Brushes.Black,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(0, 0, 0, 100),
        };
     
        //Große von Grid Fenstgelegt
        gameOverFenster.Width = 600;
        gameOverFenster.Height = 400;
        //Rectangle in Grid eingefügt
        gameOverFenster.Children.Add(rec);
        //Text in Grid eingefügt
        gameOverFenster.Children.Add(textBlock);
    }
}