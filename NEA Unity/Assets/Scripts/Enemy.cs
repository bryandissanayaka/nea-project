using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform _target; //target object (player)

    protected SpriteRenderer _spriteRenderer; //reference to the sprite
     
    [SerializeField] protected float _speed; //movement speed

    private void Start() {
        _target = Player.instance.transform; //set target to player script
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected abstract void Move(); //every subclass must implement a Move method

    private void OnTriggerEnter2D(Collider2D collision) { //when an object enters the trigger area
        if (collision.CompareTag("Player")) {   //if the object is the player
            Debug.Log($"{transform.name} has collided with the Player"); //print this enemy name on the console
        }
    }
}
