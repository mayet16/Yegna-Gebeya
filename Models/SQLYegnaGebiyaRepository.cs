using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class SQLYegnaGebiyaRepository : IUserRepository
    {
        public SQLYegnaGebiyaRepository(GebiyaContext context)
        {
            Context = context;
        }

        public GebiyaContext Context { get; }
        public User Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = Context.Users.Find(id);
            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
            return user;
        }

        public User GetAdmin(int Id)
        {
            return Context.Users.Find(Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users;
        }

        public User Update(User userChanges)
        {
            var user = Context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return userChanges;
        }

        public Feedback GetFeedback(int Id)
        {
            return Context.Feedbacks.Find(Id);
        }

        public Feedback Update(Feedback feedbackChanges)
        {
            var feedback = Context.Feedbacks.Attach(feedbackChanges);
            feedback.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return feedbackChanges;
        }
    }
}
