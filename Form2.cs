using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MlpProject
{
    public partial class Form2 : Form
    {
        public Form2(List<Tuple<int, double>> results, string resultString)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Iterations", typeof(double));
            dt.Columns.Add("Error", typeof(double));
            StringBuilder sb = new StringBuilder();
            string[] resultStringArray = resultString.Split('&');
            for (int i = 0; i < resultStringArray.Length; i++)
            {
                sb.AppendFormat(resultStringArray[i]);
                sb.AppendLine();
            }
            richTextBox1.Text = sb.ToString();
            foreach (var item in results)
            {
                dt.Rows.Add(item.Item1, item.Item2);
            }
            chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "Iterations";
            chart1.Series["Series1"].YValueMembers = "Error";
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }
    }
}
