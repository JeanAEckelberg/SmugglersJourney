using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayController : MonoBehaviour
{
    [SerializeField] private GameObject Icon;
    private GameObject[] _bar = new GameObject[10];

    [SerializeField] private float start = -250;
    [SerializeField] private float spacing = 60;
    [SerializeField] private float size = 50;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _bar.Length; i++)
        {
            _bar[i] = Instantiate(Icon);
            _bar[i].transform.SetParent(transform);
            _bar[i].GetComponent<RectTransform>().localPosition = new Vector3(start + i * spacing, 0, 0);
            //_bar[i].GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }
    }

    // Update is called once per frame
    IEnumerator UpdateDisplay(int index)
    {
        foreach (var t in _bar)
        {
            t.GetComponent<Image>().color = Color.white;
        }

        _bar[index].GetComponent<Image>().color = Color.red;
        yield break;
    }
}
