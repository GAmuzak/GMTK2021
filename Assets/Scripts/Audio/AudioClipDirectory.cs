using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu]
    public class AudioClipDirectory : ScriptableObject
    {
        public List<AudioClipDirectoryEntry> directory;

        public AudioClip FindClip(AudioTag tag)
        {
            foreach (AudioClipDirectoryEntry entry in directory)
            {
                if (!tag.Equals(entry.tag)) continue;
                if (entry.audioClip == null) throw new FileNotFoundException();
            
                return entry.audioClip;
            }

            throw new FileNotFoundException();
        }
    }
}