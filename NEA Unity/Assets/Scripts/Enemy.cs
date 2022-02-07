using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
        #region Get Player reference
    protected Transform _target;

    [SerializeField] protected float _speed;

    private void Start() {
        _target = Player.instance.transform;
    }
        #endregion

    protected abstract void Move();
}
