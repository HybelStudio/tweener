using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel.Tweener
{
    public class TweenerMono : MonoBehaviour
    {
        #region Singleton
        
        private static TweenerMono s_instance;
        private static bool s_creatingFlag;

        public static TweenerMono Instance
        {
            get
            {
                if (s_instance == null)
                    CreateSingleton();

                return s_instance;
            }
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void CreateSingleton()
        {
            s_creatingFlag = true;
            var obj = new GameObject("Tweener Mono");
            var instance = obj.AddComponent<TweenerMono>();
            s_instance = instance;
        }

        private void HandleTweenerMonoDestroyed()
        {
            if (s_instance == this)
                s_instance = null;
        }

        #endregion // Singleton

        private static readonly List<CoroutineHandle> s_handles = new();
        
        private static TimeScaleHook s_defaultTimeScaleHook;
        internal static TimeScaleHook DefaultTimeScaleHook
        {
            get => s_defaultTimeScaleHook ??= () => Time.timeScale;
            set => s_defaultTimeScaleHook = value;
        }

        public static void RunCoroutine(IEnumerator coroutine) =>
            s_handles.Add(Instance.RunCoroutine(coroutine));

        private void Awake()
        {
            if (!s_creatingFlag && (s_instance == null || s_instance != this))
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(this);
            s_creatingFlag = false;
        }

        private void OnDestroy() => HandleTweenerMonoDestroyed();
    }
}
