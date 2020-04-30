using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CodingXoriant.Model
{
    public class PresidentsRepository : IPresidentsRepository
    {
        private List<President> _presidentsList;

        public PresidentsRepository()
        {
            InitializeData();
        }

        public IEnumerable<President> All
        {
            get { return _presidentsList; }
        }

        public bool DoesItemExist(string name)
        {
            return _presidentsList.Any(item => item.PresidentName == name);
        }

        public President Find(string name)
        {
            return _presidentsList.FirstOrDefault(item => item.PresidentName == name);
        }

        public void Insert(President president)
        {
            _presidentsList.Add(president);
        }

        public void Update(President president)
        {
            var presidentLocal = Find(president.PresidentName);
            var index = _presidentsList.IndexOf(presidentLocal);
            _presidentsList.RemoveAt(index);
            _presidentsList.Insert(index, president);
        }

        public void Delete(string id)
        {
            _presidentsList.Remove(Find(id));
        }

        private void InitializeData()
        {
            _presidentsList = new List<President>();

            using (StreamReader r = new StreamReader(@"/Users/nomankhan/Projects/CodingXoriant/CodingXoriant/Data/Presidents.json"))
            {
                string json = r.ReadToEnd();
                _presidentsList = JsonConvert.DeserializeObject<List<President>>(json);
            }
        }
    }
}
