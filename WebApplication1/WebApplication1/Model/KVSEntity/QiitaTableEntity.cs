using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.KVSEntity
{
    public class QiitaTableEntity: TableEntity
    {
        public QiitaTableEntity(string qiitaId)
        {
            this.QiitaId = qiitaId;
        }

        public string QiitaId { get; set; }
    }
}
