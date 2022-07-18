using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public interface IUserRepository
    {
        User GetAdmin(int Id);
      
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User userChanges);
        
        User Delete(int id);
        Feedback GetFeedback(int Id);
        Feedback Update(Feedback feedbackChanges);
        
    }
}
