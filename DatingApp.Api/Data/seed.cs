using System.Collections.Generic;
using System.IO;
using MyDatingapp.Api.Model;
using Newtonsoft.Json;

namespace DatingApp.Api.Data
{
    public class seed
    {
        private DatingAppContext _Context { get; }
        public seed(DatingAppContext context)
        {
            _Context = context;
        }

        public void SeedAlldata()
        {
            using (StreamReader r = new StreamReader("Data/userdata.json"))
            {
                string json = r.ReadToEnd();
                List<Tuser> items = JsonConvert.DeserializeObject<List<Tuser>>(json);

                foreach (var user in items)
                {
                    _Context.Tuser.Add(user);
                }
                _Context.SaveChanges();
            }
        }
    }
}