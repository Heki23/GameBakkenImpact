using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vererben4__Bakken_
{
    internal class Spieler
    {
        protected double posx = 350;
        protected double posy = 200;
        protected Canvas canvasSpieler;
        protected ImageBrush spielerMalen;
        protected int speed;
        protected int gravity;

        public Canvas CanvasSpieler
        {
            get { return canvasSpieler; }
            set { canvasSpieler = value; }
        }
        public double Posx//Kopie
        {    //Eigenschaftsmethoden alternative bezeichhung getter und setter
            get { return posx; }//Hiermit ist es möglich aus einer anderen Klasse auf eine Kopie von Variable zuzugreifen kann
            set { posx = value; }//Hiermit ist es möglich in einer anderen Klassse eine Kopie zu bearbeiten
        }
        public double Posy
        {
            get { return posy; }
            set { posy = value; }
        }
        
        public double Speed
        {
            get { return speed; }
        }
        public int Gravity
        {
            get { return gravity; }
        }
        public Spieler(){

            canvasSpieler = new Canvas();
            spielerMalen = new ImageBrush();
            //spielerMalen.ImageSource = new BitmapImage(new Uri(@"Aether.png",UriKind.Relative));
            canvasSpieler.Background = spielerMalen;//zeichnet die Figur
            speed = -5;
            gravity = 5; 
            canvasSpieler.Width = 70;
            canvasSpieler.Height = 140;
        }
        public virtual void Zeichnen()//Basis
        {      //Polymorphismus
                                //Was? und Wo?
            Canvas.SetLeft(canvasSpieler, posx);//Position im Canvas(Element,Position)
            Canvas.SetTop(canvasSpieler, posy);
            
        }

    }
}
