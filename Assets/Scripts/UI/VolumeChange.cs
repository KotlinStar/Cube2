
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float _startVolumeGame;    
    [SerializeField] private Text _showVolumeText;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private BackGroundSound _backgroundSound;

    private void Awake()                 
    {
        if (!PlayerPrefs.HasKey("Volume"))      // ���� ��� ������ ����
        {
            _saveLoad.VolumeGame = _startVolumeGame;
        }
    }


    void Start()
    {
        volumeSlider.value = _saveLoad.VolumeGame;
        ShowVolumePercentage(volumeSlider.value);
    }

    public void ChangeVolumeSlider ()
    {
        float volume = CountingValues();

        _saveLoad.VolumeGame = volume; 
        ShowVolumePercentage(volume);
        _backgroundSound.LevelSound(volume);
    }

    private float CountingValues ()
    {
        return volumeSlider.value;
    }

    private void ShowVolumePercentage (float volume)
    {
        _showVolumeText.text = string.Format("���������: {0}%",(int)volume);
    }
}
