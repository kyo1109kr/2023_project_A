using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemlnfo : MonoBehaviour
{
    public int slotld;
    public int itemld;

    public void InitDummy(int slotld, int itemld)
    {
        this.slotld = slotld;
        this.itemld = itemld;
    }   
}
