using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsManager : MonoBehaviour
{
    private List<GameObject> systems;
    private bool canBreak;
    [SerializeField] int minTime, maxTime;
    void Start()
    {
        systems = new List<GameObject>();
        systems.AddRange(GameObject.FindGameObjectsWithTag("Systems"));
        findSystems();
    }

    //Start loop to find 'broken' systems in random time range
    void findSystems()
    {
        this.canBreak = true;
        foreach(GameObject sys in systems) {
            SystemsController controller = sys.GetComponent<SystemsController>();
            if (controller.isBroken) {this.canBreak = false;}
            if (controller.isGameOver()) { return; }
        }
        int time;
        time = Random.Range(minTime, maxTime);
        StartCoroutine(SystemBreak(time));
    }

    //Loop to determine which system breaks
    IEnumerator SystemBreak(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int systemNum = Random.Range(0, systems.Count);
        if (this.canBreak) { systems[systemNum].GetComponent<SystemsController>().Break(); }

        findSystems();
    }

}
