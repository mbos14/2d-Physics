using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	public MyGame () : base(1024, 768, false)
	{
        Level level = new Level("level.tmx");
        AddChild(level);
        Console.WriteLine(level);
	}

	void Update ()
	{
		//can you read this? no	} ?

	static void Main() {
		new MyGame().Start();
	}
}

