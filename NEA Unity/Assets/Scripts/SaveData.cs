public class SaveData{
    public bool[] LevelCompletionState = new bool[21];
    public bool[] LevelUnlockedState = new bool[21];
    public bool[] StarsCollectedState = new bool[63];
    public bool[] StarsState = new bool[63];

    public SaveData(bool[] compl, bool[] unlocked, bool[] stars) {
        LevelCompletionState = compl;
        LevelUnlockedState = unlocked;
        StarsCollectedState = stars;
    }
}