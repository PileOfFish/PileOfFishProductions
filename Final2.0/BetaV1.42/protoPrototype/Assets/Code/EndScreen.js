private var buttonWidth: 	int = 200;
private var buttonHeight: 	int = 50;
private var spacing:		int = 100;

function OnGUI ()
{
	GUILayout.BeginArea(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - 200, buttonWidth, 400));
	if(GUILayout.Button("Restart", GUILayout.Height(buttonHeight)))
	{
		//Application.LoadLevel("WHY");
		print ("fuck YOU");
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Exit", GUILayout.Height(buttonHeight)))
	{
		//Application.LoadLevel("WHY");
		print("FUCK you");
	}
	GUILayout.EndArea();
}