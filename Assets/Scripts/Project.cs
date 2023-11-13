using System.Collections;
using UnityEngine;

namespace Project
{

    enum Axis
    {
        X,
        Y,
        Z
    }

    class Tools
    {

        public static (float, float) GetRange(Transform transform, Axis axis)
        {
            var range = (0f, 0f);

            switch (axis)
            {
                case Axis.X:
                    float minX = transform.position.x - transform.localScale.x / 2;
                    float maxX = transform.position.x + transform.localScale.x / 2;
                    range = (minX, maxX);
                    break;
                case Axis.Y:
                    float minY = transform.position.y - transform.localScale.y / 2;
                    float maxY = transform.position.y + transform.localScale.y / 2;
                    range = (minY, maxY);
                    break;
                case Axis.Z:
                    float minZ = transform.position.z - transform.localScale.z / 2;
                    float maxZ = transform.position.z + transform.localScale.z / 2;
                    range = (minZ, maxZ);
                    break;
            }

            return range;
        }

        public static IEnumerator BlinkObject(GameObject gameObject, float blinkWait, float blinkTime, float blinkEvery)
        {

            yield return new WaitForSeconds(blinkWait);

            Color oldColor = gameObject.GetComponent<Renderer>().material.color;

            float oldAlpha = oldColor.a;

            for (float time = 0; time < blinkTime; time += blinkEvery)
            {

                float alpha = gameObject.GetComponent<Renderer>().material.color.a == oldAlpha ? 0 : oldAlpha;

                gameObject.GetComponent<Renderer>().material.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);

                yield return new WaitForSeconds(blinkEvery);
            }

            gameObject.GetComponent<Renderer>().material.color = oldColor;

            yield break;
        }

        public static IEnumerator ColorizeObject(GameObject gameObject, Color color, float transitionTime)
        {
            Color oldColor = gameObject.GetComponent<Renderer>().material.color;

            float elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                elapsedTime += Time.deltaTime;
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(oldColor, color, elapsedTime / transitionTime);
                yield return null;
            }

            yield break;
        }

        public static IEnumerator ScaleObject(GameObject gameObject, Vector3 scale, float transitionTime)
        {
            Vector3 oldScale = gameObject.transform.localScale;

            float elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                elapsedTime += Time.deltaTime;
                gameObject.transform.localScale = Vector3.Lerp(oldScale, scale, elapsedTime / transitionTime);
                yield return null;
            }

            yield break;
        }
    }
}
