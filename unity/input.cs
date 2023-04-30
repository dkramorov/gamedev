using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour {
    /*
        Добавить CharacterController в компоненты объекта
        Добавить CapsuleCollider в компоненты объекта
        ?Добавить RigidBody в компоненты объекта
        добавить скрипт объекту
    */

    CharacterController charController; // Компонент контроллера перемещения
    float moveSpeed = 5.0f; // скорость
    float horizontalInput; // величина перемещения по горизонтали
    Vector3 movement; // величина перемещения

    float jumpHeight = 0.5f;
    float gravity = 0.045f;
    bool isJump = false; // начат прыжок

    void Start() {
        charController = GetComponent<CharacterController>();
        if(!charController) {
            Debug.LogError("charController absent");
        }
    }

    void Update() {
        // Настройки Input: Edit - Project Settings - InputManager
        horizontalInput = Input.GetAxis("Horizontal");
        checkJumpStarted();
    }

    private void FixedUpdate() {
        if (charController) {
            move();
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
        movement.x = horizontalInput * moveSpeed * Time.deltaTime;
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
}
