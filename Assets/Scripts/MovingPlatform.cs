using System.Collections.Specialized;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public bool going;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = point1.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition = Vector3.zero;

        if (going)

            wantedPosition = point2.position;
        else
            wantedPosition = point1.position;

        Vector3 direction = wantedPosition - transform.position;

        transform.position += direction.normalized * Time.deltaTime;

        if (direction.magnitude < 1)
            going = !going;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
