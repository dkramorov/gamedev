using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
    /* Пуля, скрипт накидываем на префаб пули
       пуля направлена вверх, при это BulletSpawner rotation z -90
       use gravity выключаем
    */
    Rigidbody rigidBody;
    float speed = 6.0f;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        if (rigidBody) {
            rigidBody.velocity = transform.up * speed;
        }
    }

    void Update() {
        
    }
}
