using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlorisDeVToolsMathLibrary.BSpline
{
    public class BSplineVisualiser : MonoBehaviour
    {
        private BSplineCalculator _calculator;
        [SerializeField] private List<Transform> _points;
        [SerializeField] private Transform _handle;
        [SerializeField] private float _travelTime;

        private float _timer = 0f;

        private void OnEnable()
        {
            _calculator = new BSplineCalculator(_points.Select(x => x.position).ToList());
            _timer = 0f;
        }

        private void FixedUpdate()
        {
            _calculator.SetPoints(_points.Select(x => x.position).ToList());

            _timer += Time.fixedDeltaTime;

            var percentage = _timer / _travelTime;
            if (percentage < .99)
            {
                _handle.position = _calculator.SampleSpline(percentage);
                return;
            }

            _handle.position = _calculator.SampleSpline(1f);
            _timer = 0;
        }
    }
}