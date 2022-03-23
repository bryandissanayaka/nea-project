using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private AnimalButton[] _animalButtons; //all the animals in the shop
    [SerializeField] private Sprite _unlockedImage; //blue button sprite 
    [SerializeField] private Sprite _selectedImage; //yellow button sprite

    private AnimalButton _selectedAnimal; //which animal is selected

    private void Start() {
        int starCount = PersistentData.GetStarsCount(); //get how many stars the player has
        if(PersistentData.GetSelectedAnimal() == null) { //if the player has not selected an animal
            PersistentData.SelectAnimal(_animalButtons[0]); //select the first one by default
            _animalButtons[0].SetButtonImage(_selectedImage); //set the first animal's button's image to be selected
            _selectedAnimal = _animalButtons[0]; //hold the reference to the selected animal
        }
        
        foreach (var button in _animalButtons) { //loop through each animal button
            Image buttonImage = button.gameObject.GetComponent<Image>(); //get the image from the button
            if (button.CanBeSelected(starCount)) { //if it is unlocked
                buttonImage.sprite = _unlockedImage; //set the button's sprite to unlocked (blue)
            }
            if (button == _selectedAnimal) { //if it is the selected animal
                buttonImage.sprite = _selectedImage; //set the sprite to the unlocked sprite
            }
        }
    }

    public void OnAnimalSelected(AnimalButton button) { //when button is pressed
        if (button.CanBeSelected(PersistentData.GetStarsCount())) { //if the button can be selected
            PersistentData.SelectAnimal(button);
            //display
            _selectedAnimal.SetButtonImage(_unlockedImage); //deselect previous animal
            button.SetButtonImage(_selectedImage); //select new one
            _selectedAnimal = button;
        }
    }
}
