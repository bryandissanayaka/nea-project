using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _music; //music player component

    public static BackgroundMusic Instance; //the SINGLE instance of the background music object

    private void Awake() {
        if (Instance == null) { //if the instance is non existent
            Instance = this; //set the instance to this class
            _music = GetComponent<AudioSource>(); //grab audiosource component reference
            _music.Play(); //start the audio clip (background music)
            DontDestroyOnLoad(gameObject); //set this object to not destroy when changing scene
        }
        else { //if there is already an instance
            Destroy(gameObject); //destroy this object (and therefore not playing music)
        }
    }
    
    public void SetVolume(float sliderValue) {
        _music.volume = sliderValue / 2; //(original sound file is too loud so value is divided by 2)
    }

    public float GetSliderValue() { //called to get the value of the slider
        return _music.volume * 2; 
    }
}