using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlorisDeVToolsMathLibrary.BSpline
{
    public class BSplineCalculator
    {
        private List<Vector3> _points;

        public int NumberOfPoints => _points.Count;
        
        public BSplineCalculator(List<Vector3> points)
        {
            _points = points;
        }

        public void SetPoint(int index, Vector3 point)
        {
            if (index > NumberOfPoints - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            
            _points[index] = point;
        }

        public void SetPoints(List<Vector3> newPoints)
        {
            _points = newPoints;
        }

        public Vector3 SampleSpline(float percentage)
        {
            var points = _points;
            
            while (true)
            {
                switch (points.Count)
                {
                    case 0:
                        throw new ArgumentOutOfRangeException(nameof(points));
                    case 1:
                        return points.First();
                }

                var newPoints = new List<Vector3>();

                for (var i = 0; i < points.Count - 1; i++)
                {
                    newPoints.Add(Vector3.Lerp(points[i], points[i + 1], percentage));
                }

                points = newPoints;
            }
        }
    }
}