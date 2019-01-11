using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Mouse Look/Keyboard Movement")]
public class KeyboardMovement : MonoBehaviour
{
    private CharacterController _character;

    public float movementSpeed = 12f;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
        float deltaZ = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, movementSpeed); // сделано чтоб скорость по диагонали была равна скорости по прямым

        movement.y = gravity; // задание гравитации, чтобы игрок не мог перемещаться по y (летать)
        movement *= Time.deltaTime; // deltatime задает единую скорость перемещения для всех процессоров
        movement = transform.TransformDirection(movement); // перевод из локальной системы координат в глобальную

        _character.Move(movement);
    }
}
