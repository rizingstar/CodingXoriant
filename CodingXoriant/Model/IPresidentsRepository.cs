using System.Collections.Generic;

namespace CodingXoriant.Model
{
    public interface IPresidentsRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<President> All { get; }
        President Find(string id);
        void Insert(President president);
        void Update(President president);
        void Delete(string id);
    }
}
