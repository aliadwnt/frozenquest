extends CharacterBody2D

const SPEED = 300.0
const JUMP_VELOCITY = -700.0

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _physics_process(delta):
	# Add the gravity.
	if not is_on_floor():
		velocity.y += gravity * delta

	# Handle Jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction = Input.get_axis("ui_left", "ui_right")
	if direction != 0:
		velocity.x = direction * SPEED
		if direction > 0:
			$AnimatedSprite2D.play("kanan")
			$AnimatedSprite2D.flip_h = false  # Tidak membalik sprite
		else:
			$AnimatedSprite2D.play("kiri")
			$AnimatedSprite2D.flip_h = true  # Membalik sprite
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		$AnimatedSprite2D.play("idle")

	move_and_slide()
	
	func game_over():
	save_game()
	get_tree().change_scene_to_file("res://game_over.tscn")
