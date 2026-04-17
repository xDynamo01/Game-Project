using UnityEngine;
using UnityEngine.InputSystem; // 1. Add this namespace

public class movimento : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;

    private float velocidade = 10f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 2. Use the new syntax to get movement values
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            // This replaces Input.GetAxis
            float moveX = Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue();
            float moveZ = Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue();
            inputs.Set(moveX, 0, moveZ);
        }

        // Movimentação
        character.Move(inputs * Time.deltaTime * velocidade);
    }
}