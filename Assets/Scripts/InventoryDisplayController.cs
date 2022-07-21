using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayController : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    private GameObject[] _bar = new GameObject[10];

    [SerializeField] private GameObject selector;
    private int _selection;
    

    [SerializeField] private float start = -250;
    [SerializeField] private float spacing = 60;
    [SerializeField] private float size = 50;
    
    void Awake()
    {
        for (int i = 0; i < _bar.Length; i++)
        {
            _bar[i] = Instantiate(icon);
            _bar[i].transform.SetParent(transform);
            _bar[i].GetComponent<RectTransform>().localPosition = new Vector3(start + i * spacing, 0, 0);
            //_bar[i].GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }
        selector.transform.localPosition = _bar[0].transform.localPosition;
    }
    
    IEnumerator UpdateDisplay(int index)
    {

        selector.transform.localPosition = _bar[index].transform.localPosition;
        yield break;
    }
}
