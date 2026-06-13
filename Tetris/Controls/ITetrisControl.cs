using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controls
{
    public enum StyleColors { None, System, Light, Dark }

    public interface ITetrisControl
    {
        Tetris.Controls.StyleColors StyleColor { get; set; }
        System.Windows.Media.Color PaletteColor { get; set; }
    }
}
