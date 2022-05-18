using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Cucumba.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private Button m_Button = null;

        [SerializeField] private int m_SceneIndex = 0;

        private ZenjectSceneLoader m_SceneLoader = null;

        [Inject]
        private void Construct(ZenjectSceneLoader loader)
        {
            m_SceneLoader = loader;

            m_Button.onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            m_SceneLoader.LoadScene(m_SceneIndex);
        }
    }
}

