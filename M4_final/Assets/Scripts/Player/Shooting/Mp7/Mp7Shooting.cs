using UnityEngine;
using TMPro;

public class Mp7Shooting : MonoBehaviour
{
    public int MagAmmo;
    public int AmmoInInventory; 

    public Bullet BulletPrefab;

    public TextMeshProUGUI AmmoLeftInventory;
    public TextMeshProUGUI AmmoLeftInMagText;

    private float _shootinTimer = 10;
    private float _fullReloadTimer = 10;

    [SerializeField] AudioSource Mp7Audio;
    [SerializeField] AudioSource Mp7Audio1;
    [SerializeField] AudioSource Mp7Audio2;
    [SerializeField] AudioSource Mp7Audio3;
    [SerializeField] AudioSource Mp7Reload;

    float _timeForAudio;
    private void Start()
    {
        AmmoInInventory = PlayerPrefs.GetInt("Mp7Ammo");
        MagAmmo = PlayerPrefs.GetInt("Mp7");
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Timers();
            Shooting();
            Reload();
        }
        AmmoLeftInventory.text = AmmoInInventory.ToString();
        AmmoLeftInMagText.text = MagAmmo.ToString();
        if (AmmoInInventory <= 0)
        {
            AmmoInInventory = 0;
            AmmoLeftInventory.color = Color.red;
            AmmoLeftInventory.text = "0";
        }
        else
        {
            AmmoLeftInventory.color = Color.cyan;
        }
    }

    private void Reload()
    {
        if (MagAmmo < 1 && AmmoInInventory > 0 || Input.GetKeyDown(KeyCode.R) && AmmoInInventory > 0)
        {
            int MagLeftAmmo = 45 - MagAmmo;
            MagAmmo = 45;
            _fullReloadTimer = 0;
            AmmoInInventory -= MagLeftAmmo;
            if (AmmoInInventory < 0)
                MagAmmo += AmmoInInventory;
            AmmoLeftInMagText.text = MagAmmo.ToString();
            AmmoLeftInventory.text = AmmoInInventory.ToString();
            Mp7Reload.Play();
            if (AmmoInInventory <= 0)
            {
                AmmoLeftInventory.text = "0";
                AmmoLeftInventory.color = Color.red;
                AmmoInInventory = 0;
            }
            else
            {
                AmmoLeftInventory.color = Color.cyan;
            }
        }
    }
    private void Timers()
    {
        _shootinTimer += Time.deltaTime;
        _fullReloadTimer += Time.deltaTime;
        _timeForAudio += Time.deltaTime;
    }
    private void Shooting()
    {
        if (Input.GetMouseButton(0) && _shootinTimer > 0.07f && MagAmmo > 0 && _fullReloadTimer > 1.3f)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _shootinTimer = 0;
            MagAmmo--;
            AmmoLeftInMagText.text = MagAmmo.ToString();
            if (_timeForAudio < 0.07f)
                Mp7Audio.Play();
            else if (0.07f <= _timeForAudio && _timeForAudio < 0.14f)
                Mp7Audio1.Play();
            else if (0.14f <= _timeForAudio && _timeForAudio < 0.21f)
                Mp7Audio2.Play();
            else if (0.21f <= _timeForAudio)
            {
                Mp7Audio3.Play();
                _timeForAudio = 0;
            }
        }
        if (MagAmmo < 10)
        {
            AmmoLeftInMagText.color = Color.red;
        }
        else
        {
            AmmoLeftInMagText.color = Color.cyan;
        }
    }


    public void PickUpAmmoMp7(int Ammo)
    {
        AmmoInInventory += Ammo;
        if (AmmoInInventory > 180)
            AmmoInInventory = 180;
    }
}
