using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections;

public class NetworkController : MonoBehaviourPunCallbacks
{

    [Header("LOGIN")]
    public GameObject loginPn;
    public InputField playerNameInput;
    string tempPlayerName;

    [Header("LOBBY")]
    public GameObject lobbyPn;
    public InputField roomNameInput;
    string tempRoomName;

    [Header("PLAYER")]
    public GameObject playerPUN;

    [Header("UI")]
    public GameObject canvasTelaInicial;
    public Text mensagem;
    public GameObject menu;
    public GameObject modoonline;
    public GameObject canvasLobby;
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {   
        loginPn.transform.localPosition = new Vector2(0, 500);
        lobbyPn.transform.localPosition = new Vector2(0, 500);
        
        tempPlayerName = "User" + Random.Range(1, 20);
        playerNameInput.text = tempPlayerName;

        tempRoomName = "Sala" + Random.Range(1, 5);
    }
    //######## Minhas Funções ##################
    public void Login()
    {
        PhotonNetwork.ConnectUsingSettings();

        if (playerNameInput.text != "")
        {
            PhotonNetwork.NickName = playerNameInput.text;
        }
        else
        {
            PhotonNetwork.NickName = tempPlayerName;
        }

        loginPn.transform.LeanMoveLocalY(-500, 1f);
        lobbyPn.transform.LeanMoveLocalY(0, 1f);

        roomNameInput.text = tempRoomName;
    }

    public void QuickSearch()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOptions, TypedLobby.Default);
    }
    public void ExibePlayerEnter(string msg)
    {
        mensagem.gameObject.SetActive(true);
        mensagem.text = msg;
        StartCoroutine(WaitForHide(2f));
    }
    public void ExibePlayerExit(string msg)
    {
        mensagem.gameObject.SetActive(true);
        mensagem.text = msg;
        StartCoroutine(WaitForHide(2f));
    }

    IEnumerator WaitForHide(float time)
    {
        yield return new WaitForSeconds(time);
        mensagem.gameObject.SetActive(false);
    }

    //############# PUN Callbacks ##################
    public override void OnConnected()
    {
        Debug.LogWarning("############# LOGIN #############");
        Debug.LogWarning("OnConnected");
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogWarning("OnConnectedToMaster");
        Debug.LogWarning("Server: " + PhotonNetwork.CloudRegion);
        Debug.LogWarning("Ping: " + PhotonNetwork.GetPing());
    }

    public override void OnJoinedLobby()
    {
        Debug.LogWarning("############# LOOBY #############");
        Debug.LogWarning("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(tempRoomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogWarning("OnJoinedRoom");
        Debug.LogWarning("Nome da Sala: " + PhotonNetwork.CurrentRoom.Name);
        Debug.LogWarning("Nome da Player: " + PhotonNetwork.NickName);
        Debug.LogWarning("Players Conectados: " + PhotonNetwork.CurrentRoom.PlayerCount);

        lobbyPn.transform.localPosition = new Vector2(0, 500);
        canvasTelaInicial.SetActive(false);
        
        menu.SetActive(true);
        modoonline.SetActive(true);
        canvasLobby.SetActive(true);

        Vector3 pos = new Vector3(Random.Range(-20, 20), playerPUN.transform.position.y, Random.Range(-20, 20));
        PhotonNetwork.Instantiate(playerPUN.name, pos, playerPUN.transform.rotation, 0);

        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("ChuvaDeCaixa");
        }
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        ExibePlayerEnter(other.NickName + " Entrou na sala");
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        ExibePlayerExit(other.NickName + " Saiu da sala");
    }

    public void ClicouSelecionar()
    {
        loginPn.transform.LeanMoveLocalY(0, 1f);
    }
    public void ClicouVoltar()
    {
        loginPn.transform.localPosition = new Vector2(0, 500);
        lobbyPn.transform.localPosition = new Vector2(0, 500);
        PhotonNetwork.Disconnect();
    }

}
