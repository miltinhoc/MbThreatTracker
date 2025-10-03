using MbThreatTracker.Model;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace MbThreatTracker.Services
{
    public class DatabaseService : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly DateTime _initDateTime;
        private readonly string _connectionString;
        private readonly object _dbLock = new();

        public DatabaseService(string password, DateTime initDateTime)
        {
            _initDateTime = initDateTime;
            _connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = Path.Combine(Tracker.DbPath, "data.db"),
                Mode = SqliteOpenMode.ReadWrite,
                Password = password
            }.ToString();

            _connection = new SqliteConnection(_connectionString);
            _connection.Open();
        }

        public List<Threat> GetThreats()
        {
            lock (_dbLock)
            {
                var threats = new List<Threat>();

                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Timestamp,ThreatName,ObjectName,ID FROM Notifications WHERE ThreatName IS NOT NULL;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string threatTimestamp = reader.GetString(0);

                            if (DateTime.TryParseExact(
                                threatTimestamp,
                                "yyyy-MM-dd HH:mm:ss.fffffff",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.AssumeUniversal,
                                out DateTime timestamp))
                            {
                                if (timestamp > _initDateTime)
                                {
                                    var threat = new Threat
                                    {
                                        Timestamp = reader.GetString(0),
                                        Name = reader.GetString(1),
                                        Path = reader.GetString(2),
                                        Id = reader.GetString(3)
                                    };
                                    threats.Add(threat);
                                }
                            }
                        }
                    }
                }
                return threats;

            }
        }

        public void ForceMerge()
        {
            lock (_dbLock)
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                    _connection.Open();

                using var cmd = _connection.CreateCommand();
                cmd.CommandText = "PRAGMA wal_checkpoint(TRUNCATE);";
                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
