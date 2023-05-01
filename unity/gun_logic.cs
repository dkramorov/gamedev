using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour {
    /* Логика пистолета 
       Создаем пистолет, добавляем его к персонажу, коллайдеры убираем
       Создаем в пистолете пустой объект для генерирование пулей (spawnPoint)
       spawnPoint rotation z=-90 чтобы пуля летела вперед
       Создаем префаб с пулькой
       На пистолет вешаем скрипт
    */
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawnPoint;

    [SerializeField]
    float fireSpeedCountdown = 0.5f; // Скорострельность

    [SerializeField]
    float defaultSpeedCountdown = 0.5f;

    [SerializeField]
    int ammoCount = 10; // Боезапас

    bool fireEnabled = false;

    void Start() {
        if (bulletPrefab && bulletSpawnPoint) {
            fireEnabled = true;
        } else {
            Debug.LogError("fireGub not initialized");
        }
    }

    void Update() {
        fire();
    }

    void fire() {
        if (fireSpeedCountdown > 0) {
            fireSpeedCountdown -= Time.deltaTime;
        }
        if (fireSpeedCountdown > 0 || ammoCount <= 0) {
            return;
        }
        // Настройки Input: Edit - Project Settings - InputManager
        if (Input.GetButtonDown("Fire1")) {
            if (fireEnabled) {
                Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    bulletSpawnPoint.rotation * bulletPrefab.transform.rotation);

                fireSpeedCountdown = defaultSpeedCountdown;
                ammoCount -= 1;
            }
        }
    }
}
