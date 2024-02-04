using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Vererben4__Bakken_
{
    internal class GameOver : Spieler
    {
        public GameOver() : base()
        {
            Rectangle rec = new Rectangle()
            {
                Width = 200,
                Height = 200,
                Fill = Brushes.Green,
                Stroke = Brushes.Red,
                StrokeThickness = 2,
            };
            spielerMalen.ImageSource = new BitmapImage(new Uri(@"gameover.png", UriKind.Relative));
            canvasSpieler.Width = 810;
            canvasSpieler.Height = 400;
        }
    }
}
