using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //References to the menu objects
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _levelsMenu;
    [SerializeField] private GameObject _optionsMenu;

    //Called when Start is pressed
    public void OnStartButtonPressed(){
        //Switch to level selection screen
        _startMenu.SetActive(false);
        _levelsMenu.SetActive(true);
    }

    //Called when Options is pressed
    public void OnOptionsButtonPressed(){
        //Switch to options menu
        _startMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void OnBackToStartButtonPressed(){
        _levelsMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _startMenu.SetActive(true);
    }
}


