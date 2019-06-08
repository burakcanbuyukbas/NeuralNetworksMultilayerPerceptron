using MlpProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string inputPath = @"..\..\..\MlpProject\Datasets\iris.csv";
        static string outputPath = @"..\..\..\MlpProject\Datasets\irisout.csv";
        static string neuralNetworkPath = @"..\..\..\MlpProject\Datasets\Iris.bin";

        static int inputCount = 4;
        static int outputCount = 1;

        static bool saveNetwork = true;
        static bool loadNetwork = true;

        static double inputMax = 10;
        static double inputMin = 0;

        static int outputMax = 3;
        static int outputMin = 1;

        static List<double[]> input = new List<double[]>();
        static List<double[]> output = new List<double[]>();
        static List<double[]> validationInput = new List<double[]>();
        static List<double[]> validationOutput = new List<double[]>();
        static List<double[]> trainInput = new List<double[]>();
        static List<double[]> trainOutput = new List<double[]>();
        static List<double[]> test = new List<double[]>();
        static List<double[]> testOutput = new List<double[]>();

        List<Result> results = new List<Result>();
        int datasetId;

        static void ReadData(int dataSetId)
        {
            #region iris dataset
            if (dataSetId == 0)//iris dataset
            {
                string data = System.IO.File.ReadAllText(inputPath).Replace("\r", "").Replace("\"", "");//.Replace(",", ".");
                string[] row = data.Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < row.Length - 1; i++)
                {
                    if (i % 10 != 0)
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 0; j < rowData.Length - 1; j++)
                        {
                            if (j < inputCount)
                            {
                                inputs[j] = normalize(double.Parse(rowData[j]), inputMin, inputMax);
                                // Console.WriteLine(inputs[j]);
                            }
                            else
                            {
                                outputs[j - inputCount] = normalize(double.Parse(rowData[j]), outputMin, outputMax);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        input.Add(inputs);
                        output.Add(outputs);
                    }

                    else
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 0; j < rowData.Length - 1; j++)
                        {
                            if (j < inputCount)
                            {
                                inputs[j] = normalize(double.Parse(rowData[j]), inputMin, inputMax);
                                // Console.WriteLine(inputs[j]);
                            }
                            else
                            {
                                outputs[j - inputCount] = double.Parse(rowData[j]);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        test.Add(inputs);
                        testOutput.Add(outputs);
                    }

                }
            }
            #endregion

            #region breast cancer dataset
            else if (dataSetId == 1)
            {
                inputMax = 10;
                inputMin = 0;
                inputCount = 9;
                outputCount = 1;
                outputMax = 4;
                outputMin = 2;
                string data = System.IO.File.ReadAllText(inputPath).Replace("\r", "").Replace("\"", "");//.Replace(",", ".");
                string[] row = data.Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < row.Length - 1; i++)
                {
                    if (i % 10 != 0)
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 0; j < rowData.Length; j++)
                        {
                            if (j > 0 && j < inputCount)
                            {
                                inputs[j-1] = normalize(double.Parse(rowData[j]), inputMin, inputMax);
                                // Console.WriteLine(inputs[j]);
                            }
                            else
                            {
                                outputs[0] = normalize(double.Parse(rowData[j]), outputMin, outputMax);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        input.Add(inputs);
                        output.Add(outputs);
                    }

                    else
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 1; j < rowData.Length; j++)
                        {
                            if (j > 0 && j < inputCount+1)
                            {
                                inputs[j-1] = normalize(double.Parse(rowData[j]), inputMin, inputMax);
                                // Console.WriteLine(inputs[j]);
                            }
                            else
                            {
                                outputs[0] = double.Parse(rowData[j]);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        test.Add(inputs);
                        testOutput.Add(outputs);
                    }

                }
            }
            #endregion

            #region wine dataset
            else
            {
                inputCount = 13;
                outputCount = 1;
                outputMax = 3;
                outputMin = 1;
                string data = System.IO.File.ReadAllText(inputPath).Replace("\r", "").Replace("\"", "");//.Replace(",", ".");
                string[] row = data.Split(Environment.NewLine.ToCharArray());
                for (int i = 0; i < row.Length; i++)
                {
                    if (i % 10 != 0)
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 0; j < rowData.Length; j++)
                        {
                            if (j > 0 && j < inputCount + 2)
                            {
                                switch (j)
                                {
                                    case 1:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 11.0, 15.0);
                                        break;
                                    case 2:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.0, 6.0);
                                        break;
                                    case 3:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.30, 3.30);
                                        break;
                                    case 4:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 10.0, 30.0);
                                        break;
                                    case 5:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 70.0, 165.0);
                                        break;
                                    case 6:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.8, 4.0);
                                        break;
                                    case 7:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.30, 5.10);
                                        break;
                                    case 8:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.10, 0.70);
                                        break;
                                    case 9:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.4, 3.6);
                                        break;
                                    case 10:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.2, 13.0);
                                        break;
                                    case 11:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.45, 1.75);
                                        break;
                                    case 12:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.0, 4.0);
                                        break;
                                    case 13:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 250, 1700);
                                        break;
                                    default:
                                        break;
                                }
                                // Console.WriteLine(inputs[j]);
                            }
                            else
                            {
                                outputs[0] = normalize(double.Parse(rowData[j]), outputMin, outputMax);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        input.Add(inputs);
                        output.Add(outputs);
                    }

                    else
                    {
                        string[] rowData = row[i].Split(',');

                        double[] inputs = new double[inputCount];
                        double[] outputs = new double[outputCount];

                        for (int j = 0; j < rowData.Length; j++)
                        {
                            if (j > 0 && j < inputCount + 2)
                            {
                                switch (j)
                                {
                                    case 1:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 11.0, 15.0);
                                        break;
                                    case 2:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.0, 6.0);
                                        break;
                                    case 3:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.30, 3.30);
                                        break;
                                    case 4:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 10.0, 30.0);
                                        break;
                                    case 5:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 70.0, 165.0);
                                        break;
                                    case 6:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.8, 4.0);
                                        break;
                                    case 7:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.30, 5.10);
                                        break;
                                    case 8:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.10, 0.70);
                                        break;
                                    case 9:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.4, 3.6);
                                        break;
                                    case 10:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.2, 13.0);
                                        break;
                                    case 11:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 0.45, 1.75);
                                        break;
                                    case 12:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 1.0, 4.0);
                                        break;
                                    case 13:
                                        inputs[j - 1] = normalize(double.Parse(rowData[j]), 250, 1700);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                outputs[0] = double.Parse(rowData[j]);
                                //Console.WriteLine(outputs[j - inputCount]);
                            }
                        }

                        test.Add(inputs);
                        testOutput.Add(outputs);
                    }

                }
            }
            #endregion
        }


        static double normalize(double val, double min, double max)
        {
            return (val - min) / (max - min);
        }
        static double inverseNormalize(double val, double min, double max)
        {
            return val * (max - min) + min;
        }

        static void Evaluate(Perceptron p, double from, double to, double step)
        {
            string output = "";
            for (double i = from; i < to; i += step)
            {
                double res = p.Activate(new double[] { normalize(i, inputMin, inputMax) })[0];


                output += i + ";" + inverseNormalize(res, outputMin, outputMax) + "\n";
                Console.WriteLine(i + ";" + res + "\n");
            }

            System.IO.File.WriteAllText(outputPath, output);
        }

        static void DecomposeSets()
        {
            int k = 0;
            int j = 0;
            foreach (double[] arr in input)
            {
                if (k % 7 == 0 || k % 9 == 0)
                {
                    validationInput.Add(arr);
                }
                else
                {
                    trainInput.Add(arr);
                }
                k++;
            }

            foreach (double[] arr in output)
            {
                if (j % 7 == 0 || j % 9 == 0)
                {
                    validationOutput.Add(arr);
                }
                else
                {
                    trainOutput.Add(arr);
                }
                j++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Variables

            if (radioButtonIris.Checked)
            {
                inputPath = @"..\..\..\MlpProject\Datasets\iris.csv";
                outputPath = @"..\..\..\MlpProject\Datasets\irisout.csv";
                neuralNetworkPath = @"..\..\..\MlpProject\Datasets\IrisTraining.bin";
                inputMax = 10;
                inputMin = 0;
                outputMax = 3;
                outputMin = 1;
                datasetId = 0;
            }
            else if (radioButtonMushroom.Checked)
            {
                inputPath = @"..\..\..\MlpProject\Datasets\breastCancer.csv";
                outputPath = @"..\..\..\MlpProject\Datasets\breastCancerOut.csv";
                neuralNetworkPath = @"..\..\..\MlpProject\Datasets\breastCancerTraining.bin";
                inputMax = 10;
                inputMin = 0;
                outputMax = 3;
                outputMin = 1;
                datasetId = 1;
            }
            else
            {
                inputPath = @"..\..\..\MlpProject\Datasets\wine.csv";
                outputPath = @"..\..\..\MlpProject\Datasets\wineout.csv";
                neuralNetworkPath = @"..\..\..\MlpProject\Datasets\WineTraining.bin";
                inputMax = 10;
                inputMin = 0;
                outputMax = 3;
                outputMin = 1;
                datasetId = 2;
            }
            Perceptron p;
            int neuronCount1 = 10;
            int neuronCount2 = 10;
            double learning_rate = 0.05;
            //double max_error = 0.0001;
            double max_error = 0.9;
            int max_iter = 1000000;
            if (textBoxNeuron1.Text != "")
            {
                neuronCount1 = int.Parse(textBoxNeuron1.Text);
            }
            if (textBoxNeuron2.Text != "")
            {
                neuronCount2 = int.Parse(textBoxNeuron2.Text);
            }
            if (textBoxLearningRate.Text != "")
            {
                learning_rate = double.Parse(textBoxLearningRate.Text);
            }
            if (textBoxMaxError.Text != "")
            {
                max_error = double.Parse(textBoxMaxError.Text);
            }
            if (textBoxMaxIteration.Text != "")
            {
                max_iter = int.Parse(textBoxMaxIteration.Text);
            }
            #endregion

            int[] net_def = new int[] { inputCount, neuronCount1, neuronCount2, outputCount };

            if (loadNetwork)
            {
                ReadData(datasetId);
                DecomposeSets();

                p = new Perceptron(net_def);
                p.outputMin = outputMin;
                p.outputMax = outputMax;
                while (!p.Learn(trainInput, trainOutput, validationInput, validationOutput, learning_rate, max_error, max_iter, neuralNetworkPath, 10000))
                {
                    p = new Perceptron(net_def);
                }
                results = p.returnResults();
            }
            else
            {
                p = Perceptron.Load(neuralNetworkPath);
            }


            string resultsString = "";
            double accuracy = 0;
            double correctMatch = test.Count;
            double[] correctClass = new double[test.Count];
            double[] resultClass = new double[test.Count];
            for (int j = 0; j < test.Count; j++)
            {
                double[] val = test[j];
                double[] valLabel = testOutput[j];
                double[] sal = p.Activate(val);

                for (int i = 0; i < outputCount; i++)
                {
                    resultClass[j] = Math.Round(inverseNormalize(sal[i], outputMin, outputMax), MidpointRounding.AwayFromZero);
                    correctClass[j] = valLabel[0];
                    resultsString += "& Output: " + Math.Round(inverseNormalize(sal[i], outputMin, outputMax), MidpointRounding.AwayFromZero) + " for " + valLabel[0];
                    Console.Write("Output " + i + ": " + inverseNormalize(sal[i], outputMin, outputMax) + " for " + valLabel[0]);
                }
                Console.WriteLine("");
            }
            for (int k = 0; k < test.Count; k++)
            {
                if(correctClass[k] != resultClass[k])
                {
                    correctMatch--;
                }
            }
            accuracy = correctMatch / test.Count * 100;

            Form2 form2 = new Form2(results, resultsString.Substring(2, resultsString.Length - 2), accuracy);
            form2.Show();

        }


        #region Validation
        private void textBoxNeuron1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void textBoxNeuron2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxLearningRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxError_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxIteration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}

