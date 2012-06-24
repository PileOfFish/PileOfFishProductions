var monster:GameObject;
var sun:GameObject;
var timeText:GameObject;
var moneyText:GameObject;

function OnGUI() 
{
	var e: Event = Event.current;
	if(e.button == 0 && e.isMouse)
	{
		gameObject.SetActiveRecursively(false);
		monster.gameObject.SetActiveRecursively(true);
		sun.gameObject.SetActiveRecursively(true);
		timeText.gameObject.SetActiveRecursively(true);
		moneyText.gameObject.SetActiveRecursively(true);
	}
}