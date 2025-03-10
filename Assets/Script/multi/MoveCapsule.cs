using UnityEngine;

public class MoveCapsule : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        MoveServerRpc(movement);
    }
    void MoveServerRpc(Vector3 movement)
    {
        transform.Translate(movement, Space.World);
    }
}
