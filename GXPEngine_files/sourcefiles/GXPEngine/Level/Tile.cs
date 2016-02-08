using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class Tile : AnimationSprite
    {
        public Tile(int frame) : base("Tiles.png",4,1)
        {
            SetFrame(frame);
        }
    }
}
