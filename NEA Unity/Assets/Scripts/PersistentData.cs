using UnityEngine;
public static class PersistentData
{
    private static bool[] _levelCompletionState = new bool[21]; //true if index matching level is completed
    private static bool[] _levelUnlockedState = new bool[21]; //true if index matching level is unlocked

    //mark level as complete
    public static void SetLevelCompletionState(int index) {
        _levelCompletionState[index] = true;
        int indexOfNextLevel = index + 1;
        SetLevelUnlockedState(indexOfNextLevel);
    }

    //unlock the next level (the one after the last level the player has completed)
    public static void SetLevelUnlockedState(int index) {
        if (index > 21) return; //if it exceeds the array, return out of the function
        _levelUnlockedState[index] = true;
    }

    public static bool IsLevelCompleted(int index) {
        return _levelCompletionState[index]; //returns true or false based on level completion matching index
    }

    public static bool IsLevelUnlocked(int index) {
        return _levelUnlockedState[index]; //returns true or false based on level completion matching index
    }
    
    private static bool[] _starsCollectedState = new bool[63];

    public static void SetStarCollectedState(int levelIndex, bool[] starsState) {
        for (int i = 0; i < starsState.Length; i++) {
            if (starsState[i]) { //if the star is collected (boolean is true)               
                int starIndexInArray = levelIndex * 3 + i;
                _starsCollectedState[starIndexInArray] = true;
            }
        }
    }

    public static bool GetStarState(int levelIndex, int starIndex) {
        int index = levelIndex * 3 + starIndex; //calculate the index in the array of the star (3 as 3 stars for each level)
        bool starState = _starsCollectedState[index];
        return starState;
    }

    private static int _starsCount; //how many stars the player has collected
    public static int GetStarsCount() { //getter for _starsCount
        return _starsCount;
    }

    public static SaveData GetAllData() { //returns all the data that needs to be saved
        return new SaveData(_levelCompletionState, _levelUnlockedState, _starsCollectedState);
    }
    
    public static void LoadAllData(SaveData data) { //loads the data into this static class by getting a SaveData as parameter
        _levelCompletionState = data.LevelCompletionState;
        _levelUnlockedState = data.LevelUnlockedState;
        _starsCollectedState = data.StarsCollectedState;
        CountStarsCollected(); 
    }

    private static void CountStarsCollected() { //calculates the number of collected stars
        _starsCount = 0;
        foreach (var star in _starsCollectedState) {
            if (star) _starsCount++;
        }
    }

    private static AnimalButton _selectedAnimal; //animal selected by the player in the shop
    public static void SelectAnimal(AnimalButton animal) {
        _selectedAnimal = animal;
    }

    public static AnimalButton GetSelectedAnimal() {
        return _selectedAnimal;
    }

    public static Sprite GetSelectedSprite() { //return sprite component of the selected animal
            return _selectedAnimal.GetSprite();
    }

    public static bool PlayerHasOpenedShop; //to check if player has opened the shop at least once in the current session

}


