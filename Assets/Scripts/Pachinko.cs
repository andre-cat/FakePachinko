using TMPro;
using UnityEngine;

class Pachinko  : MonoBehaviour
{
    public static int point = 0;

    [SerializeField] TMP_Text pointsText;

    private void Update(){
        pointsText.text = $"Deadly objects: {point}";
    }

}
