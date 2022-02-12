using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    private Camera _camera;

    private Rigidbody2D _rigidBody; // variable to hold a reference to the rigidbody2d component attached to this object]

    //Gravity Tool variables
    [SerializeField] private float _gravityMagnitudeWhenChanged; //value for gravity when the tool is used
    [SerializeField] private float _gravityNormalMagnitude;      //gravity will be of this value when the tool is not being used
    [SerializeField] private float _gravityStabilizeRate;        //the rate of which gravity will go from _gravityMagnitudeWhenChanged to _gravityStabilizeRate
    private bool _gravityReversed = false;                       //false when gravity acts downwards. true when it's acting upwards
    private bool _gravityChanging = false;                       //true when the tool is being used

    //Freeze tool variables
    private bool _isFrozen;                                      //keep track if the player is frozen or not

    //Teleport tool variables
    private bool _isTeleporting;
    [SerializeField] private GameObject _teleportZone;
    private float _teleportRadius;

    //Push tool variables
    [SerializeField] private float _pushForce;
    private int _maxPushesCount;
    private int _currentPushesCount;
    [SerializeField] private TextMeshProUGUI _pushesText;

    public delegate void Tools();
    private Tools toolsDelegate;

    //Start is called when the object is instantiated in the scene
    private void Start() {
        _camera = Camera.main;
        _rigidBody = GetComponent<Rigidbody2D>();                //grabs a reference of the rigidbody2d
        _rigidBody.gravityScale = _gravityNormalMagnitude;       //set the gravity scale to the normal magnitude
    }

    //Update is called once per frame
    private void Update() {
        toolsDelegate();
    }

    private void HandleGravityTool(){
        if(Input.GetKeyDown(KeyCode.G) && !_gravityChanging){    //if the player presses G and the gravity isnt currently changing
            _gravityChanging = true;                             //gravity will be set to be changing
            _gravityReversed = !_gravityReversed;                //flips boolean
            if(_gravityReversed){                                               //if gravity is going up   
                _rigidBody.gravityScale = - _gravityMagnitudeWhenChanged;       //set the scale to be the negative of _gravityMagnitudeWhenChanged (positive is downards)
            }else{                                                              //if gravity is going down
                _rigidBody.gravityScale = _gravityMagnitudeWhenChanged;         //set the scale to be _gravityMagnitudeWhenChanged
            }
        }

        if (_gravityChanging){  //if the tool has been pressed
            if(_gravityReversed){ //when gravity is going up        
                _rigidBody.gravityScale += _gravityStabilizeRate * Time.deltaTime; //the scale increases (from negative value, towards zero)
                if(_rigidBody.gravityScale >= - _gravityNormalMagnitude){           
                    _rigidBody.gravityScale = - _gravityNormalMagnitude;           //stop the scale from changing when reaching the correct value
                    _gravityChanging = false;                                      //the tool is now not being used
                }
            }else{                //when gravity is going down                     //same as above, but for when gravity is now acting downwards
                _rigidBody.gravityScale -= _gravityStabilizeRate * Time.deltaTime;
                if(_rigidBody.gravityScale <= -_gravityNormalMagnitude){
                    _rigidBody.gravityScale = _gravityNormalMagnitude;
                    _gravityChanging = false;
                }           
            }
        }
    }

    private void HandleFreezeTool(){
        if(Input.GetKeyDown(KeyCode.F)){    //if player presses the F key
            _isFrozen = !_isFrozen;         //flip boolean
            _rigidBody.bodyType = _isFrozen ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;     //short version of simple if else statement
            //if _isFrozen is true, the body type will be static, if false it will be dynamic
        }
    }

    private void HandleTeleportTool(){
        if(Input.GetKeyDown(KeyCode.T) && !_isTeleporting){         //if the player presses T and the the teleport zone is not currently visible
            _isTeleporting = true;
            _teleportZone.SetActive(true);                          //set the gameobject to be active, therefore making the sprite visible
        }
        if(_isTeleporting){             
            if(Input.GetMouseButtonDown(1)){    //if the player right clicks while the zone is visible
                Vector2 targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);   //get the mouse position
                float distance = Vector2.Distance(transform.position, targetPosition);      //calculate distnace from the player's position to the mouse position
                Debug.Log($"Distance: {distance}. Target Pos: {targetPosition}. Position: {transform.position}.");  //print those values to the console (using string interpolation)
                if(distance <= _teleportRadius){    //if the distance is less or equal to the maximum teleporting distance (the radius of the teleporter zone)
                    transform.position = targetPosition;    //set the player's position to the mouse position
                }
                _isTeleporting = false;             //the player has finished using the tool (either succesfully or not if they clicked outside the area)
                _teleportZone.SetActive(false);     //disable teleportzone game object therefore hiding the sprite showing the zone
            }             
        }
    }

    public void SetMaxTeleportingDistance(float maxDistance){
        float diameterOfZone = maxDistance * 2;
        Vector3 scale = new Vector3(diameterOfZone, diameterOfZone, 1);
        _teleportZone.transform.localScale = scale;
        _teleportRadius = maxDistance;
    }

    private void HandlePushTool() {
        if (_currentPushesCount <= 0) return;   //if the player has ran out of the number of push counts, return of the function
        if (Input.GetKeyDown(KeyCode.A)) {      
            Push(Vector2.left);                 //Push to the left when pressing A
        }else if (Input.GetKeyDown(KeyCode.D)) {
            Push(Vector2.right);                //Push to the right when pressing D
        }
    }

    private void Push(Vector2 direction) {
        _rigidBody.AddForce(direction * _pushForce, ForceMode2D.Impulse);   //add an instant force to the ball
        _currentPushesCount--;                                              //reduce push count by one
        UpdatePushesUI();                                                       
    }

    private void UpdatePushesUI() {
        _pushesText.text = $"Pushes: {_currentPushesCount}";    //set the UI text using string interpolation
    }

    public void SetMaxPushCount(int count) {
        _maxPushesCount = count;
        _currentPushesCount = _maxPushesCount;
        UpdatePushesUI();
    }

    public void EnableTools(bool gravity, bool freeze, bool teleport, bool push) {
        if (gravity) toolsDelegate += HandleGravityTool;
        if (freeze) toolsDelegate += HandleFreezeTool;
        if (teleport) toolsDelegate += HandleTeleportTool;
        if (push) toolsDelegate += HandlePushTool;
    }
}
