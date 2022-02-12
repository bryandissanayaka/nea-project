using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private Image _iconUI; //UI icon referenece
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) { //if player enters trigger area
            _iconUI.sprite = GetComponent<SpriteRenderer>().sprite; //set the UI icon to this sprite
            GameManager.instance.CollectKey(); //call function on game manager
            Destroy(gameObject); //destroy this object
        }
    }
}
