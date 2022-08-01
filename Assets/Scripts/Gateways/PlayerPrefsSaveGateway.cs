using UnityEngine;

namespace Calculator
{
    public class PlayerPrefsSaveGateway : ISaveGateway
    {
        private const string KEY = "save_key";

        public void Save(CalculatorData data)
        {
            PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }

        public bool HasSave() => PlayerPrefs.HasKey(KEY);

        public CalculatorData Load() => JsonUtility.FromJson<CalculatorData>(PlayerPrefs.GetString(KEY));
    }
}