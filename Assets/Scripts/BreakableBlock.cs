using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public int ticksToBreak = 50;
    private int ticksLeft;
    private Renderer renderer;

    public void Awake() {
        ticksLeft = ticksToBreak;
        renderer = GetComponent<Renderer>();
    }

    public void Break() {
        ticksLeft--;

        renderer.material.color = Color.Lerp(Color.red, Color.green, (float)ticksLeft/ticksToBreak);

        if(ticksLeft <= 0) {
            Destroy(gameObject);
        }
    }
}
