#if UNITY_EDITOR
    using UnityEditor;
#endif

using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    private void Start()
    {
        #if UNITY_EDITOR
            gameObject.SetActive(EditorUserBuildSettings.activeBuildTarget==BuildTarget.Android);
        #else 
            gameObject.SetActive(Application.isMobilePlatform);
        #endif
    }

}
