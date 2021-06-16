using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClipDirectory audioClipDirectory;

        [Header("Audio Channels")]
        [SerializeField] private AudioSource musicSource = null;
        [SerializeField] private AudioSource sfxSource = null;

        private AudioTag currentMusicTag=AudioTag.NULL;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            MainMenu.PlayMenuMusic += MenuMusic;
            MainMenu.PlayGameMusic += GameMusic;
            PlayerController.MoveSfx += MoveSfx;
            PlayerController.JumpSfx += JumpSfx;
        }
        
        private void OnDisable()
        {
            MainMenu.PlayMenuMusic -= MenuMusic;
            MainMenu.PlayGameMusic -= GameMusic;
            PlayerController.MoveSfx -= MoveSfx;
            PlayerController.JumpSfx -= JumpSfx;
        }

        private void PlayMusicClip(AudioTag audioTag)
        {
            if (audioTag.Equals(currentMusicTag) && musicSource.isPlaying) return;

            musicSource.clip = audioClipDirectory.FindClip(audioTag);
            musicSource.Play();
        }

        private void PlaySfxClip(AudioTag audioTag)
        {
            if (audioTag.Equals(currentMusicTag) && musicSource.isPlaying) return;

            sfxSource.clip = audioClipDirectory.FindClip(audioTag);
            sfxSource.Play();
        }

        #region Callbacks

        private void MenuMusic()
        {
            PlayMusicClip(AudioTag.MenuMusic);
        }

        private void GameMusic()
        {
            PlayMusicClip(AudioTag.GameMusic);
        }

        private void MoveSfx()
        {
            // PlaySfxClip(AudioTag.MoveSfx);
        }

        private void JumpSfx()
        {
            // PlaySfxClip(AudioTag.JumpSfx);
        }

        #endregion
    }
}