using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager instance;
    private void SetSingleton() {
        if (instance == null) {
            instance = this;
        }
    }
    private void Awake() {
        SetSingleton();
    }
    #endregion

    [SerializeField] private LevelData _levelData;

    private void Start() {
        PlayerSetup();
        LevelInitialisation();
    }

    private void PlayerSetup() {
        Player.instance.EnableTools(_levelData.GravityToolEnabled, _levelData.FreezeToolEnabled,
                            _levelData.TeleportToolEnabled, _levelData.PushToolEnabled);
        if (_levelData.TeleportToolEnabled) {
            Player.instance.SetMaxTeleportingDistance(_levelData.TeleportRadius);
            Player.instance.SetTeleportsCount(_levelData.TeleportsCount);
        }
        if (_levelData.PushToolEnabled)
            Player.instance.SetMaxPushCount(_levelData.MaxPushesCount);
        Player.instance.GetComponent<DrawTool>().SetMaxInk(_levelData.MaxInkAmount);
    }

    private void LevelInitialisation() {
        Time.timeScale = 1;
        bool isLevelWinOnTimerEnd = _levelData.Type == LevelType.Timer;
        if (isLevelWinOnTimerEnd) {
            GetComponent<LevelTimer>().SetMode(true);
        }
    }

    #region KeyDoor System
    private bool _keyCollected;

    public void CollectKey() {
        _keyCollected = true;
    }

    public bool IsKeyCollected() {
        return _keyCollected;
    }
    #endregion

    #region Stars
    private bool[] _starsCollected = {false, false, false};
    [SerializeField] private Image _starOne, _starTwo, _starThree;
    [SerializeField] private Sprite _completedStar;
    public void CollectStar(int id) {
        _starsCollected[id] = true;
        if(id == 0) {
            _starOne.sprite = _completedStar;
        }else if(id == 1) {
            _starTwo.sprite = _completedStar;
        }else if(id == 2) {
            _starThree.sprite = _completedStar;
        }
    }
    #endregion

    #region Level End
    [SerializeField] private GameObject _completedLevelScreen;
    public void CompleteLevel() {
        Debug.Log("Level Completed!");
        Time.timeScale = 0;
        _completedLevelScreen.SetActive(true);
        int indexOfCurrentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        //mark this level as complete
        if (!PersistentData.IsLevelCompleted(indexOfCurrentLevel)) { //if level wasnt already marked complete
            PersistentData.SetLevelCompletionState(indexOfCurrentLevel);
        }
        //Debug.Log(_starsCollected.ToString());
        PersistentData.SetStarCollectedState(indexOfCurrentLevel, _starsCollected);
        
        SaveLoadSystem.Save();
        
    }

    [SerializeField] private GameObject _failedLevelScreen;
    public void FailLevel() {
        Debug.Log("Level Failed!");
        Time.timeScale = 0;
        _failedLevelScreen.SetActive(true);
    }

    public void OnProceedToNextLevelPressed() {
        int indexOfNextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexOfNextLevel);
        Time.timeScale = 1;
    }
    #endregion Level End

    #region Pause System
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    private bool _paused;
    [SerializeField] private GameObject _pauseMenu;
    private void TogglePause() {
        if (_completedLevelScreen.activeInHierarchy || _failedLevelScreen.activeInHierarchy) return;
        _paused = !_paused;
        Time.timeScale = _paused ? 0 : 1;
        _pauseMenu.SetActive(_paused);
    }
    #endregion

}
