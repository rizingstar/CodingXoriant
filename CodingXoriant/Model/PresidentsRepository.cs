using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CodingXoriant.Model
{
    public class PresidentsRepository : IPresidentsRepository
    {
        private PresidentContext _presidentContext;

        public PresidentsRepository(PresidentContext presidentContext)
        {
            _presidentContext = presidentContext;
            if (_presidentContext.Presidents.Count()== 0)
                InitializeData();
        }

        public IEnumerable<President> All
        {
            get { return _presidentContext.Presidents; }
        }

        public bool DoesItemExist(int id)
        {
            return _presidentContext.Presidents.Any(x => x.Id == id);
        }

        public President Find(int id)
        {
            return _presidentContext.Presidents.Find(id);
        }

        public void Insert(President president)
        {
            _presidentContext.Add(president);
            _presidentContext.SaveChanges();
        }

        public void Update(President president)
        {
            _presidentContext.Update(president);
            _presidentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _presidentContext.Remove(Find(id));
            _presidentContext.SaveChanges();
        }

        private void InitializeData()
        {
            _presidentContext.Presidents.RemoveRange(_presidentContext.Presidents);
            using (StreamReader r = new StreamReader(@"/Users/nomankhan/Projects/CodingXoriant/CodingXoriant/Data/Presidents.json"))
            {
                string json = r.ReadToEnd();
                _presidentContext.Presidents.AddRange(JsonConvert.DeserializeObject<List<President>>(json));
                _presidentContext.SaveChanges();
            }
        }
    }
}
