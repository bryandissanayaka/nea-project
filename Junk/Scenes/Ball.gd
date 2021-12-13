extends RigidBody2D

const DECREASE_PERCENTAGE = 0.8
var gravity_reversed_pressed = false

func _ready():
	pass

func _process(delta):
	if(Input.is_action_just_pressed("reverse_gravity") and not gravity_reversed_pressed):
		print("gravity reversed")
		gravity_reversed_pressed = true
		gravity_scale *= -1
	
	if(gravity_reversed_pressed):
		var half_y_vel = 0.5 * abs(linear_velocity.y)
		if (abs(linear_velocity.y) > half_y_vel):
			linear_velocity.y = linear_velocity.y * DECREASE_PERCENTAGE * delta
		else:
			gravity_reversed_pressed = false
			
	print(linear_velocity.y)
	
