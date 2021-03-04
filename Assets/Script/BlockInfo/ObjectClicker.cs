using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    public string popUp;
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                    //PopUpWIndow();
                }
            }
        }

       
    }

     void PrintName(GameObject block)
    {
        print(block.name);
    }

    // void PopUpWIndow()
    //{
    //    PopUpInfo pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpInfo>();
    //    pop.PopUp(popUp);
    //}

}
