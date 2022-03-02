using UnityEngine;
public static class PersistentData
{
    private static bool[] _levelCompletionState = new bool[21];
    private static bool[] _levelUnlockedState = new bool[21];

    //mark level as complete
    public static void SetLevelCompletionState(int index) {
        _levelCompletionState[index] = true;
        int indexOfNextLevel = index + 1;
        SetLevelUnlockedState(indexOfNextLevel);
    }

    //unlock the next level
    public static void SetLevelUnlockedState(int index) {
        if (index > 21) return;
        _levelUnlockedState[index] = true;
    }

    public static bool IsLevelCompleted(int index) {
        return _levelCompletionState[index];
    }

    public static bool IsLevelUnlocked(int index) {
        return _levelUnlockedState[index];
    }
    
    private static bool[] _starsCollectedState = new bool[63];

    public static void SetStarCollectedState(int levelIndex, bool[] starsState) {
        for (int i = 0; i < starsState.Length; i++) {
            if (starsState[i]) { //if the star is collected
                //_starsCollectedState[levelIndex, i] = true;
                int starIndexInArray = levelIndex * 3 + i;
                _starsCollectedState[starIndexInArray] = true;
            }
        }
    }

    public static bool GetStarState(int levelIndex, int starIndex) {
        int index = levelIndex * 3 + starIndex;
        bool starState = _starsCollectedState[index];
        return starState;
    }

    private static int _starsCount;

    public static int GetStarsCount() {
        return _starsCount;
    }


    public static SaveData GetAllData() {
        return new SaveData(_levelCompletionState, _levelUnlockedState, _starsCollectedState);
    }
    
    public static void LoadAllData(SaveData data) {
        _levelCompletionState = data.LevelCompletionState;
        _levelUnlockedState = data.LevelUnlockedState;
        _starsCollectedState = data.StarsCollectedState;
        CountStarsCollected();
    }

    private static void CountStarsCollected() {
        _starsCount = 0;
        foreach (var star in _starsCollectedState) {
            if (star) _starsCount++;
        }
    }

    private static AnimalButton _selectedAnimal;

    public static void SelectAnimal(AnimalButton animal) {
        _selectedAnimal = animal;
    }

    public static AnimalButton GetSelectedAnimal() {
        return _selectedAnimal;
    }

    public static Sprite GetSelectedSprite() {
            return _selectedAnimal.GetSprite();
    }
}
