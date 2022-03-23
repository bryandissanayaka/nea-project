using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //References to the menu objects
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _levelsMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _shopMenu;

    [SerializeField] private Image[] _levelButtons;
    [SerializeField] private Sprite _completedImage;
    [SerializeField] private Sprite _lockedImage;
    [SerializeField] private Sprite _starImage;

    private void Awake() => GameLaunch();

    private void Start() {
        GameLaunch();
        DisplayLevelButtonsState();
        SetStarsCount();
    }

    private void GameLaunch() {
        SaveLoadSystem.Load();
        PersistentData.SetLevelUnlockedState(0);
    }

    private void DisplayLevelButtonsState() {
        for (int i = 0; i < _levelButtons.Length; i++) {
            if (PersistentData.IsLevelCompleted(i)) {
                _levelButtons[i].sprite = _completedImage;
                DisplayStarsStateOfLevel(_levelButtons[i].transform, i);
            }
            else { //if the level isnt completed
                if (!PersistentData.IsLevelUnlocked(i)) { //if the level is locked
                    GameObject text = _levelButtons[i].transform.GetChild(0).gameObject;
                    text.SetActive(false);
                    _levelButtons[i].sprite = _lockedImage;
                }
            }
        }
    }

    private void DisplayStarsStateOfLevel(Transform button, int levelIndex) {
        if (PersistentData.GetStarState(levelIndex, 0))
            button.GetChild(1).gameObject.GetComponent<Image>().sprite = _starImage;
        if (PersistentData.GetStarState(levelIndex, 1))
            button.GetChild(2).gameObject.GetComponent<Image>().sprite = _starImage;
        if (PersistentData.GetStarState(levelIndex, 2))
            button.GetChild(3).gameObject.GetComponent<Image>().sprite = _starImage;
    }

    [SerializeField] private TextMeshProUGUI _starsCount;
    private void SetStarsCount() {
        int x = PersistentData.GetStarsCount();
        print(x);
        _starsCount.text = x.ToString();
    }


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

    public void OnShopButtonPressed() {
        _startMenu.SetActive(false);
        _shopMenu.SetActive(true);
        PersistentData.PlayerHasOpenedShop = true;
    }

    public void OnBackToStartButtonPressed(){
        _levelsMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _shopMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    public void OnLevelButtonPressed(int levelID) {
        //level ID is the index of the levels in the build settings
        //the first level in the build settings has index 1
        //the first level in the persistent data has index 0 (array)
        //therefore when checking if the level is unlocked, i decrease the id by 1
        if(PersistentData.IsLevelUnlocked(levelID - 1)) {
            SceneManager.LoadScene(levelID);
        }
    }
}


