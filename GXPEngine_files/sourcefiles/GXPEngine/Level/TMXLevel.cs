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
        private Map _map;
		private List<NLineSegment> _CollisionLines = new List<NLineSegment>();

        public TMXLevel ()
		{
		}
		protected void InterpretMap(string filename) {
			//create a TMXParser
			TMXParser tmxParser = new TMXParser();
			//parse the file 'level.tmx'
			_map = tmxParser.Parse(filename);
			//read all object groups if not null
			ObjectGroup[] objectGroups = _map.ObjectGroup;
            if (objectGroups != null)
            {
                for (int i = 0; i < objectGroups.Length; i++)
                {
                    interpretObjectGroup(objectGroups[i]);
                }
            }
            Layer[] layer = _map.Layers;
            for (int i =0; i< layer.Length; i++)
            {
                interpretLayerGroup(layer[i],i);
            }
		}
        private void interpretLayerGroup (Layer layer,int index)
        {
            int[,] tile = new int[_map.Width, _map.Height];

            string levelData = _map.Layers[0].Data.innerXML;
            string[] lines = levelData.Split('\n');
			for (int i = 1; i <= _map.Height; i++)
            {
                string[] columns = lines[i].Split(',');
				for (int j = 0; j < _map.Width; j++)
                {
                    int tileID;
                    if (int.TryParse(columns[j], out tileID))
                    {
                        if (tileID != 0)
                        {
                            tileID--;
                            interpretCell(i, j, tileID);
                        }
                    }
                }
            }
        }
        private void interpretCell(int rows, int columns, int tileFrame)
        {
            Tile tile = new Tile(tileFrame);
            tile.SetXY(columns * _map.tileWidth, (rows-1) * _map.tileHeight);
            AddChild(tile);
        }
        private void interpretObjectGroup (ObjectGroup objectGroup)
		{
            TiledObject[] objects = objectGroup.TiledObject;
            for (int i = 0; i < objects.Length; i++)
            {
                interpretObject(objects[i]);
            }
            foreach (LineSegment line in _CollisionLines)
            {
                Console.WriteLine("Start: " +line.start+" End: "+line.end);
            }
        }

        //read a single Tiled Object
        private void interpretObject(TiledObject tiledObject)
        {
            //create a scenery item
            Item scenery = new Item(tiledObject);
            AddChild(scenery);

        }

		public List<NLineSegment> GetLines()
		{
			return _CollisionLines;
		}
	}
}

