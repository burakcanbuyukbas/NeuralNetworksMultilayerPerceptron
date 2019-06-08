using MlpProject.models;
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
        public Form2(List<Result> results, string resultString, double accuracy)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Iterations", typeof(double));
            dt.Columns.Add("Error", typeof(double));
            dt.Columns.Add("Validation Error", typeof(double));
            StringBuilder sb = new StringBuilder();
            string[] resultStringArray = resultString.Split('&');
            for (int i = 0; i < resultStringArray.Length; i++)
            {
                sb.AppendFormat(resultStringArray[i]);
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Accuracy: " + accuracy);
            richTextBox1.Text = sb.ToString();
            foreach (Result item in results)
            {                
                dt.Rows.Add(item.val1, item.val2, item.accuracy);
            }
            chart1.DataSource = dt;
            chart1.Series.RemoveAt(0);
            chart2.Series.RemoveAt(0);
            chart1.Series.Add("Training Error");
            chart1.Series["Training Error"].XValueMember = "Iterations";
            chart1.Series["Training Error"].YValueMembers = "Error";
            chart1.Series["Training Error"].ChartType = SeriesChartType.Line;
            chart2.Series.Add("Validation Error");
            chart2.DataSource = dt;
            chart2.Series["Validation Error"].XValueMember = "Iterations";
            chart2.Series["Validation Error"].YValueMembers = "Validation Error";
            chart2.Series["Validation Error"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisY.Maximum = 5;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 1;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart1.Series["Training Error"].Color = Color.Blue;
            chart1.Series["Training Error"].BorderWidth = 2;
            chart2.Series["Validation Error"].Color = Color.Blue;
            chart2.Series["Validation Error"].BorderWidth = 2;
        }
    }
}
