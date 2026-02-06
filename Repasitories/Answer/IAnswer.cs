namespace DevNet.Repasitories.Answer
{
    public interface IAnswer
    {
        public Task AddAnswer(Models.Answer model);
        public Task DeleteAnswer(int id);
        public Task<Models.Answer> GetAnswerById(int id);
    }
}
