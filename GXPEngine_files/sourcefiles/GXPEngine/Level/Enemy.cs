using System;
using System.Collections.Generic;
using GXPEngine;

namespace GXPEngine
{
	public class Enemy : Sprite
	{
		//all different Item types
		const int ITEMCOUNT = 1;
		public const int TYPE_NORMAL = 1;

		//field that stores this items Item type
		private int type;
		//we use an AnimSprite as a graphic (currentFrame==type)
		private EnemyAnimation gfx;
		//properties can be stored as a Dictionary
		public Dictionary<string, string> properties = new Dictionary<string, string>();

        //object is made from it's hitbox (since it is 2.5D)
        public Enemy(TiledObject tiledObject) : base ("hitbox.png")
        {
            Console.WriteLine("-------Enemy created--------");
            Console.WriteLine("X: "+tiledObject.X+ " Y: "+tiledObject.Y);
            //process TiledObject properties
            x = tiledObject.X;
            y = tiledObject.Y;
            if (tiledObject.Properties == null) Console.WriteLine("Error: properties missing!");
            else
            {
                for (int i = 0; i < tiledObject.Properties.Property.Length; i++)
                {
                    if (tiledObject.Properties.Property[i].Name == "image")
                    {
                        addGfx(tiledObject.GID, tiledObject.Properties.Property[i].Value);
                    }
                }
            }

            if (tiledObject.Properties != null)
            {
                for (int i = 0; i < tiledObject.Properties.Property.Length; i++)
                {
                    properties[tiledObject.Properties.Property[i].Name] = Convert.ToString(tiledObject.Properties.Property[i].Value);
                }
                Console.WriteLine("Dictionary count: "+properties.Count + " "+ tiledObject.Properties.Property.Length);
            }
            Console.WriteLine("\n");
        }

		//adds a visual to this object
		void addGfx(int itemID,string imageFile) {
            gfx = new EnemyAnimation(imageFile,1,1);
			AddChild (gfx);
			SetOrigin (width/2,0);
			gfx.SetOrigin (width/2, 0);
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

