using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructor : MonoBehaviour
{
    public float maxDistance = Mathf.Infinity;

    private BreakableBlock prevBlock = null;

    void FixedUpdate()
    {
        var brokenBlock = BreakBlock();

        if(brokenBlock != prevBlock) {
            if(prevBlock)
                prevBlock.RevertBreak();

            prevBlock = brokenBlock;
        }
    }

    BreakableBlock BreakBlock() {
        if(!Input.GetMouseButton(0)) { return null; }

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("Block"))) { return null; }

        var block = hit.transform.gameObject.GetComponent<BreakableBlock>();
        block.Break();
        return block;
    }
}
