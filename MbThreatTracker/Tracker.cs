using MbThreatTracker.Controls;
using MbThreatTracker.Services;

namespace MbThreatTracker
{
    public partial class Tracker : Form
    {
        private readonly HashSet<string> _threatsIds = [];
        private readonly DatabaseService _databaseService;
        private readonly System.Timers.Timer _walPollTimer;
        private long _lastWalSize = 0;
        public static string DbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Malwarebytes");

        public Tracker()
        {
            string? dbPassword = MalwarebytesService.GetDatabasePassword();

            if (string.IsNullOrEmpty(dbPassword))
                throw new Exception("Could not retrieve Malwarebytes database password.");

            _databaseService = new DatabaseService(dbPassword, DateTime.UtcNow);


            _walPollTimer = new System.Timers.Timer(100);
            _walPollTimer.Elapsed += WalPollTimer_Elapsed;
            _walPollTimer.AutoReset = true;
            _walPollTimer.Start();

            InitializeComponent();

            PanelThreats.AutoScroll = true;
        }

        private void WalPollTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            string walPath = Path.Combine(DbPath, "data.db-wal");
            var fi = new FileInfo(walPath);
            if (!fi.Exists) return;

            long currentSize = fi.Length;
            if (currentSize != _lastWalSize)
            {
                _lastWalSize = currentSize;
                OnWalChanged();
            }
        }

        private void OnWalChanged()
        {
            Task.Run(() =>
            {
                _databaseService.ForceMerge();
                var threats = _databaseService.GetThreats();

                var newThreats = threats.Where(t => t.Id != null && !_threatsIds.Contains(t.Id)).ToList();
                if (newThreats.Count == 0) return;

                PanelThreats.Invoke((MethodInvoker)(() =>
                {
                    foreach (var t in newThreats)
                    {
                        _threatsIds.Add(t.Id!);

                        var mbThreat = new MbThreat(t.Name ?? "Unknown", t.Path ?? "Unknown")
                        {
                            Dock = DockStyle.Top
                        };
                        PanelThreats.Controls.Add(mbThreat);
                    }
                }));
            });
        }

        private void Tracker_FormClosing(object sender, FormClosingEventArgs e) => _databaseService.Dispose();
    }
}
