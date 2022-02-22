using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpeech : MonoBehaviour
{
    Touch touch;
    public GameObject bubble;
    bool open = false;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(touch.position));
            if (hits != null)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (touch.phase == TouchPhase.Ended && hit.collider.gameObject == this.gameObject)
                    {
                        if (open == true)
                        {
                            bubble.SetActive(false);
                            open = false;
                        }
                        else
                        {
                            bubble.SetActive(true);
                            open = true;
                        }
                    }
                }
            }
        }
    }
}
