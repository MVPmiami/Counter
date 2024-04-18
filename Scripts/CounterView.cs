using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMesh;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _textMesh.text = _counter.Count.ToString();
    }

    private void OnEnable()
    {
        _counter.CountChanged += ChangeCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangeCount;
    }

    private void ChangeCount()
    {
        _textMesh.text = _counter.Count.ToString();
    }

}
