﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MlpProject.models
{
    class Perceptron
    {
        List<Layer> layers;
        List<Tuple<int, double>> results = new List<Tuple<int, double>>();

        public Perceptron(int[] neuronsPerlayer)
        {
            layers = new List<Layer>();
            Random r = new Random();

            for (int i = 0; i < neuronsPerlayer.Length; i++)
            {
                layers.Add(new Layer(neuronsPerlayer[i], i == 0 ? neuronsPerlayer[i] : neuronsPerlayer[i - 1], r));
            }
        }
        public double[] Activate(double[] inputs)
        {
            double[] outputs = new double[0];
            for (int i = 1; i < layers.Count; i++)
            {
                outputs = layers[i].Activate(inputs);
                inputs = outputs;
            }
            return outputs;
        }
        double IndividualError(double[] realOutput, double[] desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < realOutput.Length; i++)
            {
                err += Math.Pow(realOutput[i] - desiredOutput[i], 2);
            }
            return err;
        }
        double GeneralError(List<double[]> input, List<double[]> desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < input.Count; i++)
            {
                err += IndividualError(Activate(input[i]), desiredOutput[i]);
            }
            return err;
        }
        List<string> log;
        public bool Learn(List<double[]> input, List<double[]> desiredOutput, double alpha, double maxError, int maxIterations, String net_path = null, int iter_save = 1)
        {
            double err = 99999;
            log = new List<string>();
            int it = maxIterations;
            while (err > maxError)
            {
                ApplyBackPropagation(input, desiredOutput, alpha);
                err = GeneralError(input, desiredOutput);


                if ((it - maxIterations) % 1000 == 0)
                {
                    Console.WriteLine(err + " iterations: " + (it - maxIterations));
                    results.Add(new Tuple<int, double>(it - maxIterations, err));
                }


                //if (net_path != null)
                //{
                //    if ((it - maxIterations) % iter_save == 0)
                //    {
                //        save_net(net_path);
                //        Console.WriteLine("Save network to " + net_path);
                //    }
                //}

                log.Add(err.ToString());
                maxIterations--;

                //if (Console.KeyAvailable)
                //{
                //    System.IO.File.WriteAllLines(@"Debug.txt", log.ToArray());
                //    return true;
                //}

                if (maxIterations <= 0)
                {
                    Console.WriteLine("Input Error");
                    System.IO.File.WriteAllLines(@"Debug.txt", log.ToArray());
                    return false;
                }

            }

            System.IO.File.WriteAllLines(@"Debug.txt", log.ToArray());
            return true;
        }

        public List<Tuple<int, double>> returnResults()
        {
            return results;
        }


        List<double[]> sigmas;
        List<double[,]> deltas;

        void SetSigmas(double[] desiredOutput)
        {
            sigmas = new List<double[]>();
            for (int i = 0; i < layers.Count; i++)
            {
                sigmas.Add(new double[layers[i].numberOfNeurons]);
            }
            for (int i = layers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    if (i == layers.Count - 1)
                    {
                        double y = layers[i].neurons[j].lastActivation;
                        sigmas[i][j] = (Neuron.Sigmoid(y) - desiredOutput[j]) * Neuron.SigmoidDerivated(y);
                    }
                    else
                    {
                        double sum = 0;
                        for (int k = 0; k < layers[i + 1].numberOfNeurons; k++)
                        {
                            sum += layers[i + 1].neurons[k].weights[j] * sigmas[i + 1][k];
                        }
                        sigmas[i][j] = Neuron.SigmoidDerivated(layers[i].neurons[j].lastActivation) * sum;
                    }
                }
            }
        }
        void SetDeltas()
        {
            deltas = new List<double[,]>();
            for (int i = 0; i < layers.Count; i++)
            {
                deltas.Add(new double[layers[i].numberOfNeurons, layers[i].neurons[0].weights.Length]);
            }
        }
        void AddDelta()
        {
            for (int i = 1; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].weights.Length; k++)
                    {
                        deltas[i][j, k] += sigmas[i][j] * Neuron.Sigmoid(layers[i - 1].neurons[k].lastActivation);
                    }
                }
            }
        }
        void UpdateBias(double alpha)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    layers[i].neurons[j].bias -= alpha * sigmas[i][j];
                }
            }
        }
        void UpdateWeights(double alpha)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].weights.Length; k++)
                    {
                        layers[i].neurons[j].weights[k] -= alpha * deltas[i][j, k];
                    }
                }
            }
        }
        void ApplyBackPropagation(List<double[]> input, List<double[]> desiredOutput, double alpha)
        {
            SetDeltas();
            for (int i = 0; i < input.Count; i++)
            {
                Activate(input[i]);
                SetSigmas(desiredOutput[i]);
                UpdateBias(alpha);
                AddDelta();
            }
            UpdateWeights(alpha);

        }

        public void save_net(String neuralNetworkPath)
        {
            FileStream fs = new FileStream(neuralNetworkPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static Perceptron Load(String neuralNetworkPath)
        {
            FileStream fs = new FileStream(neuralNetworkPath, FileMode.Open);
            Perceptron p = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                p = (Perceptron)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return p;
        }
    }
}
