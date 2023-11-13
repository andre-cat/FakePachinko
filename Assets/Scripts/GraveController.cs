using System.Collections;
using UnityEngine;

public class GraveController : MonoBehaviour
{

    [SerializeField] private GameObject monster;
    [SerializeField] private float monsterBlinkTime = 0f;

    [SerializeField] private Vector3 ballNewScale = new Vector3(0, 0, 0);
    [SerializeField] private float ballScaleTime = 0f;

    private void Awake()
    {
        monster.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(WaitForMonster(monster, monsterBlinkTime));
            StartCoroutine(WaitForBall(collision.gameObject, ballNewScale, ballScaleTime));
            Pachinko.point += 1;
        }
    }

    private IEnumerator WaitForMonster(GameObject monster, float blinkTime)
    {
        monster.SetActive(true);
        yield return StartCoroutine(Project.Tools.BlinkObject(monster, 0, blinkTime, 0.1f));
        monster.SetActive(false);
    }

    private IEnumerator WaitForBall(GameObject ball, Vector3 newScale, float scaleTime)
    {
        Vector3 oldScale = ball.transform.localScale;
        yield return StartCoroutine(Project.Tools.ScaleObject(ball, newScale, scaleTime));
        ball.SetActive(false);
        ball.transform.localScale = oldScale;
    }
}