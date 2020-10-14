using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace GamePlay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private GameObjectVariable player;
        private string currentScene;
        private bool canLoad = true;

        void Start()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            currentScene = SceneManager.GetSceneByBuildIndex(1).name;
            Debug.Log(currentScene);
        }

        public void Win()=> SceneManager.LoadScene("ManagersScene");

        public void Loose()
        { 
            if (canLoad)
            {
                canLoad = false;
                Destroy(player.Value);
                if (Application.platform == RuntimePlatform.Android)
                {
                    SceneManager.UnloadSceneAsync("Lvl_0 Mobile");
                    SceneManager.LoadScene("Lvl_0 Mobile", LoadSceneMode.Additive);

                }
                else
                {
                    SceneManager.UnloadSceneAsync("Lvl_0 f00KED Le Dernier Quash");
                    SceneManager.LoadScene("Lvl_0 f00KED Le Dernier Quash", LoadSceneMode.Additive);
                }
                
                StartCoroutine(WaitCanLoad());
            }
           
        }

        IEnumerator WaitCanLoad()
        {
            yield return new WaitForSeconds(1);
            canLoad = true;
        }
        

        public void LoadSceneAdditive(StringVariable scene)
        {
            
            SceneManager.LoadScene(scene.Value,LoadSceneMode.Additive);
            currentScene = scene.Value;
        }

        public void LoadSceneAdditiveNetworkToOthers(StringVariable scene)
        {
            photonView.RPC("LoadSceneAdditiveNetwork", RpcTarget.Others, scene.Value);
        }
        public void LoadSceneAdditiveNetworkToAll(StringVariable scene)
        {
            photonView.RPC("LoadSceneAdditiveNetwork", RpcTarget.AllBufferedViaServer, scene.Value);
        }

        [PunRPC]
        private void LoadSceneAdditiveNetwork(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            currentScene = currentScene = scene;
        }

        public void UnloadCurrentScene()
        {
            SceneManager.UnloadScene(currentScene);
            Debug.Log(currentScene);
        }
        
        public void UnloadCurrentSceneToAll()
        {
            photonView.RPC("UnloadCurrentScenePun", RpcTarget.All);
        }

        [PunRPC]
        void UnloadCurrentScenePun()
        {
            SceneManager.UnloadScene(currentScene);
        }
    }
}

