using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumCover : MonoBehaviour
{
    public SongInfo songInfo;
    Image image;
    public Sprite aka;
    public Sprite woodsImage;
    public Sprite stormsImage;
    GameObject title, album, artist;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        title = GameObject.Find("Canvas/album/Title");
        album = GameObject.Find("Canvas/album/Album");
        artist = GameObject.Find("Canvas/album/Artist");
    }

    public void akaImage()
    {
        image.sprite = aka;
        title.GetComponent<UnityEngine.UI.Text>().text = "Atsuku Nare";
        album.GetComponent<UnityEngine.UI.Text>().text = "ZOMBIE LAND SAGA SAGA.1 SP";
        artist.GetComponent<UnityEngine.UI.Text>().text = "Franchouchou (フランシュシュ)";
        setActive();
    }

    public void lostWoods()
    {
        image.sprite = woodsImage;
        title.GetComponent<UnityEngine.UI.Text>().text = "Lost Woods";
        album.GetComponent<UnityEngine.UI.Text>().text = "Legend of Zelda";
        artist.GetComponent<UnityEngine.UI.Text>().text = "Ocarina of Time";
        setActive();
    }

    public void songOfStorms()
    {
        image.sprite = stormsImage;
        title.GetComponent<UnityEngine.UI.Text>().text = "Song of Storms";
        album.GetComponent<UnityEngine.UI.Text>().text = "Legend of Zelda";
        artist.GetComponent<UnityEngine.UI.Text>().text = "BlueSCD";
        setActive();
    }

    public void slowedDown()
    {
        image.sprite = woodsImage;
        title.GetComponent<UnityEngine.UI.Text>().text = "Lost Woods - Slowed";
        album.GetComponent<UnityEngine.UI.Text>().text = "Legend of Zelda";
        artist.GetComponent<UnityEngine.UI.Text>().text = "Ocarina of Time";
        setActive();
    }

    public void setActive()
    {
        image.enabled = true;
        title.gameObject.SetActive(true);
        album.gameObject.SetActive(true);
        artist.gameObject.SetActive(true);
    }

    public void mouseOff()
    {
        image.sprite = null;
        image.enabled = false;
        title.gameObject.SetActive(false);
        album.gameObject.SetActive(false);
        artist.gameObject.SetActive(false);
    }
}
