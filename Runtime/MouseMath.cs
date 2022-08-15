using UnityEngine;

namespace FlorisDeVToolsMathLibrary
{
    public static class MouseMath
    {
        public static Vector3 MouseWorldPosition(Vector2 screenPos, float height)
        {
            var camera = Camera.main;
            var plane = new Plane(Vector3.up, new Vector3(0, height, 0));

            var ray = camera!.ScreenPointToRay(screenPos);
            float dist = 0;
                
            return plane.Raycast(ray, out dist) ? ray.GetPoint(dist) : Vector3.one;
        }

        public static Vector2 MouseWorldPosition2D(Vector2 screenPos)
        {
            if (Camera.main != null) 
                return Camera.main.ScreenToWorldPoint(screenPos);
            
            Debug.LogWarning("No main camera found!");
            return Vector2.zero;
        }
    }
}