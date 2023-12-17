using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    // Update is called once per frame
    void Update()
    {
        clockText.text = System.DateTime.Now.ToString("h:mm tt");
    }
}
