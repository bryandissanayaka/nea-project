using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalButton : MonoBehaviour
{
	[SerializeField] private int _starsRequired;

    private Sprite _animalSprite;

    private void Start() {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _starsRequired.ToString(); //display stars required
        _animalSprite = transform.GetChild(2).GetComponent<Image>().sprite; 
    }

    public int GetStarsRequired() {
        return _starsRequired;
    }

    public bool CanBeSelected(int currentStarsCount) {
        return (_starsRequired <= currentStarsCount);
    }
    
    public Sprite GetSprite() {
        return _animalSprite;
    }

    public void SetButtonImage(Sprite sprite) {
        GetComponent<Image>().sprite = sprite;
    }
}
