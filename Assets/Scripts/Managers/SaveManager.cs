using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    #region singleton
    public static SaveManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        //else if (instance != this)
        //    Destroy(gameObject);
    }
    #endregion singleton

    private PlayerCharacter player;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject optionsMenu;

    private void Start()
    {
        player = PlayerCharacter.instance;
        optionsMenu.GetComponent<SavePrefsOnDisable>().LoadVol();
    }

    public void Save()
    {
        int health = player.Health.hp;
        int armor = player.armor.armor;
        Vector3 playerPosition = player.Transform.position;
        int currPistolAmmo = player.WeaponDictonary[0].currAmmo;
        bool currPistolUnlocked = player.WeaponDictonary[0].unlocked; ;
        int currPlasmaAmmo = player.WeaponDictonary[1].currAmmo;
        bool currPlasmaUnlocked = player.WeaponDictonary[1].unlocked;
        int currShotgunAmmo = player.WeaponDictonary[2].currAmmo;
        bool currShotgunUnlocked = player.WeaponDictonary[2].unlocked;
        int currRocketAmmo = player.WeaponDictonary[3].currAmmo;
        bool currRocketUnlocked = player.WeaponDictonary[3].unlocked;
        int currBBAmmo = player.WeaponDictonary[4].currAmmo;
        bool currBBUnlocked = player.WeaponDictonary[4].unlocked;
        string sceneName = SceneManagement.instance.currentSceneName;
        int checkpointNum = CheckpointsSystem.instance.IndexActivator;


        SaveObject saveObject = new SaveObject
        {
            health = health,
            armor = armor,
            playerPosition = playerPosition,
            currPistolAmmo = currPistolAmmo,
            currPistolUnlocked = currPistolUnlocked,
            currPlasmaAmmo = currPlasmaAmmo,
            currPlasmaUnlocked = currPlasmaUnlocked,
            currShotgunAmmo = currShotgunAmmo,
            currShotgunUnlocked = currShotgunUnlocked,
            currRocketAmmo = currRocketAmmo,
            currRocketUnlocked = currRocketUnlocked,
            currBBAmmo = currBBAmmo,
            currBBUnlocked = currBBUnlocked,
            sceneName = sceneName,
            checkpointNum = checkpointNum
        };
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            player.Health.hp = saveObject.health;
            player.armor.armor = saveObject.armor;

            player.gameObject.transform.position = saveObject.playerPosition;

            player.Health.SetHealthBar(saveObject.health);
            player.armor.SetArmorBar(saveObject.armor);

            player.WeaponDictonary[0].currAmmo = saveObject.currPistolAmmo;
            player.WeaponDictonary[0].unlocked = saveObject.currPistolUnlocked;
            player.WeaponDictonary[1].currAmmo = saveObject.currPlasmaAmmo;
            player.WeaponDictonary[1].unlocked = saveObject.currPlasmaUnlocked;
            player.WeaponDictonary[2].currAmmo = saveObject.currShotgunAmmo;
            player.WeaponDictonary[2].unlocked = saveObject.currShotgunUnlocked;
            player.WeaponDictonary[3].currAmmo = saveObject.currRocketAmmo;
            player.WeaponDictonary[3].unlocked = saveObject.currRocketUnlocked;
            player.WeaponDictonary[4].currAmmo = saveObject.currBBAmmo;
            player.WeaponDictonary[4].unlocked = saveObject.currBBUnlocked;

            SceneManagement.instance.loadNextScene(saveObject.sceneName);

            SceneManagement.instance.checkPoint = saveObject.checkpointNum;
        }
    }

    public void SaveSettings()
    {

        Resolution resolution = Screen.currentResolution;
        bool fullscreen = Screen.fullScreen;
        float sensitivity = PlayerCharacter.mouseSensitivity;


        SettingSave settingSave = new SettingSave
        {
            resolutionWidth = resolution.width,
            resolutionHeight = resolution.height,
            resolutionRefresh= resolution.refreshRate,
            fullscreen = fullscreen,
            sensitivity = sensitivity
        };
        string json = JsonUtility.ToJson(settingSave);
        File.WriteAllText(Application.dataPath + "/savesettings.txt", json);
    }

    public void LoadSettings()
    {
        if(File.Exists(Application.dataPath + "/savesettings.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/savesettings.txt");
            SettingSave settingSave = JsonUtility.FromJson<SettingSave>(saveString);

            Screen.SetResolution(settingSave.resolutionWidth, settingSave.resolutionHeight, settingSave.fullscreen, settingSave.resolutionRefresh);
            Screen.fullScreen = settingSave.fullscreen;
            PlayerCharacter.mouseSensitivity = settingSave.sensitivity;
        }
    }

    public void SaveVolume(string exposedParam, float val)
    {
        VolumeSave volumeSave = new VolumeSave
        {
            exposedParam = exposedParam,
            val = val
        };
        string json = JsonUtility.ToJson(volumeSave);
        File.WriteAllText(Application.dataPath + "/"+ exposedParam + ".txt", json);
    }

    public void LoadVolume(string exposedParam, Slider slider)
    {
        if(File.Exists(Application.dataPath + "/" + exposedParam + ".txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath +"/"+ exposedParam + ".txt");
            VolumeSave volumeSave = JsonUtility.FromJson<VolumeSave>(saveString);

            exposedParam = volumeSave.exposedParam;
            mixer.SetFloat(exposedParam, volumeSave.val);
            slider.value = volumeSave.val;

        }

    }

    private class SaveObject
    {
        public int health;
        public int armor;
        public Vector3 playerPosition;
        public int currPistolAmmo;
        public bool currPistolUnlocked;
        public int currPlasmaAmmo;
        public bool currPlasmaUnlocked;
        public int currShotgunAmmo;
        public bool currShotgunUnlocked;
        public int currRocketAmmo;
        public bool currRocketUnlocked;
        public int currBBAmmo;
        public bool currBBUnlocked;
        public string sceneName;
        public int checkpointNum;
    }

    private class SettingSave
    {
        public bool fullscreen;
        public int resolutionWidth;
        public int resolutionHeight;
        public int resolutionRefresh;
        public float sensitivity;
    }

    private class VolumeSave
    {
        public string exposedParam;
        public float val;
    }

}
