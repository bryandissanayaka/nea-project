using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy {

    private void Update() {
        Move();
    }

    protected override void Move() {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
