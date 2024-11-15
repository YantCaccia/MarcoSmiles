using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{

    // Change it in some way
    // private List<string> orderedNotes = new List<string> { "DO5", "DO#5", "RE5", "RE#5", "MI5", "FA5", "FA#5", "SOL5", "SOL#5", "LA5", "LA#5", "SI5", "DO4", "DO#4", "RE4", "RE#4", "MI4", "FA4", "FA#4", "SOL4", "SOL#4", "LA4", "LA#4", "SI4", "DO3", "DO#3", "RE3", "RE#3", "MI3", "FA3", "FA#3", "SOL3", "SOL#3", "LA3", "LA#3", "SI3" };

    [SerializeField]
    private GameObject _keyboard;
    private List<GameObject> _keys;
    public static List<GameObject> SelectedKeys = new List<GameObject>();

    private GameObject _firstSelectedKey;
    public GameObject FirstSelectedKey
    {
        get => _firstSelectedKey;
        set
        {
            _firstSelectedKey = value;
            if (_firstSelectedKey != null)
                _firstSelectedKey.GetComponent<Image>().color = GetSelectedColor(_firstSelectedKey.name);
        }
    }

    private GameObject _lastSelectedKey;
    public GameObject LastSelectedKey
    {
        get => _lastSelectedKey;
        set
        {
            _lastSelectedKey = value;
            if (_lastSelectedKey != null)
                _lastSelectedKey.GetComponent<Image>().color = GetSelectedColor(_lastSelectedKey.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> allChildren = GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToList();
        _keys = allChildren.Where(k => k.tag == "Key").ToList();
        _keys = _keys.OrderBy(k => new Note(k.name).Octave).ThenBy(k => new Note(k.name).Pitch).ToList();

        foreach (GameObject key in _keys)
        {
            Toggle keyToggle = key.GetComponent<Toggle>();
            keyToggle.onValueChanged.AddListener(delegate
            {
                SelectKey(keyToggle);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        // ResetKeys();
    }

    public void SelectKey(Toggle keyToggle)
    {
        if (keyToggle.isOn)
        {
            if (FirstSelectedKey == null && LastSelectedKey == null)
            {
                FirstSelectedKey = keyToggle.gameObject;
            }
            else if (FirstSelectedKey != null && LastSelectedKey == null)
            {
                LastSelectedKey = keyToggle.gameObject;
                ComputeSelectedKeys();
            }
            else
            {
                ResetKeys();
                FirstSelectedKey = keyToggle.gameObject;
                LastSelectedKey = null;
            }
        }
    }

    private void ComputeSelectedKeys()
    {
        if (FirstSelectedKey != null && LastSelectedKey != null)
        {
            float firstSelectedKeyPositionX = FirstSelectedKey.GetComponent<Transform>().position.x;
            float lastSelectedKeyPositionX = LastSelectedKey.GetComponent<Transform>().position.x;
            foreach (GameObject key in _keys)
            {
                float keyPositionX = key.GetComponent<Transform>().position.x;
                if ((keyPositionX >= firstSelectedKeyPositionX && keyPositionX <= lastSelectedKeyPositionX)|| 
                    (keyPositionX <= firstSelectedKeyPositionX && keyPositionX >= lastSelectedKeyPositionX))
                {
                    key.GetComponent<Image>().color = GetSelectedColor(key.name);
                    SelectedKeys.Add(key);
                }
            }
        }
    }

    private void ResetKeys()
    {
        foreach (GameObject key in _keys)
        {
            key.GetComponent<Image>().color = GetResetColor(key.name);
        }
        SelectedKeys.Clear();
        FirstSelectedKey = null;
        LastSelectedKey = null;
    }

    private static Color GetResetColor(string keyName)
    {
        if (keyName.Contains("#"))
        {
            return Color.black;
        }
        else
        {
            return Color.white;
        }
    }

    private static Color GetSelectedColor(string keyName)
    {
        Color color;
        if (keyName.Contains("#"))
        {
            ColorUtility.TryParseHtmlString("#2D5B2A", out color);
        }
        else
        {
            ColorUtility.TryParseHtmlString("#3F903A", out color);
        }
        return color;
    }

}
