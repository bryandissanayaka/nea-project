using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager instance;
    private void SetSingleton() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private LevelData _levelData;
    private void Awake() {
        SetSingleton();
        Player.instance.EnableTools(_levelData.GravityToolEnabled, _levelData.FreezeToolEnabled,
                                    _levelData.TeleportToolEnabled, _levelData.PushToolEnabled);
        if(_levelData.TeleportToolEnabled) 
            Player.instance.SetMaxTeleportingDistance(_levelData.TeleportRadius);
        if (_levelData.PushToolEnabled)
            Player.instance.SetMaxPushCount(_levelData.MaxPushesCount);
        Player.instance.GetComponent<DrawTool>().SetMaxInk(_levelData.MaxInkAmount);

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

    #region Stars System
    private bool[] _starsCollected = {false, false, false};

    public void CollectStar(int id) {
        _starsCollected[id] = true;
    }
    #endregion



    public void CompleteLevel() {
        Debug.Log("Level Completed!");
        Time.timeScale = 0;
    }

    public void FailLevel() {
        Debug.Log("Level Failed!");
        Time.timeScale = 0;
    }

}
