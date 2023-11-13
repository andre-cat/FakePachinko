using System.Collections;
using UnityEngine;

public class BatController : MonoBehaviour
{

    [SerializeField] private float speed = 0f;
    [SerializeField] private Transform[] transforms;

    void Start()
    {
        StartCoroutine(FollowRandomTransform(transform, transforms, speed));
    }

    private IEnumerator FollowRandomTransform(Transform currentTransform, Transform[] transforms, float speed)
    {
        while (true)
        {
            Transform randomTransform = transforms[Random.Range(0, transforms.Length)];
            float randomSpeed = new float[3] { speed, speed * 2, speed }[Random.Range(0, 2)];
            yield return StartCoroutine(FollowTransform(currentTransform, randomTransform, speed));
        }
    }

    private IEnumerator FollowTransform(Transform currentTransform, Transform targetTransform, float speed)
    {
        while (Vector3.Distance(currentTransform.position, targetTransform.position) > 0.1)
        {
            currentTransform.SetPositionAndRotation(Vector3.Lerp(currentTransform.position, targetTransform.position, speed * Time.deltaTime), Quaternion.Lerp(transform.rotation, targetTransform.rotation, speed * Time.deltaTime));
            yield return null;
        }
    }

}
