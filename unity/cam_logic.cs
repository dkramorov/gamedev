using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour {
    /* Простая логика камеры
       Создаем контейнер - пустой объект и в него помещаем камеру,
       камере задаем x=0, y=8, z=-8, rotation x=40
       На контейнер вешаем скрипт и камера будет перемещаться за персонажем
    */
    [SerializeField]
    Transform playerTarget;

    void Start() {
        if (!playerTarget) {
            Debug.LogError("Player target not set for camera");
        }
    }

    // Update is called once per frame
    void Update() {
        if (playerTarget) {
            transform.position = playerTarget.position;
        }
    }
}
