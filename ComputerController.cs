using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ComputerController : MonoBehaviour
{
    // Cursor movement
    public GameObject mouse;
    public float sensitivity;

    // UI Elements
    public GameObject grothIcon;
    public GameObject grothMenu;
    public GameObject x;
    public GameObject wifi;
    public GameObject wifiMenu;

    // SteamVR Stuff
    public SteamVR_Input_Sources inputSource;
    private SteamVR_Action_Boolean triggerAction;
    private bool triggerPulled = false;

    private void Start()
    {
        // SteamVR Stuff
        triggerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "InteractUI");
        BackButtonPressed();
    }


    // Update is called once per frame
    void Update()
    {
        // Cursor movement
        transform.localPosition = new Vector3(-mouse.transform.localPosition.x * sensitivity, -mouse.transform.localPosition.z * sensitivity, transform.localPosition.z);
    }


    private void OnTriggerStay(Collider other)
    {
        if (triggerAction.GetState(inputSource))
        {
            if (!triggerPulled)
            {
                triggerPulled = true;

                if (other.GetComponent<Button>() != null)
                {
                    other.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
        else
        {
            triggerPulled = false;
        }
    }


    // ========================= Desktop UI Buttons ======================
    public void grothIconClicked()
    {
        grothIcon.SetActive(false);
        grothMenu.SetActive(true);
    }

    public void xButtonClicked()
    {
        grothIcon.SetActive(true);
        grothMenu.SetActive(false);
    }

    public void WifiButtonClicked()
    {
        if (wifiMenu.activeSelf)
        {
            wifiMenu.SetActive(false);
        }
        else
        {
            wifiMenu.SetActive(true);
        }
    }


    // ========================= Keyboard Buttons ======================
    public void BackButtonPressed()
    {
        grothMenu.SetActive(false);
        wifiMenu.SetActive(false);
        grothIcon.SetActive(true);
    }

    public void DeleteButtonPressed()
    {

    }

    public void EnterButtonPressed()
    {

    }
}
