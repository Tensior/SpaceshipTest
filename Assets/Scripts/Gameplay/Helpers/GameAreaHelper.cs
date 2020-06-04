using UnityEngine;

namespace Gameplay.Helpers
{
    // Tells whether or not an object is in camera field of view
    public static class GameAreaHelper
    {

        private static Camera _camera; //cached current camera

        private static readonly object CameraLock = new object(); //used for thread safety

        // Cashes and returns main camera (with thread-safety and double check)
        // Also reinits camera when the scene is reloaded
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

        // Says if an object with given position is in gameplay area including/not including
        // its boundaries based on the boundsInArea flag (by default object must be completely out to get false)
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
