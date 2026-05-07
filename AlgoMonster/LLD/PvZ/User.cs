namespace AlgoMonster.LLD.PvZ
{
    public class User
    {
        public int UserId { get; set; }
        public CharacterType Character { get; set; }
        public int DifficultyLevel { get; set; }

        public void SetCharacter(CharacterType characterType)
        {
            this.Character = characterType;
        }

        public void SetDifficultyLevel(int  difficultyLevel)
        {
            this.DifficultyLevel = difficultyLevel;
        }
     }
}
