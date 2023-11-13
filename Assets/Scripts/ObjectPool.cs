using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] private GameObject[] pachinkoBalls;
    [SerializeField] private Transform spawnZone;
    [SerializeField] private Transform hideZone;
    [SerializeField] private int objectQuantity = 1;
    [SerializeField] private float unpoolSeconds = 1f;

    private Transform pool;
    private float timePassed;

    private void Awake()
    {
        pool = transform;
        FillPool(pool, pachinkoBalls, objectQuantity);
    }

    private void Start()
    {
        timePassed = 0f;
    }

    private void FillPool(Transform pool, GameObject[] childObject, float childQuantity)
    {
        foreach (GameObject gameObject in childObject)
        {
            for (int j = 0; j < childQuantity; j++)
            {
                GameObject obj = Instantiate(gameObject, pool.position, Quaternion.identity, pool);
                obj.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= unpoolSeconds)
        {
            timePassed = 0;

            GameObject child = TakeOneFromPool(pool);

            if (!child.activeSelf)
            {
                SpawnOne(child, spawnZone);
            }
        }
    }

    private GameObject TakeOneFromPool(Transform pool)
    {
        int childIndex = (new System.Random()).Next(0, pool.childCount - 1);
        return pool.GetChild(childIndex).gameObject;
    }

    private void SpawnOne(GameObject child, Transform spawnZone)
    {
        (float min, float max) = Project.Tools.GetRange(spawnZone, Project.Axis.X);

        float width = child.transform.localScale.x; // width of current child
        float height = child.transform.localScale.y; // height of current child

        float x = UnityEngine.Random.Range(min + width / 2, max - width / 2);
        float y = spawnZone.position.y - height / 2;

        child.transform.position = new Vector3(x, y);
        child.SetActive(true);
    }
}
