using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Vererben4__Bakken_
{
    internal class Enemy:Spieler
    {
        public Enemy() : base()
        {
            canvasSpieler.Width = 60;
            canvasSpieler.Height = 50;
            //Standart
            UpdateImage(1);
            speed = 5;
        }
        public void UpdateImage(int enemyRandom)
        {
            switch (enemyRandom)
            {
                case 1:
                    spielerMalen.ImageSource = new BitmapImage(new Uri(@"slime.png", UriKind.Relative));
                    break;
                case 2:
                    spielerMalen.ImageSource = new BitmapImage(new Uri(@"enemy2.png", UriKind.Relative));
                    break;
                case 3:
                    spielerMalen.ImageSource = new BitmapImage(new Uri(@"enemy3.png", UriKind.Relative));
                    break;
                case 4:
                    spielerMalen.ImageSource = new BitmapImage(new Uri(@"genshin-klee-bomb.png", UriKind.Relative));
                    break;
                default:
                    spielerMalen.ImageSource = new BitmapImage(new Uri(@"slime.png", UriKind.Relative));
                    break;
            }
        }
        public override void Zeichnen()//Abgeleitet
        {
            //Was? und Wo?
            Canvas.SetLeft(canvasSpieler, posx=0);//Position im Canvas(Element,Position)
            Canvas.SetTop(canvasSpieler, posy=100);
 
        }
    }
}
