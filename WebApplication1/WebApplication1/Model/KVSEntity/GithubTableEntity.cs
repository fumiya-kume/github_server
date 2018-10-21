using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.KVSEntity
{
    public class GithubTableEntity: TableEntity
    {
        public GithubTableEntity(string githubId)
        {
            this.GithubId = githubId;
        }

        public string GithubId { get; set; }
    }
}
