using System;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

namespace Game.CameraNS.Utils
{
    public static class CameraUtils
    {
        public static void FitFovToBounds(this CinemachineCamera cineCamera, Camera camera, Bounds bounds)
        {
            float2 maxFitFovScaleFactor = float2.zero;
            foreach (Vector3 corner in bounds.EnumerateCorners())
            {
                float2 fitFovScaleFactor = camera.FitFovScaleFactorForPoint(corner);
                maxFitFovScaleFactor = math.max(maxFitFovScaleFactor, fitFovScaleFactor);
            }

            float finalFovScaleFactor = math.max(maxFitFovScaleFactor.x, maxFitFovScaleFactor.y);
            if (finalFovScaleFactor > 0 && !Mathf.Approximately(finalFovScaleFactor, 1))
            {
                if (camera.orthographic)
                {
                    cineCamera.Lens.OrthographicSize *= finalFovScaleFactor;
                }
                else
                {
                    cineCamera.Lens.FieldOfView *= finalFovScaleFactor;
                }
            }
        }

        private static float2 FitFovScaleFactorForPoint(this Camera camera, Vector3 worldPoint)
        {
            float3 viewportPoint = camera.WorldToViewportPoint(worldPoint);
            if (viewportPoint.z >= camera.nearClipPlane && viewportPoint.z <= camera.farClipPlane)
            {
                return math.abs(viewportPoint.xy - 0.5f) * 2;
            }
            else
            {
                return float2.zero;
            }
        }
    }
}