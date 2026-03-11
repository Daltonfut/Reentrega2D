using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá


    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -1);
    }
}
