var speed: float;
var title: float;

function FixedUpdate()
{
	transform.position.y += speed;
	if( transform.position.y > title )
	{
		speed = 0;
	}
	
}