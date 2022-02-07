using UnityEngine;
using UnityEngine.UI;

public class DrawTool : MonoBehaviour
{
	[SerializeField] private Camera _camera;         //variable to hold reference to the camera

    [SerializeField] private GameObject _linePrefab; //the line object prefab
    private Vector2 _startPosition;                  //the starting point of the line
    private Vector2 _endPosition;                    //the end point of the line

    [SerializeField] private float _maxInk;          //the starting ink that player has
    private float _currentInk;                       //stores the current amount of ink
    [SerializeField] private Image _inkImage;

    private void Start(){
        _currentInk = _maxInk;                              //set the current ink to the maximum ink
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition); //when left click is pressed, _startPosition is set to current the mouse position
        }else if(Input.GetMouseButtonUp(0)){
            _endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);   //the left click is released, _endPosition is set to the current mouse position
            Vector2 lineVector = _endPosition - _startPosition;               //substract end by start to find the vector pointing from start to end
            float lineLength = lineVector.magnitude;                          //get the length of the vector
            if( (_currentInk - lineLength) > 0){        //check if the player has enough ink to draw this line
                float lineRotation = Mathf.Atan2(lineVector.y, lineVector.x) * 57.29578f;   //calculate rotation by doing arctan(y / x) and multiplying by constant to convert to degrees
                Vector2 midPoint =  new Vector2(lineVector.x / 2, lineVector.y / 2);        //calculate midpoint 
                GameObject line = Instantiate(_linePrefab);                                 //instantiate new line object
                line.transform.position = _startPosition + midPoint;                        //set the position of the line
                line.transform.rotation = Quaternion.Euler(0, 0, lineRotation);             //set the Z rotation of the line leaving the X and Y rotation to 0
                line.transform.localScale = new Vector3(lineLength * 2, 1, 1);              //set X scale. Multiplying by 2 because the object has been resized from its original sprite size.
                _currentInk -= lineLength;                                                  //decrease the current ink by the line length
                _inkImage.fillAmount = _currentInk / _maxInk;                               //update UI
            }
        }
    }
}
