using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private AnimalButton[] _animalButtons;
    [SerializeField] private Sprite _unlockedImage;
    [SerializeField] private Sprite _selectedImage;

    private AnimalButton _selectedAnimal;

    private void Start() {
        int starCount = PersistentData.GetStarsCount();
        if(PersistentData.GetSelectedAnimal() == null) {
            PersistentData.SelectAnimal(_animalButtons[0]);
            _animalButtons[0].SetButtonImage(_selectedImage);
            _selectedAnimal = _animalButtons[0];
        }
        
        foreach (var button in _animalButtons) {
            int starsRequired = button.GetStarsRequired();
            Image buttonImage = button.gameObject.GetComponent<Image>();
            if (starsRequired <= starCount) {
                buttonImage.sprite = _unlockedImage;
            }
            if (button == _selectedAnimal) {
                buttonImage.sprite = _selectedImage;
            }
        }
    }

    public void OnAnimalSelected(AnimalButton button) { //when button is pressed
        if (button.CanBeSelected(PersistentData.GetStarsCount())) {
            PersistentData.SelectAnimal(button);
            //display
            _selectedAnimal.SetButtonImage(_unlockedImage); //deselect previous animal
            button.SetButtonImage(_selectedImage); //select new one
            _selectedAnimal = button;
        }
    }
}
