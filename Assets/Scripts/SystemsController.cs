using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsController : MonoBehaviour
{
    [SerializeField] GameObject part;
    [SerializeField] GameObject tool;

    //100 is full resistance, 0 is none
    [SerializeField] int resistance;

    public void Break()
    {
        int breakChance = Random.Range(0, 100);

        //If system resists, lower its durability by 5%
        if (resistance > breakChance) {
            resistance = Mathf.CeilToInt(resistance * .95f);
            return;
        }
        else
        {
            Debug.Log(gameObject.name);
        }
    }

}
