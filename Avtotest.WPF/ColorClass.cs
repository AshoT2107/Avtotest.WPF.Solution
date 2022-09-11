using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Avtotest.WPF
{
    public class ColorClass
    {
        public int tag;
        public SolidColorBrush solidColorBrush;
        public ColorClass(int tag, SolidColorBrush solidColorBrush)
        {
            this.tag = tag;
            this.solidColorBrush = solidColorBrush;
        }
    }
}
