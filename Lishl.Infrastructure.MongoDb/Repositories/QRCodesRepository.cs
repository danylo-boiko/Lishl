using System;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb.Repositories
{
    public class QRCodesRepository : MongoDbGenericRepository<QRCode, Guid>, IQRCodesRepository
    {
        public QRCodesRepository(IMongoDatabase mongoDatabase)
        {
            _сollection = mongoDatabase.GetCollection<QRCode>("QRCodes");
        }
    }
}