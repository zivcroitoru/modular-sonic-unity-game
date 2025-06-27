// using System.Collections;
// using UnityEngine;

// // A laser that moves upward and disappears after a while
// public class ProjectileLaser : BaseProjectile
// {
//     // Starts the laser movement and the timer to deactivate it
//     public override void Shoot()
//     {
//         StartCoroutine(ManualMove());      // Start moving up
//         StartDeactivateTimer();            // Turn off after a few seconds
//     }

//     // Moves the laser upward every frame
//     // private IEnumerator ManualMove()
//     // {
//     //     while (true)
//     //     {
//     //         transform.position += Vector3.up * _speed * Time.deltaTime;
//     //         yield return null; // Wait until next frame
//     //     }
//     // }
//         private IEnumerator ManualMove()
//     {
//         while (true)
//         {
//             transform.position += transform.up * _speed * Time.deltaTime;
//             yield return null;
//         }
//     }
// }

using System.Collections;
using UnityEngine;

// A laser that moves in the direction it’s facing and disappears after a while
public class ProjectileLaser : BaseProjectile
{
    private Vector3 _direction;

    // Call this to shoot in a specific direction (e.g., transform.up)
    public void Fire(Vector3 direction)
    {
        _direction = direction.normalized;
        Shoot();
    }

    // Starts the laser movement and the timer
    public override void Shoot()
    {
        StartCoroutine(ManualMove());
        StartDeactivateTimer();
    }

    // Moves the laser every frame in the given direction
    private IEnumerator ManualMove()
    {
        while (true)
        {
            transform.position += _direction * _speed * Time.deltaTime;
            yield return null;
        }
    }
}
