using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _count;
    private bool _isActive;
    private float _delay = 0.5f;
    private Coroutine _coroutine;

    public int Count => _count;
    public event Action CountChanged;

    private void Start()
    {
        _count = 0;
        _isActive = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;

            if (_isActive)
                Restart();
            if(!_isActive)
                Stop();
        }
    }

    private IEnumerator CountUp(int initValue)
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _count++;
            CountChanged?.Invoke();

            yield return wait;
        }
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(CountUp(_count));
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
