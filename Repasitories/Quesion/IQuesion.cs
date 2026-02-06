namespace DevNet.Repasitories.Quesion
{
    public interface IQuesion
    {
        public Task AddQuesion(Models.Quesion model);
        public Task DeleteQuesion(int id);
        public Task<List<Models.Quesion>> GetAllQuesions();
        public Task<Models.Quesion> GetQuesionById(int id);
        public Task Edit(Models.Quesion model);
    }
}
