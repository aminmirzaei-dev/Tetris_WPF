using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controls
{
    public interface ITetrisControl
    {
        Tetris.Controls.Styles Style { get; set; }
        System.Windows.Media.Color Palette { get; set; }
    }
}
