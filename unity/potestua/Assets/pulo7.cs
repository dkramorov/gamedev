using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulo7 : MonoBehaviour {
    /*
        Коллайдер со звуком и сериализованным полем
        Создаем пару кубов, чтобы можно было проходить через них
        в MeshCollider ставим isTrigger
        добавляем AudioSource компонент и убираем Play On Awake
        втыкаем звук в сериализованное поле
        Для игрока задаем tag=Player и проверяем по тегу, что именно
        игрок столкнулся с подарочком, а не, например, пуля
    */
    AudioSource audioSource;
    Collider objCollider;
    MeshRenderer meshRenderer;

    [SerializeField]
    AudioClip pulo7Sound;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        objCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void FixedUpdate() {
        // Постоянное вращение
        transform.Rotate(Vector3.forward, 1.0f);
    }

    private void OnTriggerEnter(Collider other) {
        // При пересечении объекта играем звук
        if (other.tag != "Player") {
            return;
        }
        if (audioSource && pulo7Sound) {
            audioSource.PlayOneShot(pulo7Sound);
        }
        // выключаем коллайдер
        if (objCollider) {
            objCollider.enabled = false;
        }
        // прячем объект
        if (meshRenderer) {
            meshRenderer.enabled = false;
        }
    }
}
