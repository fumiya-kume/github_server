using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.KVSEntity;

namespace WebApplication1.Model.Repository
{
    public class QiitaSettingRepository : IQiitaSettingRepository
    {
        private IKVSClient KVSClient { get; set; }
        private readonly string tableName = "qiitasetting";

        public QiitaSettingRepository(IKVSClient kVSClient)
        {
            KVSClient = kVSClient;
        }

        public async Task<string> LoadSetting(string key)
        {
            QiitaTableEntity loadResult = await KVSClient.LoadWithKeyAsync<QiitaTableEntity>(tableName, key);
            return loadResult.QiitaId;
        }

        public async Task WriteSetting(string key, string QiitaSetting)
        {
            QiitaTableEntity entity = new QiitaTableEntity(QiitaSetting);
            await KVSClient.SaveAsync(tableName, key, entity);
        }
    }
}
