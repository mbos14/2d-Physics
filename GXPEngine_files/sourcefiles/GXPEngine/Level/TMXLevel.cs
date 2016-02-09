using System;
using GXPEngine;
using System.IO;
using System.Collections.Generic;

namespace GXPEngine
{
	public class TMXLevel : GameObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GXPEngine.LevelBase"/> class.
		/// </summary>
		/// <param name='map'>
		/// Map data structure from Tiled
		/// </param>
        protected Map _map;
		private List<NLineSegment> _CollisionLines = new List<NLineSegment>();

        public TMXLevel ()
		{
		}
        protected void InterpretMap(string filename)
        {
            //create a TMXParser
            TMXParser tmxParser = new TMXParser();
            //parse the file 'level.tmx'
            _map = tmxParser.Parse(filename);
            //read all object groups if not null
            ObjectGroup[] objectGroups = _map.objectGroups;
            if (objectGroups != null)
            {
                for (int i = 0; i < objectGroups.Length; i++)
                {
                    interpretObjectGroup(objectGroups[i]);
                }
            }
        }
        private void interpretObjectGroup (ObjectGroup objectGroup)
		{
            TiledObject[] objects = objectGroup.TiledObject;
            if (objects == null)
            {
                Console.WriteLine("Error: object layer is empty");
                return;
            }
            for (int i = 0; i < objects.Length; i++)
            {
                interpretObject(objects[i]);
            }
        }

        //read a single Tiled Object
        private void interpretObject(TiledObject tiledObject)
        {
            //create an enemy
            Enemy enemy = new Enemy(tiledObject);
            AddChild(enemy);
        }
	}
}

