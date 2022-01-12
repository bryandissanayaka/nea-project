extends RigidBody2D

#gravity variables
const STOP_BALL_PERCENTAGE = 0.5
const DECREASE_PERCENTAGE = 0.7
const REVERSED_GRAVITY_SCALE = -5
var gravity_reversed_pressed = false
var gravity_up = false # is gravity going upwards

#freeze variables
var frozen = false

#pushing variables
var push_force = 200


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


func _handle_gravity_reverse(delta):
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

func _handle_freeze():
	if(Input.is_action_just_pressed("freeze_ball")):
		if(frozen):
			mode = RigidBody2D.MODE_RIGID
			frozen = false
		else:
			mode = RigidBody2D.MODE_STATIC
			frozen = true

func _handle_pushing():
	if(Input.is_action_just_pressed("push_right")):
		apply_impulse(Vector2.ZERO, Vector2.RIGHT * push_force)
	if(Input.is_action_just_pressed("push_left")):
		apply_impulse(Vector2.ZERO, Vector2.LEFT * push_force)

func _ready():
	pass

func _process(delta):
	_handle_gravity_reverse(delta)
	_handle_freeze()
	_handle_pushing()
	pass
	
	


	
