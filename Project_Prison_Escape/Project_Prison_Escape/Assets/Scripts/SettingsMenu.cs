using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;
public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Dropdown difficultyDropdown;

    public AudioMixer audioMixer;
    public GameObject difficultyGameObject;

    private string dropDownText;

    public Slider musicSlider; 
    public Slider soundSlider; 
    public void Start(){

        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height}).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0;i<resolutions.Length;i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

        if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
            currentResolutionIndex = i; 
        }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true; 

        difficultyDropdown.options.Clear();
        List<string> items = new List<string>();
        items.Add("Easy");
        items.Add("Medium");
        items.Add("Hard");

        foreach(var item in items){
            difficultyDropdown.options.Add(new Dropdown.OptionData(){ text = item});
        }
        difficultyDropdown.onValueChanged.AddListener(delegate { DropdownItemSeleted(difficultyDropdown);});
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Music",volume);
    }
    public void SetSoundVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Sound",volume);
    }

    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void DropdownItemSeleted(Dropdown difficultyDropdown){
        int index = difficultyDropdown.value;
        dropDownText = difficultyDropdown.options[index].text;
        DifficultyScript difficultyOnScript = difficultyGameObject.GetComponent<DifficultyScript>();
        difficultyOnScript.setDifficulty(dropDownText);                
    }
}
