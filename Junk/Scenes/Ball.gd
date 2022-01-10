extends RigidBody2D

const STOP_BALL_PERCENTAGE = 0.5
const DECREASE_PERCENTAGE = 0.7
const REVERSED_GRAVITY_SCALE = -5
var gravity_reversed_pressed = false
var gravity_up = false # is gravity going upwards

func _method_one(var delta):
	if(Input.is_action_just_pressed("reverse_gravity") and not gravity_reversed_pressed):
		print("gravity reversed")
		gravity_reversed_pressed = true
		gravity_scale *= -1
	
	if(gravity_reversed_pressed):
		var half_y_vel = 0.5 * abs(linear_velocity.y)
		if (abs(linear_velocity.y) > half_y_vel):
			linear_velocity.y = linear_velocity.y - (linear_velocity.y * 1/ STOP_BALL_PERCENTAGE * delta)
		else:
			gravity_reversed_pressed = false	
#	print(linear_velocity.y)


func _method_two(delta):
	if(Input.is_action_just_pressed(("reverse_gravity")) and not gravity_reversed_pressed):
		gravity_scale *= REVERSED_GRAVITY_SCALE
		gravity_reversed_pressed = true
		gravity_up = not gravity_up
		Debug.Log3("Gravity reversed", gravity_up, gravity_scale)
	
	if(gravity_reversed_pressed):
		gravity_scale = gravity_scale - (gravity_scale * DECREASE_PERCENTAGE * delta)
		if (abs(gravity_scale) < 1):
			if(gravity_up):
				gravity_scale = -1
			elif(not gravity_up):
				gravity_scale = 1	
			gravity_reversed_pressed = false

func _ready():
	pass


func _process(delta):
#	_method_one(delta)
	_method_two(delta)


	pass
	
	


	
