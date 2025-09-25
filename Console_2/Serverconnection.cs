using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Console_2
{
    internal class Serverconnection
    {
        HttpClient client = new HttpClient();
        string baseUrl = "";
        public Serverconnection(string url)
        {

            if (!url.StartsWith("http://"))
            {
                throw new ArgumentException("Hibás url,http:// meagasása sikertelen");

            }
            baseUrl = url;
            GetSubjects();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            List<Subject> resault = new List<Subject>();
            string url = baseUrl + "/subject";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                resault = JsonSerializer.Deserialize<List<Subject>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return resault;

        }
        public async Task<List<Users>> GetUsers()
        {
            List<Users> resault = new List<Users>();
            string url = baseUrl + "/user";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                resault = JsonSerializer.Deserialize<List<Users>>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return resault;

        }
        public async Task<Message> PostUser(string username,string password)
        {
            Message message = new Message();
            string url = baseUrl + "/user";
            try
            {
                var jsondata = new
                {
                    username = username,
                    password = password
                };
                string jsonString=JsonSerializer.Serialize(jsondata);
                HttpContent content=new StringContent(jsonString);
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return message;

        }
        public async Task<Message> PostSubject( string name)
        {
            Message message = new Message();
            string url = baseUrl + "/subject";
            try
            {
                var jsondata = new
                {
                    name = name
                };
                string jsonString = JsonSerializer.Serialize(jsondata);
                HttpContent content = new StringContent(jsonString);
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return message;
        }
        public async Task<Message> DeleteSubject(int id)
        {
            Message message = new Message();
            string url = baseUrl + "/subject/"+id;
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return message;
        }
        public async Task<Subject?> GetbiggestAsync()
        {
            string url = baseUrl + "/subject";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString= await response.Content.ReadAsStringAsync();
                List<Subject>? subjects = JsonSerializer.Deserialize<List<Subject>>(jsonString);
                Subject biggest = subjects.OrderByDescending(s => s.name.Count()).First();
                return biggest;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }


        }
        public async Task<Subject?> GetSmallestAsync()
        {
            string url = baseUrl + "/subject";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                List<Subject>? subjects = JsonSerializer.Deserialize<List<Subject>>(jsonString);
                Subject biggest = subjects.OrderByDescending(s => s.name.Count()).Last();
                return biggest;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }


        }


    }
}
