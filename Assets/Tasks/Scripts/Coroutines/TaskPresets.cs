using System;
using System.Collections;
using UnityEngine;

namespace Tasks.CoroutineExtension.Presets
{
    public static class TaskPresets
    {
        /// <summary>
        /// Wait until the end of the current frame
        /// </summary>
        /// <param name="callback">Method to be called after coroutine has finished</param>
        /// <returns></returns>
        public static IEnumerator delayEndOfFrame(Action callback = null)
        {
            yield return new WaitForEndOfFrame();

            if (callback != null)
            {
                callback();
            }
        }

        /// <summary>
        /// Wait until the new frame
        /// </summary>
        /// <param name="callback">Method to be called after coroutine has finished</param>
        /// <returns></returns>
        public static IEnumerator delayStartOfNewFrame(Action callback = null)
        {
            yield return null;

            if (callback != null)
            {
                callback();
            }
        }

        /// <summary>
        /// Wait for N frames
        /// </summary>
        /// <param name="frames">Wait for this amount of frames</param>
        /// <param name="callback">Method to be called after coroutine has finished</param>
        /// <returns></returns>
        public static IEnumerator delayForNFrames(int frames, Action callback = null)
        {
            int n = 0;

            while(n < frames)
            {
                yield return null;
                n++;
            }

            if(callback != null)
            {
                callback();
            }
        }

        /// <summary>
        /// Wait for seconds
        /// </summary>
        /// <param name="callback">Method to be called after coroutine has finished</param>
        /// <returns></returns>
        public static IEnumerator waitForSeconds(float seconds, Action callback = null)
        {
            yield return new WaitForSeconds(seconds);

            if (callback != null)
            {
                callback();
            }
        }
    }
}