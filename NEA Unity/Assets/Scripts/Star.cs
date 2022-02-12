using UnityEngine;

public class Star : MonoBehaviour
{
    [Range(0, 2)] //make sure that I set the id to 0, 1 or 2 and nothing else
    [SerializeField] private int id; //which star it is in the level

    [SerializeField] private Sprite _collectedSprite; //outline sprite
    private bool _collected; //has the player collected this star
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (_collected) return; //if its collected, return out of the method
        if (collision.CompareTag("Player")) { //if player collides
            GameManager.instance.CollectStar(id); //collect this star
            GetComponent<SpriteRenderer>().sprite = _collectedSprite; //change sprite
            _collected = true;
        } 
    }
}
