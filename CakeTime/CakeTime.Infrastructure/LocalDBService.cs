using CakeTime.Domain;
using Microsoft.Maui.Storage;
using SQLite;

namespace CakeTime.Infrastructure;

internal sealed class LocalDBService
{
    private const string DB_NAME = "cake_time_db.db3";

    public SQLiteAsyncConnection Connection { get; init; }

    public LocalDBService()
    {
        var dbFullPath = Path.Combine(FileSystem.AppDataDirectory, DB_NAME);
        Connection = new SQLiteAsyncConnection(
            dbFullPath,
            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        Connection.CreateTableAsync<EventData>();
        Connection.CreateTableAsync<NotificationSetting>();
    }
}