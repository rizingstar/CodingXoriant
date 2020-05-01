using System.Collections.Generic;

namespace CodingXoriant.Model
{
    public interface IPresidentsRepository
    {
        bool DoesItemExist(int id);
        IEnumerable<President> All { get; }
        President Find(int id);
        void Insert(President president);
        void Update(President president);
        void Delete(int id);
    }
}
