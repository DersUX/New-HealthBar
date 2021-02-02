using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fadingTime;

    public void OnValueChanged(float value, float maxValue)
    {
        StartCoroutine(SmoothCorrentValue(_slider.value, (float)value / maxValue));
        //_slider.value = (float)value / maxValue;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
    private IEnumerator SmoothCorrentValue(float from, float to)
    {
        float time = 0.0f;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (1.0f / _fadingTime);
            _slider.value = Mathf.Lerp(from, to, time);

            yield return 0;
        }
    }
}
