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

        public static bool IsInGameplayArea( Vector3 objectPos )
        {
            var zeroBounds = new Bounds( Vector3.zero, Vector3.zero );
            return IsInGameplayArea( objectPos, zeroBounds );
        }

        public static bool IsInGameplayArea(Vector3 objectPos, Bounds objectBounds)
        {
            var camHalfHeight = MainCamera.orthographicSize;
            var camHalfWidth = camHalfHeight * MainCamera.aspect;
            var camPos = MainCamera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }
        
    }
}
