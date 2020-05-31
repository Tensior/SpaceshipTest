using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {

        private static Camera _camera;

        private static readonly object CameraLock = new object();

        //Need some way to reinit camera when the scene is reloaded
        private static Camera MainCamera
        {
            get
            {
                if ( _camera == null )
                {
                    lock ( CameraLock )
                    {
                        if ( _camera == null )
                        {
                            _camera = Camera.main;
                        }
                    }
                }
                return _camera;
            }
        }

        public static bool IsInGameplayArea(Vector3 objectPos, Bounds objectBounds, bool boundsInArea = false)
        {
            var camHalfHeight = MainCamera.orthographicSize;
            var camHalfWidth = camHalfHeight * MainCamera.aspect;
            var camPos = MainCamera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            int boundsSign = boundsInArea ? -1 : 1;

            return (objectPos.x - objectBounds.extents.x * boundsSign < rightBound)
                && (objectPos.x + objectBounds.extents.x * boundsSign > leftBound)
                && (objectPos.y - objectBounds.extents.y * boundsSign < topBound)
                && (objectPos.y + objectBounds.extents.y * boundsSign > bottomBound);

        }
        
    }
}
