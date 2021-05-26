using UnityEngine;

public class CharacterBodiesPusher : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    public float PushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // без твердости (rigidbody)
        if (body == null || body.isKinematic)
        {
            return;
        }

        // Не толкаем объекты под нами 
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Высчитываем направление деша в сторону передвижения,
        // мы только толкаем предметы в стороны никогда вверх или вниз
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Толкаем
        body.velocity = pushDir * PushPower;
    }
}
