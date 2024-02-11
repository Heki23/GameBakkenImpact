using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Vererben4__Bakken_
{
    internal class Aether:Spieler
    {
        public Aether():base()
        {
            spielerMalen.ImageSource = new BitmapImage(new Uri(@"Aether.png", UriKind.Relative));
            speed = -15;
            gravity = 6;
        }
      
    }
}
