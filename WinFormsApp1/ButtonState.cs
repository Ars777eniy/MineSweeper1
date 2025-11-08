using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ButtonState
    {
        public int I { get; set; }
        public int J { get; set; }

        public bool IsBomb { get; set; }

        public ButtonState(int i, int j, bool isBomb)
        {
            I  = i;
            J = j;
            IsBomb = isBomb;
        }
    }
}
