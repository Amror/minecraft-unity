using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructor : MonoBehaviour
{
    void FixedUpdate()
    {
        BreakBlock();
    }

    void BreakBlock() {
        if(!Input.GetMouseButton(0)) { return; }

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!Physics.Raycast(ray, out hit)) { return; }

        if(hit.transform.gameObject.tag != "Block") { return; }

        hit.transform.gameObject.GetComponent<BreakableBlock>().Break();
    }
}
