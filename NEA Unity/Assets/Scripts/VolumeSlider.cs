using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private void Start() {
        //set the slider's knob to match the music volume
        GetComponent<Slider>().value = BackgroundMusic.Instance.GetSliderValue();
    }

	public void SetVolume(float value) {
        BackgroundMusic.Instance.SetVolume(value); //set the music's instance's volume
    }
}
