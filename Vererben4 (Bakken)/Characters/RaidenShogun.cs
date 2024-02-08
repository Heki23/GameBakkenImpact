using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Vererben4__Bakken_
{
    internal class RaidenShogun : Spieler
    {
        public RaidenShogun() : base()
        {
            spielerMalen.ImageSource = new BitmapImage(new Uri(@"RaidenShogun.png", UriKind.Relative));
            speed = -15;
            gravity = 7;
        }
     
    }
}