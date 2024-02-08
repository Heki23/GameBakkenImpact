using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Vererben4__Bakken_
{
    internal class Bombe:Spieler
    {
        public Bombe():base() {
            canvasSpieler.Width = 60;
            canvasSpieler.Height = 50;
            spielerMalen.ImageSource = new BitmapImage(new Uri(@"slime.png", UriKind.Relative));
            speed = 5;
        }
        public override void Zeichnen()//Abgeleitet
        {
            //Was? und Wo?
            Canvas.SetLeft(canvasSpieler, posx=0);//Position im Canvas(Element,Position)
            Canvas.SetTop(canvasSpieler, posy=100);
 
        }
    }
}
