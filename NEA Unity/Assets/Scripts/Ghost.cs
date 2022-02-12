using UnityEngine;

public class Ghost : Enemy {

    private bool _isSpriteFlippedOnYAxis;

    private void Update() {
        Move();
        Rotate();
    }

    protected override void Move() {
        //calculate vector towards target position, and multiply speed with deltaTime for framerate independent behaviour
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void Rotate() {
        Vector2 direction = _target.position - transform.position; //vector pointing from ghost to player
        //determine if the ghost should flip on the Y axis
        bool shouldFlip = (direction.x < 0 && !_isSpriteFlippedOnYAxis) || (direction.x > 0 && _isSpriteFlippedOnYAxis);
        if (shouldFlip) {
            _isSpriteFlippedOnYAxis = !_isSpriteFlippedOnYAxis; 
            _spriteRenderer.flipY = _isSpriteFlippedOnYAxis; //flip sprite on Y axis
        }

        //calculate angle towards the player with arctan of direction vector.  multiple with constant to get angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * 57.29578f;

        transform.rotation = Quaternion.Euler(0, 0, angle); //set Z rotation to angle
    }
}
