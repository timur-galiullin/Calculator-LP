using System;
using UnityEngine;

namespace Calculator
{
    public class AndroidExtensions
    {
        private class Callback : AndroidJavaProxy
        {
            public Action<int> OnClick;

            public Callback() : base("com.galiullin.unityextentions.IAlertDialogCallback")
            {
            }

            public void Click(int whichButton)
            {
                OnClick?.Invoke(whichButton);
            }
        }

        public static void ShowAlertDialog(string desc, string positiveButtonName, string negativeButtonName, Action<int> onClickEvent)
        {
#if UNITY_ANDROID
            using (var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                Callback callback = new Callback();
                callback.OnClick = onClickEvent;
                AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.galiullin.unityextentions.AlertDialog");
                androidJavaClass.CallStatic("Show", activity, desc, positiveButtonName, negativeButtonName, callback);
            }
#endif
        }

        public static void ShowNotification(string title, string description)
        {
#if UNITY_ANDROID
            using (var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.galiullin.unityextentions.Notification");
                androidJavaClass.CallStatic("Show", activity, title, description);
            }
#endif
        }
    }
}