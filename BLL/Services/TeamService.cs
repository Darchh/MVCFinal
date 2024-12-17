using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{

    }
    public class TeamService : ServiceBase, IService<Team, TeamModel>
    {
        public TeamService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Team record)
        {
            if (_db.Teams.Any(t => t.Name.ToUpper() == record.Name.ToUpper().Trim() && t.Points == record.Points && t.IsFull == record.IsFull))
                return Error("Team with the same name exists!");
            record.Name = record.Name.Trim();
            _db.Teams.Add(record);
            _db.SaveChanges();
            return Success("Team created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Teams.Include(t => t.Players).SingleOrDefault(t => t.Id == id);
            if (entity is null)
                return Error("Team cannot be found! ");
            if (entity.Players.Any())
                return Error("Team has players. You cannot delete it. ");
            _db.Teams.Remove(entity);
            _db.SaveChanges();
            return Success("Team deleted successfully. ");
        }

        public IQueryable<TeamModel> Query()
        {
            return _db.Teams.OrderBy(t => t.Name).Select(t => new TeamModel() { Record = t });
        }

        public ServiceBase Update(Team record)
        {
            if (_db.Teams.Any(t => t.Name.ToUpper() == record.Name.ToUpper().Trim() && t.Points == record.Points && t.IsFull == record.IsFull))
            return Error("Team with the same name exists!");
            var entity = _db.Teams.SingleOrDefault(t => t.Id == record.Id);
             if (entity is null)
                 return Error("Team is not found!");
            entity.Name = record.Name?.Trim();
            entity.Points = record.Points;
            entity.IsFull = record.IsFull;
            _db.Teams.Update(entity);
            _db.SaveChanges();
            return Success("Team updated successfully. ");
        }
    }

