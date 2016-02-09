using System;

namespace GXPEngine
{
	public class Level : TMXLevel
	{
		public Level (string filename) : base()
		{
            //interpret objects
            InterpretMap(filename);

		}
        void GetCollisionLines()
        {

        }
		void Update()
		{
		
		}
        public override string ToString()
        {
            return _map.ToString();
        }
    }
}

