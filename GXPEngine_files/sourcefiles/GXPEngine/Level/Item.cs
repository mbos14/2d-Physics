using System;
using System.Collections.Generic;
using GXPEngine;

namespace GXPEngine
{
	public class Item : Sprite
	{
		//all different Item types
		const int ITEMCOUNT = 1;
		public const int TYPE_SPAWN = 1;

		//field that stores this items Item type
		private int type;
		//we use an AnimSprite as a graphic (currentFrame==type)
		private Tile gfx;
		//properties can be stored as a Dictionary
		public Dictionary<string, string> properties = new Dictionary<string, string>();

        //object is made from it's hitbox (since it is 2.5D)
        public Item(TiledObject tiledObject) : base("hitbox.png")
        {
            //test
            Console.WriteLine(tiledObject.X+ " "+tiledObject.Y);
            //process TiledObject properties
            x = tiledObject.X;
            y = tiledObject.Y;
            if(type!=TYPE_SPAWN) addGfx(tiledObject.GID);

            //DONE: read properties from TiledObject and store them in the scenery object
            if (tiledObject.Properties != null)
            {
                for (int i = 0; i < tiledObject.Properties.Property.Length; i++)
                {
                    properties[tiledObject.Properties.Property[i].Name] = Convert.ToString(tiledObject.Properties.Property[i].Value);
                }
                Console.WriteLine("Dictionary count: "+properties.Count + " "+ tiledObject.Properties.Property.Length);
            }
        }

		//adds a visual to this object
		void addGfx(int itemID) {
            gfx = new Tile(type-1);
			AddChild (gfx);
			SetOrigin (0, height);
			gfx.SetOrigin (0, gfx.height);
			SetItemType (itemID);
			alpha = 0;
		}

		//change item type, also updates gfx.currentFrame
		public void SetItemType(int type) {
			if (type > gfx.frameCount) type = 1;
			if (type < 1) type = 1;
			this.type = type;
			gfx.currentFrame = type - 1;
		}

		//returns item type
		public int GetItemType() {
			return this.type;
		}
	}
}

