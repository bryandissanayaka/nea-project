using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
	[SerializeField] private float _time;
    [SerializeField] private TextMeshProUGUI _ui;

    private bool _winWhenTimerEnds = false;

	private float _current;
    private void Start() {
        _current = _time;
    }

    private void Update() {
        _current -= Time.deltaTime;
        _ui.text = _current.ToString("F2");
        if (_current <= 0) {
            _current = 0;
            _ui.text = "0";
            if (_winWhenTimerEnds) {
                GameManager.instance.CompleteLevel();
            }
            else {
                GameManager.instance.FailLevel();
            }
            Destroy(this);
        }
    }

    public void SetMode(bool winOnTimerEnd) {
        _winWhenTimerEnds |= winOnTimerEnd;
    }
}
