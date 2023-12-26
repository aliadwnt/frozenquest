extends CharacterBody2D

enum State {
	jalan,
	diam,
	DESTROY,
}

const JALAN_SPEED = 100.0

var _state = State.diam

@onready var gravity = ProjectSettings.get_setting("physics/2d/default_gravity") as float
@onready var platform_detector = $PlatformDetector as RayCast2D
@onready var floor_detector_left = $FloorDetectorLeft as RayCast2D
@onready var floor_detector_right = $FloorDetectorRight as RayCast2D
@onready var sprite := $Sprite2D as Sprite2D
@onready var animation_player = $AnimationPlayer as AnimationPlayer

func _physics_process(delta: float) -> void:
	if _state == State.diam and velocity.is_zero_approx():
		velocity.x = JALAN_SPEED
	velocity.y += gravity * delta
	if not floor_detector_left.is_colliding():
		velocity.x = JALAN_SPEED
	elif not floor_detector_right.is_colliding():
		velocity.x = -JALAN_SPEED

	if is_on_wall():
		velocity.x = -velocity.x

	move_and_slide()

	if velocity.x > 0.0:
		sprite.scale.x = -1.0
	elif velocity.x < 0.0:
		sprite.scale.x = 1.0

	var animation = get_new_animation()
	if animation != animation_player.current_animation:
		animation_player.play(animation)

func get_new_animation() -> StringName:
	var animation_new = ""
	if _state == State.diam:
		if velocity.x == 0:
			animation_new = "diam"
		else:
			animation_new = "jalan"
	else:
		animation_new = "DESTROY"
	return animation_new
