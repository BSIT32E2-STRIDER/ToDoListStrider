using ToDoListStrider.Domain;

namespace ToDoListStrider.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _inMemoryDatabase;

        public UserRepository()
        {
            
            _inMemoryDatabase = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Username = "user1",
                    Password = "password1"
                    
                },
                 new User
                {
                    UserId = 1,
                    Username = "hazel",
                    Password = "sagre"
                   
                },
                 new User
                {
                    UserId = 1,
                    Username = "paolo",
                    Password = "deleon"
                   
                },
                  new User
                {
                    UserId = 1,
                    Username = "kenjie",
                    Password = "baniqued"
                    
                },
                new User
                {
                    UserId = 2,
                    Username = "kevin",
                    Password = "francisco"
                    
                }
                
            };
        }


        public async Task<User> Authenticate(string username, string password)
        {
            // Find the user with the matching username and password
            return await Task.FromResult(_inMemoryDatabase.FirstOrDefault(u => u.Username == username && u.Password == password));
        }

        public async Task<User> Register(User user)
        {
            // Add the user to the in-memory database
            _inMemoryDatabase.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User> GetById(int id)
        {
            // Find the user with the matching ID
            return await Task.FromResult(_inMemoryDatabase.FirstOrDefault(u => u.UserId == id));
        }

        // Add the GetUserByUsername method
        public async Task<User> GetUserByUsername(string username)
        {
            // Find the user with the matching username
            return await Task.FromResult(_inMemoryDatabase.FirstOrDefault(u => u.Username == username));
        }
        public int GetMaxUserId()
        {
            return _inMemoryDatabase.Max(u => u.UserId);
        }
        public async Task Add(User user)
        {
            // Assign a unique ID to the new user
            user.UserId = _inMemoryDatabase.Count > 0 ? _inMemoryDatabase.Max(u => u.UserId) + 1 : 1;
            _inMemoryDatabase.Add(user);
            await Task.CompletedTask;
        }

    }
}
