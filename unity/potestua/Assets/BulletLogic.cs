using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
    /* Пуля, скрипт накидываем на префаб пули
       пуля направлена вверх, при это BulletSpawner rotation z -90
       use gravity выключаем

       Чтобы отслеживать куда попала пуля, нужно добавить
       коллайдер для пули и поставить IsTrigger,
       а в методе OnTriggerEnter
       удалить объект в который попала пуля и саму пулю
       Но делать это следует по тегу, то есть,
       задать для мишени Tag объекта
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

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Target") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
