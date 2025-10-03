
namespace MbThreatTracker.Controls
{
    public partial class MbThreat : UserControl
    {
        public MbThreat(string threatName, string threatPath)
        {
            InitializeComponent();

            LabelThreatName.Text = threatName;

            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.BackColor = this.BackColor;
            textBox1.Width = 400;
            textBox1.ScrollBars = ScrollBars.None;

            textBox1.Text = threatPath;

            int measuredHeight = TextRenderer.MeasureText(textBox1.Text, textBox1.Font,
                new Size(textBox1.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;

            textBox1.Height = measuredHeight + textBox1.Font.Height;
        }
    }
}
