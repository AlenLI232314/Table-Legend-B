using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    public string popUp;
    //public float panSpeed = 20f;
    //public float panBorderThickness = 10f;
    //public Vector2 panLimit;
    //public float scrollSpeed = 2f;
    void Update()
    {

        //Vector3 pos = transform.position;
        //if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        //{
        //    pos.z += panSpeed * Time.deltaTime;
        //}

        //if (Input.mousePosition.y <= Screen.height - panBorderThickness)
        //{
        //    pos.z -= panSpeed * Time.deltaTime;
        //}

        //if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        //{
        //    pos.z += panSpeed * Time.deltaTime;
        //}

        //if (Input.mousePosition.x <= Screen.width - panBorderThickness)
        //{
        //    pos.z -= panSpeed * Time.deltaTime;
        //}

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //pos.y += scroll * scrollSpeed * Time.deltaTime;

        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);



    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (Physics.Raycast(ray, out hit, 500f))
    //        {
    //            if (hit.transform != null)
    //            {
    //                PrintName(hit.transform.gameObject);
    //                PopUpWIndow();
    //            }
    //        }
    //    }




    //}

    void OnMouseDown()
    {
            PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
            pop.PopUp(popUp);
    }

    void PrintName(GameObject block)
    {
            print(block.name);
    }



    }
}

