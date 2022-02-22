using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// For Bucks Row and Hanburry Street 
// For Map Interaction + Statement Zoom
// When Map clicked > Rotate to 0 and open BR/HBS Pictures
public class Zoomer : MonoBehaviour
{
    public GameObject 
        middlePoint, // for moving the map
        canvas, 
        targetBR, // BR Picture
        targetHBS; // HBS Picture
    Vector3 originalPos, mPPos; // Original Positions
    Quaternion originalRot, mPRot; // Original Rotations
    private bool zoom; // is currently zoomed?
    public GameObject Controller; // Check for annie bool > activate HBS Picture if true;

    Vector3 oriLocScale; // original Local Scale
    Vector2 sizeD; // original Size

    // Size Pictures according to Screensize. Zoom Factors given in:
    private Vector3 scaleFactorBR, scaleFactorHBS;

    //Map and Target Sprites
    public Sprite emptyMap;
    public Sprite bucksRow;
    public Sprite hanburryStreet;
   
    void Start()
    {
        zoom = false;
        originalPos = transform.position;
        originalRot = transform.rotation;
        mPPos = middlePoint.transform.position;
        mPRot = middlePoint.transform.rotation;
        oriLocScale = transform.localScale;
        scaleFactorBR = new Vector3(2f, 2f, 2f);
        scaleFactorHBS = new Vector3(1.5f, 1.5f, 1.5f);
        sizeD = GetComponent<RectTransform>().sizeDelta;
    }

    //Handels Statements
    void Update()
    {
        //If BR Statements are klicked: zoom in or out
        if (tag == "Statement" && zoom)
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 temp = new Vector3(transform.position.x, (Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime) + transform.position.y, transform.position.z);
                transform.GetComponent<RectTransform>().position = temp;
            }
            else
            {
                Vector3 lScale = transform.localScale;
                lScale.x += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 20;
                lScale.y = lScale.z = lScale.x;
                transform.localScale = lScale;
            }
        }
        //Doctor Statement exception because its longer
        if (name == "Statement1")
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(sizeD.x, sizeD.y * 2);
        }
        //Return to normal size
        if (!zoom)
        {
            transform.localScale = oriLocScale;
            if (name == "Statement1")
            {
                GetComponent<RectTransform>().sizeDelta = sizeD;
            }
        }
    }

    //Handels Map zoom
    //If zoomed in, zoom out
    //If zoomed out, zoom in
    public void Klicked()
    {
        if (zoom == false)
        {
            zoom = true;
            transform.position = mPPos;
            transform.rotation = mPRot;
            transform.GetComponent<RectTransform>().sizeDelta *= scaleFactorBR;
            // Lays statement on top, so no Sprite is in front
            if (transform.name != "Map")
            {
                int tmp = GetComponentInParent<Transform>().gameObject.transform.GetSiblingIndex();
                GetComponentInParent<Transform>().gameObject.transform.SetSiblingIndex(tmp + 1);
            }
        }
        else
        {
            zoom = false;
            transform.position = originalPos;
            transform.rotation = originalRot;
            transform.GetComponent<RectTransform>().sizeDelta /= scaleFactorBR;
            // Lays statement on top, so no Sprite is in front
            if (transform.name != "Map")
            {
                int tmp = GetComponentInParent<Transform>().gameObject.transform.GetSiblingIndex();
                GetComponentInParent<Transform>().gameObject.transform.SetSiblingIndex(tmp + 1);
            }
        }
    }

    //Handels Targets if Map is already zoomed
    //Zooms Targets again > Screensize
    public void Klicked2()
    {
        if (zoom == false)
        {
            zoom = true;
            transform.position = mPPos;
            transform.rotation = mPRot;
            transform.GetComponent<RectTransform>().sizeDelta *= scaleFactorHBS;
            if (transform.name != "Map")
            {
                // Lays statement on top, so no Sprite is in front
                int tmp = GetComponentInParent<Transform>().gameObject.transform.GetSiblingIndex();
                GetComponentInParent<Transform>().gameObject.transform.SetSiblingIndex(tmp + 1);
            }
        }
        else
        {
            zoom = false;
            transform.position = originalPos;
            transform.rotation = originalRot;
            transform.GetComponent<RectTransform>().sizeDelta /= scaleFactorHBS;
            if (transform.name != "Map")
            {
                // Lays statement on top, so no Sprite is in front
                int tmp = GetComponentInParent<Transform>().gameObject.transform.GetSiblingIndex();
                GetComponentInParent<Transform>().gameObject.transform.SetSiblingIndex(tmp + 1);
            }
        }
    }
    
    //If Map active > Activate Targets
    //+++ ANNIE Bool
    public void Map()
    {
        if (zoom == false)
        {
            GetComponent<Image>().sprite = bucksRow;
            targetBR.SetActive(true);
            // if already at HBS (annie == true) > Change sprite to HBS included one
            if (Controller.GetComponent<MainController>().annie == true)
            {
                targetHBS.SetActive(true);
                GetComponent<Image>().sprite = hanburryStreet;
            }
        }
        else
        {
            GetComponent<Image>().sprite = emptyMap;
            targetBR.SetActive(false);
            // if already at HBS (annie == true) > Change sprite to HBS included one
            if (Controller.GetComponent<MainController>().annie == true)
            {
                targetHBS.SetActive(false);
            }
        }
    }

    //Statements
    // Lay last used statement on top of others
    // Much Realism
    // Such visual effect, that no one recognizes :<
    public void Statements()
    {
        if (zoom == false)
        {
            //Foreground
            transform.SetAsLastSibling();
        }
        else
        {
            //Background
            transform.SetAsFirstSibling();
        }
    }
    
    // Resizes Target to Screen height
    // > Biggest possible size on Screen 
    public void Target(GameObject cur)
    {
        if (!zoom)
        {
            cur.gameObject.transform.localScale = new Vector2(cur.gameObject.transform.localScale.x, cur.gameObject.transform.localScale.y) * 2;
            zoom = false;
        }
        else
        {
            cur.gameObject.transform.localScale = new Vector2(cur.gameObject.transform.localScale.x, cur.gameObject.transform.localScale.y) * 0.5f;
            zoom = true;
        }
    }
}
