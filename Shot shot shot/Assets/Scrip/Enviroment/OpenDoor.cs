using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform point;
    private Transform door;
    private float speed = 3;
    void Start()
    {
        door = GetComponent<Transform>();
    }

    public void OpDoor()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, point.position, step);
    }

}
