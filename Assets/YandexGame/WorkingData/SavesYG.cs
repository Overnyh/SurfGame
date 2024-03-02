
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;


        public bool[] OpenKnifes = new bool[20];
        public int TackenKnifeId = 0;
        public int Sensitivity = 100;
        public bool AutoHope = true;
        public int movement = 0;
        public int KnifesCount = 9;
        public bool freeKnife = false;
        public int freeKnifeTime = 900;
        public SavesYG()
        {
            OpenKnifes[0] = true;
        }
    }
}
