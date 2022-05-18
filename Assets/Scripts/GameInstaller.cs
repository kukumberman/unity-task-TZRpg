using UnityEngine;
using Zenject;
using Cucumba.SO;

namespace Cucumba
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CharacterItemsStorage m_CharactersStorage = null;

        private PlayerProfileModel m_PlayerProfile = null;

        public override void InstallBindings()
        {
            // should i call it here?
            LoadPlayerData();

            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CharacterChangedSignal>();

            Container
                .BindInstance(m_CharactersStorage)
                .AsSingle();

            Container
                .BindInstance(m_PlayerProfile)
                .AsSingle();

            // SimpleCharacterRandomizer or YetAnotherCharacterRandomizer
            Container
                .BindInterfacesAndSelfTo<SimpleCharacterRandomizer>()
                .AsSingle();
        }

        private void LoadPlayerData()
        {
            // save system is not mentioned in the task
            // lets say data is stored in json and being deserialized to regular class

            m_PlayerProfile = new PlayerProfileModel();

            if (!m_CharactersStorage.Includes(m_PlayerProfile.SelectedCharacterId))
            {
                m_PlayerProfile.SelectedCharacterId = m_CharactersStorage.Items[0].Id;
            }
        }
    }
}
