using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class EnemyAnimation : AnimSprite
    {
        public EnemyAnimation(string stringInput,int cols,int rows) : base(stringInput,cols,rows)
        {
            Console.WriteLine("fileName: " +stringInput);
        }
    }
}
