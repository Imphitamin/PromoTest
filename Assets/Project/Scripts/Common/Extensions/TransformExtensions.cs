using System.Collections;
using UnityEngine;

namespace PromoTest.Project.Common.Extensions
{
    public static class TransformExtensions
    {
        public static IEnumerator ScaleFromTo(
            this Transform transform,
            Vector3 startScale,
            Vector3 endScale,
            float totalDuration)
        {
            var startTime = Time.time;
            var currentLerpValue = 0.0f;
            var elapsedTime = 0.0f;
            var lerpValueMult = 1.0f / totalDuration;
            var cachedScale = Vector3.zero;

            while (elapsedTime < totalDuration)
            {
                cachedScale.x = Mathf.Lerp(startScale.x, endScale.x, currentLerpValue);
                cachedScale.y = Mathf.Lerp(startScale.y, endScale.y, currentLerpValue);
                cachedScale.z = Mathf.Lerp(startScale.z, endScale.z, currentLerpValue);
                transform.localScale = cachedScale;
                
                elapsedTime = Time.time - startTime;
                currentLerpValue = elapsedTime * lerpValueMult;
                
                yield return null;
            }

            if (currentLerpValue > 1)
            {
                transform.localScale = endScale;
            }
        }
    }
}