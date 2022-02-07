using UnityEngine;

public class Line : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer; //reference to the sprite renderer component
    [SerializeField] private float _fadeRate;   //the rate at which the line fades
    private float redValue, greenValue, blueValue;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();   //grab reference
        //access the sprite renderer to get the rgb values of the line
        //these will not change after the object is instantiated
        redValue = _spriteRenderer.color.r;
        greenValue = _spriteRenderer.color.g;
        blueValue = _spriteRenderer.color.b;
    }
    
    private void Update() {
        //get current alpha and reduce by fade rate. multiply the rate by time.deltatime to keep the fade framerate independent.
        float newAlpha = _spriteRenderer.color.a - (_fadeRate * Time.deltaTime);
        if(newAlpha <= 0){  //check if the object has completely faded
            Destroy(this.gameObject); //if yes, destroy the entire object
        }
        //cannot change just the alpha value, so set the colour to a new colour with the rgb values and the new alpha value
        _spriteRenderer.color = new Color(redValue, greenValue, blueValue, newAlpha);
    }
}
