[System.Serializable]
public class LevelData
{
	public LevelType Type;

	public float TeleportRadius;
	public int TeleportsCount;
	public int MaxPushesCount;
	public float MaxInkAmount;

	public bool GravityToolEnabled;
	public bool FreezeToolEnabled;
	public bool TeleportToolEnabled;
	public bool PushToolEnabled;

}

public enum LevelType {
	Timer,
	Stars,
	KeyDoor
}

