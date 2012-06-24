private var buttonWidth: 	int = 200;
private var buttonHeight: 	int = 50;
private var spacing:		int = 50;

function OnGUI ()
{
	GUILayout.BeginArea(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - 200, buttonWidth, 400));
	if(GUILayout.Button("New Game", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("Financial District");
		
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Level Select", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("Level Select");
		
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Exit", GUILayout.Height(buttonHeight)))
	{
		//Application.Quit;
		
	}
	
	GUILayout.EndArea();
}