var speed: float;
var title: float;

function FixedUpdate()
{
	transform.position.x += speed;
	if( transform.position.x > title )
	{
		speed = 0;
	}
	
}
