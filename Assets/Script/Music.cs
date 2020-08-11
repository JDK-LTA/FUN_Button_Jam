using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] highNotes, lowNotes;
    int notesPerChord;
    AudioClip lowNotePlayed;
    AudioSource a;
    int[] cChord = new int[] {0, 1, 2, 4, 7};
    int[] dChord = new int[] { 0, 1, 3, 5, 6 };
    int[] fChord = new int[] { 0, 3, 5, 7, 5 };
    int[] gChord = new int[] { 1, 2, 3, 4, 6 };
    int[] aChord = new int[] { 0, 2, 4, 5, 7 };
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        GameManager.Instance.OnWorldChanging += PlayNote;
        notesPerChord = 4;
    }

    void PlayNote()
    {
        if(notesPerChord >= 4)
        {
            lowNotePlayed = lowNotes[Random.Range(0, lowNotes.Length)];
            a.PlayOneShot(lowNotePlayed);
            notesPerChord = 0;
        }
        else
        {
            notesPerChord++;
        }
        if(lowNotePlayed == lowNotes[0])
        {
            a.PlayOneShot(highNotes[cChord[Random.Range(0, cChord.Length)]]);
        }
        else if (lowNotePlayed == lowNotes[1])
        {
            a.PlayOneShot(highNotes[dChord[Random.Range(0, dChord.Length)]]);
        }
        else if (lowNotePlayed == lowNotes[2])
        {
            a.PlayOneShot(highNotes[fChord[Random.Range(0, fChord.Length)]]);
        }
        else if (lowNotePlayed == lowNotes[3])
        {
            a.PlayOneShot(highNotes[aChord[Random.Range(0, aChord.Length)]]);
        }else if (lowNotePlayed == lowNotes[4])
        {
            a.PlayOneShot(highNotes[gChord[Random.Range(0, gChord.Length)]]);
        }



    }


}
