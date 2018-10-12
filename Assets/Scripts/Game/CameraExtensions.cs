using UnityEngine;

namespace Game
{
    public static class CameraExtensions
    {
        public static Bounds OrthographicBounds(this Camera camera)
        {
            var screenAspect = (float) Screen.width / Screen.height;
            var cameraHeight = camera.orthographicSize * 2;
            var bounds = new Bounds(
                camera.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0f));
            
            return bounds;
        }
        
        public static Rect OrthographicRect(this Camera camera)
        {
            var screenAspect = (float) Screen.width / Screen.height;
            var cameraHeight = camera.orthographicSize * 2;
            var center = camera.transform.position;
            var halfWidth = cameraHeight * screenAspect / 2;
            var halfHeight = cameraHeight / 2;
            
            var rect = new Rect(
                new Vector2(center.x - halfWidth, center.y - halfHeight),
                new Vector2(center.x + halfWidth * 2, center.y + halfHeight * 2)
            );
            
            return rect;
        }
    }
}