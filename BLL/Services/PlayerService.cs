using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    

    public class PlayerService : ServiceBase, IService<Player, PlayerModel>
    {

        public PlayerService(Db db) : base(db)
        {
            
        }

        public ServiceBase Create(Player record)
        {
            if (_db.Players.Any(p => p.Name.ToLower() == record.Name.ToLower().Trim() && p.Surname.ToLower() == record.Surname.ToLower().Trim() && p.IsFemale == record.IsFemale && p.Birthdate == record.Birthdate))
                return Error("Player with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Players.Add(record);
            _db.SaveChanges();
            return Success("Player created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Players.SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return Error("Player cannot be found! ");
            _db.Payments.RemoveRange(entity.Payments);
            _db.Players.Remove(entity);
            _db.SaveChanges();
            return Success("Team deleted successfully. ");
        }

        public IQueryable<PlayerModel> Query()
        {
            return _db.Players.Include(p => p.Team).Include(p => p.Payments).ThenInclude(pa => pa.Matches).OrderByDescending(p => p.Birthdate).Select(p => new PlayerModel() { Record = p });
        }

        public ServiceBase Update(Player record)
        {   
            if (_db.Players.Any(p => p.Id != record.Id && p.Name.ToLower() == record.Name.ToLower().Trim() && 
            p.Surname.ToLower() == record.Surname.ToLower().Trim() && p.IsFemale == record.IsFemale && p.Birthdate == record.Birthdate))
                return Error("Player with the same name exists!");
            var entity = _db.Players.Include(p => p.Payments).SingleOrDefault(p => p.Id == record.Id);
            if (entity is null)
                return Error("Player is not found!");
            _db.Payments.RemoveRange(entity.Payments);
            entity.Name = record.Name?.Trim();
            entity.Surname = record.Surname?.Trim();
            entity.IsFemale = record.IsFemale;
            entity.Birthdate = record.Birthdate;
            entity.Payments = record.Payments;
            _db.Players.Update(entity);
            _db.SaveChanges();
            return Success("Player updated successfully. ");
        }
    }
}
