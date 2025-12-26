using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace HiddenTest
{
    public class GameInstaller : MonoInstaller
    {
        public UIManager _uiManager;
        public LevelSettings _settings;

        public override void InstallBindings()
        {
            try
            {
                Debug.Log("InstallBindings: Container = " + (Container == null ? "NULL" : "ok"));

                if (_settings == null)
                    Debug.LogWarning("Settings reference not set in ScriptableObject!");
                Container.BindInstance<LevelSettings>(_settings).AsSingle();
                if (_uiManager == null)
                    Debug.LogWarning("UIManager reference not set in ScriptableObject!");
                Container.BindInstance<IUIManager>(_uiManager).AsSingle();

                Container.BindInterfacesTo<GameController>().AsSingle();

            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }
}
