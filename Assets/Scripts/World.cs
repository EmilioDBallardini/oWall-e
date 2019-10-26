using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
public class World : MonoBehaviour
{
    public GameObject[] characters;
    GameObject currentCharacter;
    int charactersIndex;
    private bool pressed;
    void Start()
    {
        pressed = false;
        charactersIndex = 0;
        characters[0] = GameObject.FindGameObjectWithTag("oWall-e");
        characters[1] = GameObject.FindGameObjectWithTag("oEva");
        characters[1].GetComponent<Rigidbody>().isKinematic = true;
        characters[1].GetComponent<subController>().enabled = false;
        currentCharacter = characters[0];
        GameObject.Find("Main Camera").GetComponent<AutoCam>().myTarget = GameObject.Find("CenterOfCameraWalle").GetComponent<Transform>();
        GameObject.Find("CenterOfCameraEva").GetComponent<Transform>().rotation = characters[1].transform.rotation;
        GameObject.Find("CenterOfCameraWalle").GetComponent<Transform>().rotation = characters[0].transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            charactersIndex++;
            if (!pressed)
            {
                pressed = true;
                characters[1].GetComponent<Rigidbody>().isKinematic = false;
                characters[1].GetComponent<Rigidbody>().useGravity= true;
                new WaitForSecondsRealtime(2);
                characters[1].GetComponent<Rigidbody>().useGravity = false;
            }
            if(charactersIndex== characters.Length)
            {
                charactersIndex = 0;
            }
            if (currentCharacter.tag.Equals("oWall-e"))
            {
                currentCharacter.GetComponent<ShipController>().enabled = false;
                characters[charactersIndex].GetComponent<subController>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<AutoCam>().myTarget = GameObject.Find("CenterOfCameraEva").GetComponent<Transform>();
                currentCharacter = characters[charactersIndex];
            }
            else
            {
                if (currentCharacter.tag.Equals("oEva"))
                {
                    currentCharacter.GetComponent<subController>().enabled = false;
                    characters[charactersIndex].GetComponent<ShipController>().enabled = true;
                    GameObject.Find("Main Camera").GetComponent<AutoCam>().myTarget = GameObject.Find("CenterOfCameraWalle").GetComponent<Transform>();
                    currentCharacter = characters[charactersIndex];
                }
            }
            
        }    
    }

}
