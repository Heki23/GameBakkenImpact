using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Vererben4__Bakken_
{
    internal class Albedo:Spieler
    {
        public Albedo() : base()
        {
            spielerMalen.ImageSource = new BitmapImage(new Uri(@"Albedo.png", UriKind.Relative));
            speed = -10;
            gravity = 4;
        }
      
    }
}
