using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour {
    /*
        Добавить CharacterController в компоненты объекта
        Добавить CapsuleCollider в компоненты объекта
        добавить скрипт объекту
    */

    CharacterController charController; // Компонент контроллера перемещения
    float moveSpeed = 5.0f; // скорость
    float horizontalInput; // перемещение по x
    float verticalInput; // перемещение по z
    Vector3 movement; // величина перемещения

    float jumpHeight = 0.5f;
    float gravity = 0.045f;
    bool isJump = false; // начат прыжок

    [SerializeField]
    bool isRotateWithMouse = false;

    void Start() {
        charController = GetComponent<CharacterController>();
        if(!charController) {
            Debug.LogError("charController absent");
        }
    }

    void Update() {
        // Настройки Input: Edit - Project Settings - InputManager
        horizontalInput = Input.GetAxis("Horizontal"); // for 2d
        verticalInput = Input.GetAxis("Vertical");
        checkJumpStarted();
    }

    private void FixedUpdate() {
        if (charController) {
            move();
            rotate();
            jump();
        }
    }

    private void checkJumpStarted() {
        // Настройки Input: Edit - Project Settings - InputManager
        if (!isJump && Input.GetButtonDown("Jump")) {
            isJump = true;
        }
    }

    private void move() {
        movement.x = horizontalInput * moveSpeed * Time.deltaTime; // 2d
        movement.z = verticalInput * moveSpeed * Time.deltaTime;
        charController.Move(movement);
    }

    private void jump() {
        if (charController.isGrounded) {
            // Если мы на земле
            movement.y = 0;
        } else {
            // Если мы в полете
            movement.y -= gravity;
        }
        if (isJump) {
            isJump = false;
            movement.y = jumpHeight;
        }
    }

    private void rotate() {
        if (isRotateWithMouse) {
            rotateWithMouse();
        } else {
            rotateWithKey();
        }

    }

    private void rotateWithKey() {
        /* Поворот персонажа в сторону движения по кнопке
        */
        Vector3 directionInput = new Vector3(horizontalInput, 0, verticalInput);
        if (directionInput != Vector3.zero) {
            // Если лицо направлено в сторону z
            //transform.forward = directionInput.normalized;
            // Если мы разместили лицо справа (по x)
            transform.forward = Quaternion.Euler(0, -90, 0) * directionInput.normalized;
        }
    }

    private void rotateWithMouse() {
        /* Поворот персонажа в сторону курсора мыши
           глаза должны быть направлены в x сторону
        */
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}
