using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;

public class LinePayView : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Color _color;
    [SerializeField] private int _betNumber;
    private LineRenderer _line;
    private Image _image;
    private Toggle _toggle;
    private Text _text;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _line = GetComponent<LineRenderer>();
        _line.startColor = _line.endColor = _color;
        _image = GetComponentInChildren<Image>();
        _image.color = _color;
        _line.enabled = false;
        _text = GetComponentInChildren<Text>();
        _text.text = _betNumber.ToString();
        // _toggle.onValueChanged.AddListener(SetLine);
    }

    public void SetLine(bool value)
    {
        _line.enabled = value;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetLine(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetLine(false);
    }

    public void SetToggle(bool value)
    {
        _toggle.isOn = value;
    }
}
