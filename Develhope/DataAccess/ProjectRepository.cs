using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;
using Microsoft.VisualBasic;

namespace Develhope.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private static readonly string _PROJECT_DATA_PATH = Shared.Constants.DATA_PATH + "projects.json";
        private static readonly JsonSerializerOptions _Options = new JsonSerializerOptions {WriteIndented= true};
        public async Task CreateAsync(Project item)
        {
            var projects = await GetAllAsync();
            projects.Add(item);
            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, JsonSerializer.Serialize(projects, _Options));
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var readJsonToFile= File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var stringJson= JsonSerializer.Deserialize<List<Project>>(await readJsonToFile, _Options) ?? new List<Project>();  
            return stringJson;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            /*var getProject = await GetAllAsync();
            foreach(var item in getProject)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return ;*/
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project item)
        {
            throw new NotImplementedException();
        }
    }
}