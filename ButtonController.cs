using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private int collisionCount = 0;
    private Vector3 upPosition;
    private Vector3 downPosition;
    public float buttonPressedOffset;

    public GameObject cursor;


    // Start is called before the first frame update
    void Start()
    {
        upPosition = transform.localPosition;
        downPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - buttonPressedOffset, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionCount++;
        if (collisionCount >= 1)
        {
            transform.localPosition = downPosition;

            // Add individual key functions here
            if (CompareTag("BackKey"))
            {
                cursor.GetComponent<ComputerController>().BackButtonPressed();
            } else if (CompareTag("DeleteKey"))
            {
                cursor.GetComponent<ComputerController>().DeleteButtonPressed();
            } else if (CompareTag("EnterKey"))
            {
                cursor.GetComponent<ComputerController>().EnterButtonPressed();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
        if (collisionCount == 0)
        {
            transform.localPosition = upPosition;
        }
    }
}
