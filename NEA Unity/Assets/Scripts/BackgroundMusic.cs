using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _music;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject); //dont destroy this when changing levels
        _music = GetComponent<AudioSource>();
    }
    
    public void SetVolume(float value) {
        _music.volume = value / 2; //(original sound file is too loud so value is divided by 2)
    }
}
