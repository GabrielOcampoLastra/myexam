using MyExam.Helpers;
using MyExam.Models;
using MyExam.Services.ApiService;
using Newtonsoft.Json;
using Plugin.SecureStorage;
using Realms;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyExam.Services.User
{
    public class UserService : IUserService
    {
        IRandomUserApi randomUserApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyExam.Services.User.UserService"/> class.
        /// </summary>
        public UserService()
        {
            randomUserApi = RestService.For<IRandomUserApi>(Constants.ApiUrl);
        }

        /// <summary>
        /// Gets the users from database.
        /// </summary>
        /// <returns>The users from database.</returns>
        public List<Models.User> GetUsersFromDatabase()
        {
            using (var realm = Realm.GetInstance())
            {
                var userList = realm.All<Models.User>().ToList().SeparateFromRealm();
                return userList;
            }
        }

        /// <summary>
        /// Gets the users from service.
        /// </summary>
        /// <returns>The users from service.</returns>
        /// <param name="users">Users.</param>
        public async Task<List<Models.User>> GetUsersFromService(int users)
        {
            var userList = new List<Models.User>();
            try
            {
                var response = await randomUserApi.GetUser(users);
                var content = await response.Content.ReadAsStringAsync();

                var randomUsers = new Response<RandomUsers>();
                randomUsers.Data = await Task.Run(() => JsonConvert.DeserializeObject<RandomUsers>(content));
                randomUsers.Data.Results.ForEach(x => x.Calification = Utils.GetCalification());
                await SaveUsers(randomUsers.Data.Results);

                userList = GetUsersFromDatabase();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return userList;
        }

        /// <summary>
        /// Saves the users.
        /// </summary>
        /// <returns>The users.</returns>
        /// <param name="userList">User list.</param>
        private async Task SaveUsers(List<Models.User> userList)
        {
            using (var realm = Realm.GetInstance())
            {
                using (var transaction = realm.BeginWrite())
                {
                    foreach (var user in userList)
                    {
                        user.Location.UserPosition = await Utils.GetUserPosition(user.Location);
                        realm.Add(user);
                    }
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Login the specified user.
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="user">User.</param>
        public async Task<Response<bool>> Login(Models.User user)
        {
            var response = new Response<bool>()
            {
                Success = false
            };

            await Task.Delay(2000);
            if(user.Password.Equals("pass1234"))
            {
                CrossSecureStorage.Current.SetValue("IsLogged", "True");
                response.Success = true;
            }
            else
            {
                response.Message = "Datos incorrectos";
            }
            return response;
        }

        /// <summary>
        /// Logout the user.
        /// </summary>
        /// <returns>The logout.</returns>
        public bool Logout()
        {
            try
            {
                CrossSecureStorage.Current.DeleteKey("IsLogged");
                Realm.DeleteRealm(new RealmConfiguration());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
