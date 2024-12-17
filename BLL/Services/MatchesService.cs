using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class MatchesService : ServiceBase, IService<Matches, MatchesModel>
    {
        public MatchesService(Db db) : base(db)
        {

        }

        public ServiceBase Create(Matches record)
        {
            if (_db.Matches.Any(m => m.Date == record.Date))
                return Error("There's an another match at that date!");
            record.Name = record.Name?.Trim();
            _db.Matches.Add(record);
            _db.SaveChanges();
            return Success("Match created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Matches.SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return Error("Match cannot be found! ");
            _db.Matches.Remove(entity);
            _db.SaveChanges();
            return Success("Match deleted successfully. ");
        }

        public IQueryable<Models.MatchesModel> Query()
        {
            return _db.Matches.OrderBy(m => m.Date).Select(m => new Models.MatchesModel() { Record = m });
        }

        public ServiceBase Update(Matches record)
        {
            if (_db.Matches.Any(m => m.Date == record.Date))
                return Error("There's an another match at that date!");
            var entity = _db.Matches.SingleOrDefault(m => m.Id == record.Id);
            if (entity is null)
                return Error("Match is not found!");
            entity.Name = record.Name?.Trim();
            entity.Date = record.Date;
            entity.IsCompleted = record.IsCompleted;
            _db.Matches.Update(entity);
            _db.SaveChanges();
            return Success("Match updated successfully. ");
        }

    }
}