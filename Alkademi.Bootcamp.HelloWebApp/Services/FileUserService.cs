using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public class FileUserService : IFileUserService
    {
        private const string FILE_NAME = "_datauser.txt";
        public async Task<List<UserViewModel>> Read()
        {
            if(!File.Exists(System.AppContext.BaseDirectory + FILE_NAME)){
                return new List<UserViewModel>();
            }
            var res = await File.ReadAllLinesAsync(System.AppContext.BaseDirectory + FILE_NAME);
            if(res == null)
                return new List<UserViewModel>();

            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var item in res)
            {
                var dataSplit = item.Split(":").ToArray();
                users.Add(new UserViewModel(int.Parse(dataSplit[0]), dataSplit[1], dataSplit[2]));
            }

            return users;
        }

        public async Task Write(UserViewModel request)
        {
            if(!File.Exists(System.AppContext.BaseDirectory + FILE_NAME)){
                using (var fileStream = File.Create(System.AppContext.BaseDirectory + FILE_NAME)){
                    fileStream.Close();
                }
            }
            using(var fileStream = File.AppendText(System.AppContext.BaseDirectory + FILE_NAME)){
                await fileStream.WriteLineAsync($"{request.Id}:{request.Username}:{request.Password}");
            }
        }
    }
}
