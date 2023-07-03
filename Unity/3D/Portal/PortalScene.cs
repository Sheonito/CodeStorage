using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Metalive
{
    public class PortalScene : MonoBehaviour
    {

        #region Variable

        [SerializeField]
        private Button sceneButton;
        [SerializeField]
        private PortalSceneType sceneType = PortalSceneType.None;
        [SerializeField]
        private string sceneName = "";

        #endregion



        #region

        private void Start()
        {
            if(sceneButton)
            {
                sceneButton.onClick.AddListener(() => { SceneUpdate(); });
            }            
        }

        private void OnDestroy()
        {
            if(sceneButton)
            {
                Destroy(sceneButton);
            }
        }

        #endregion


        #region Method

        public void SceneUpdate()
        {
            if(sceneType == PortalSceneType.Open)
            {
                if(string.IsNullOrEmpty(sceneName))
                {

#if UNITY_EDITOR
                    Debug.LogError("No write scene name");
#endif

                    return;
                }
                else
                {
                    Portal.Open(sceneName);
                }
            }
            else
            {
                if(string.IsNullOrEmpty(sceneName))
                {
#if UNITY_EDITOR
                    Debug.LogError("No write scene name");
#endif

                    return;
                }
                else
                {
                    Portal.Close(sceneName);
                }
            }
        }

#endregion

    }
}