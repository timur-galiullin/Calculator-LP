using UnityEngine;

namespace Calculator
{
    public class SaveService
    {
        private const string KEY = "save_key";

        public void Save(SaveData data)
        {
            PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }

        public bool HasSave() => PlayerPrefs.HasKey(KEY);

        public SaveData Load() => JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(KEY));
    }
}