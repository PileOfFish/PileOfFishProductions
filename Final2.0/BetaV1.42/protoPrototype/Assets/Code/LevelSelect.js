private var buttonWidth: 	int = 200;
private var buttonHeight: 	int = 50;
private var spacing:		int = 25;

function OnGUI ()
{
	GUILayout.BeginArea(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - 200, buttonWidth, 400));
	if(GUILayout.Button("Financial District", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("Financial District");
		
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Red Light District", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("Red Light District");
		
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Industrial District", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("Industrial District");
		
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button("Back", GUILayout.Height(buttonHeight)))
	{
		Application.LoadLevel("TitleScreen");
		
	}
	GUILayout.EndArea();
}