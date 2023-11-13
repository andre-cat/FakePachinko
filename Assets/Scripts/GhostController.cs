using UnityEngine;

public class GhostController : MonoBehaviour
{

    [SerializeField] private Transform endPoint;
    [SerializeField] private float amplitude = 1.0f;
    [SerializeField] private float frequency = 1.0f;
    [SerializeField] private float velocity = 1.0f;

    private Vector3 iniPosition;
    private float elapsedTime = 0.0f;
    private float xFactor = 1;

    void Start()
    {
        iniPosition = transform.position;
    }

    void Update()
    {
        elapsedTime += velocity * Time.deltaTime;

        if (transform.position.x > endPoint.position.x)
        {
            xFactor = -1;
        }
        else if (transform.position.x < iniPosition.x)
        {
            xFactor = +1;
        }
        else if (inipoint.position.x == endPoint.position.x)
        {
            xFactor = 0;
        }

        float x = transform.position.x + (velocity * Time.deltaTime * xFactor);

        float y = iniPosition.y + amplitude * Mathf.Sin(frequency * elapsedTime);

        transform.position = new Vector3(x, y, iniPosition.z);
    }
}
