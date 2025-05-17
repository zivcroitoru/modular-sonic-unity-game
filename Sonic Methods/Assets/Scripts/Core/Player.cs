using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputManager), typeof(AnimatorManager), typeof(Sensors))]
public class Player : MonoBehaviour
{
    // Core state
    public Vector2 velocity;
    public float groundVelocity;
    private bool grounded;

    InputManager input;
    AnimatorManager anim;
    Sensors sensors;

    void Awake()
    {
        input = GetComponent<InputManager>();
        anim = GetComponent<AnimatorManager>();
        sensors = GetComponent<Sensors>();
    }

    void Update()
    {
        // flip sprite & set animator flags
        anim.SetBool("IsWalking", grounded && input.Horizontal != 0);
        anim.SetBool("IsInAir", !grounded);

        // ... any other pure input→anim stuff
    }

    void FixedUpdate()
    {
        grounded = sensors.CheckGrounded();

        // MovementProcessor is injected or found elsewhere:
        MovementProcessor.Apply(ref groundVelocity, ref velocity, grounded, input.Horizontal);

        sensors.MoveAndCollide(grounded ?
                                MovementProcessor.ToWorld(groundVelocity) : velocity);
    }
}
