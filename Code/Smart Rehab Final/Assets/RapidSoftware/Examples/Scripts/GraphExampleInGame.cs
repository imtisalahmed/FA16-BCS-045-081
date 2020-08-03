
using UnityEngine;
using Rapid.Tools;

/// <summary>
/// This is a simple example of how you could draw graphs in-game.
/// </summary>
public class GraphExampleInGame : MonoBehaviour
{
	GraphLogStyle _style;
	GraphLogBuffer _buffer;
	GraphGridInGame _drawer;
	
	public Material RenderMaterial;
	
	int _screenWidth = -1;
	bool _wasScreenSpace = true;
	
	
	void Awake()
	{
		_style = new GraphLogStyle("MyStyle", Color.white, Color.cyan, new []{Color.red, Color.green, Color.blue});
		
		int bufferSize = 300;
		
		_buffer = new GraphLogBuffer("MyGraph", "", 2, new []{"x","y"}, null, LogTimeMode.TimeSinceStartup, _style, bufferSize);
		
		_drawer = new GraphGridInGame(GetComponent<Camera>(), RenderMaterial, false, _buffer);
		_drawer.SetGridColor(Color.white);
		_drawer.Rows = 4;
		
		_wasScreenSpace = !_drawer.ScreenSpace;
	}
	
	
	void UpdateAreaScreenSpace()
	{
		Vector2 inset = Vector2.one * 2f;
		_drawer.SetArea(new Vector2(40f, 40f), new Vector2(Screen.width-40f, 240f), inset, inset);
		_screenWidth = Screen.width;
		_drawer.Columns = _screenWidth / 100;
	}
	
	void UpdateAreaWorldSpace()
	{
		Vector2 inset = new Vector2(0.1f, 0.1f);
		_drawer.SetArea(new Vector2(-8f, -2f), new Vector2(8f, 2f), inset, inset);
		_drawer.Columns = 10;
	}
	
	
	void Update()
	{
		if(_drawer.ScreenSpace)
		{
			if(!_wasScreenSpace || _screenWidth != Screen.width)
				UpdateAreaScreenSpace();
		}
		else if(_wasScreenSpace)
		{
			UpdateAreaWorldSpace();
		}
		_wasScreenSpace = _drawer.ScreenSpace;
		
		
		Vector2 mousePos = Input.mousePosition;
		_buffer.Log(mousePos.x, mousePos.y);
		_drawer.SetTimeValueBounds(_buffer.TimeStart, _buffer.TimeLast, _buffer.Min, _buffer.Max);
	}
	
	void OnPostRender()
	{
		_drawer.Draw();
	}
	
	void OnGUI()
	{
		_drawer.ScreenSpace = GUILayout.Toggle(_drawer.ScreenSpace, "Screen space");
	}
};
