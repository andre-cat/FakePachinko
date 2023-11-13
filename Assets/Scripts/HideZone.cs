using System.Collections;
using UnityEngine;

public class HideZone : MonoBehaviour
{

    [SerializeField] private float blinkWait = 0f;
    [SerializeField] private float blinkTime = 0f;
    [SerializeField] private float blinkEvery = 0f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(BlinkAndDrop(collision.gameObject, blinkWait, blinkTime, blinkEvery));
        }
    }

    private IEnumerator BlinkAndDrop(GameObject gameObject, float blinkWait, float blinkTime, float blinkEvery)
    {
        yield return StartCoroutine(Project.Tools.BlinkObject(gameObject, blinkWait, blinkTime, blinkEvery));
        gameObject.SetActive(false);
    }


}
