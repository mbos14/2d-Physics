using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	public MyGame () : base(1024, 768, false)
	{
        Level level = new Level("Level/level.tmx");
	}

	void Update ()
	{
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}

