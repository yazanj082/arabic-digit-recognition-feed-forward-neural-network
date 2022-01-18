using DR.Data;
using DR.shared;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using ZedGraph;

namespace DR
{
    public class NeuralNetwork
    {
        const float Threshold = -1f;
        float rate;
        int iteration;
        List<float> zero;
        List<float> one;
        List<float> two;
        List<float> three;
        List<float> four;
        List<float> five;
        List<float> six;
        List<float> seven;
        List<float> eight;
        List<float> nine;
        static Mydict weights;
        static List<Layer> layers;
        static List<Dictionary<int, Neuron>> network;
        public NeuralNetwork(float rate, int iteration)
        {
            this.rate = rate;
            this.iteration = iteration;
            initNum();
            initLayers();
            initNetwork();
            initWeights();
            
        }
        void initLayers()
        {
            layers = new List<Layer>();
            layers.Add(new Layer() { nodes = 35, input = true }) ;
            foreach(Layer layer in Data.layers.layer)
            {
                layers.Add(layer);
            }
            layers.Add(new Layer() { nodes = 10, output = true ,AFunc=false});
        }
        void initNetwork()
        {
            Random rand = new Random();
            network = new List<Dictionary<int, Neuron>>();
            int count = 0;
            Dictionary<int, Neuron> dict = new Dictionary<int, Neuron>();
            foreach (Layer layer in layers)
            {
                dict=new Dictionary<int, Neuron>();
                for (int i = 0; i < layer.nodes; i++)
                {
                    float random= rand.Next(-10, 11) * .1f;
                    dict.Add(count, new Neuron() { Threshold = random, input=layer.input,output=layer.output,AFunc=layer.AFunc,num=i}) ;
                    count++;
                }
                network.Add(dict);
            }
        }
        private void initNum()
        {
            zero = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            one = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
            two = new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            three = new List<float>() { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            four = new List<float>() { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1 };
            five = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };
            six = new List<float>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            seven = new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            eight = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            nine = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        }
        void initWeights()
        {
            Random rand = new Random();
            weights = new Mydict();

            for(int i = 0; i < network.Count()-1; i++)
            {
                foreach(KeyValuePair<int, Neuron> entry in network[i])
                {
                    foreach (KeyValuePair<int, Neuron> entry1 in network[i+1])
                    {
                        float f = rand.Next(-10, 11) * .1f;
                        weights.Add(entry.Key, entry1.Key, f);
                    }
                }
            }


        }


        public PointPairList train()
        {
            PointPairList PairList =new PointPairList();
            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {
                float sse =0 ;
                //zero
                float result;
                result = train(zero, new List<float>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    zero[x] = rand.Next(0, 11) * .1f;
                    result = train(zero, new List<float>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                    sse += result;
                }
                //one
                result =  train(one, new List<float>() { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    one[x] = rand.Next(0, 11) * .1f;
                    result = train(one, new List<float>() { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
                    sse += result;
                }
                //two
                result = train(two, new List<float>() { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    two[x] = rand.Next(0, 11) * .1f;
                    result = train(two, new List<float>() { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
                    sse += result;
                }
                //three
                result = train(three, new List<float>() { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    three[x] = rand.Next(0, 11) * .1f;
                    result = train(three, new List<float>() { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                    sse += result;
                }
                //four
                result = train(four, new List<float>() { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    four[x] = rand.Next(0, 11) * .1f;
                    result = train(four, new List<float>() { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
                    sse += result;
                }
                //five
                result = train(five, new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    five[x] = rand.Next(0, 11) * .1f;
                    result = train(five, new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 });
                    sse += result;
                }
                //six
                result = train(six, new List<float>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    six[x] = rand.Next(0, 11) * .1f;
                    result = train(six, new List<float>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
                    sse += result;
                }
                //seven
                result = train(seven, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    seven[x] = rand.Next(0, 11) * .1f;
                    result = train(seven, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 });
                    sse += result;
                }
                //eight
                result = train(eight, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    eight[x] = rand.Next(0, 11) * .1f;
                    result = train(eight, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 });
                    sse += result;
                }
                //nine
                result = train(nine, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
                sse += result;
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    nine[x] = rand.Next(0, 11) * .1f;
                    result = train(nine, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
                    sse += result;
                }
                float mse = sse / (300);
                PairList.Add( i,sse);
                
                if (sse<=0.001f)
                {
                    break;
                }
            }
            return PairList;
        }
        private float train(List<float> list, List<float> doutput)
        {

            forward(list);
            float sum = 0;
            foreach (KeyValuePair<int, Neuron> entry in network[network.Count() - 1])
            {

                sum = sum + (doutput[entry.Value.num]-entry.Value.Y);
            }
             backward( doutput, rate, list);
            return sum*sum;
        }
        void forward(List<float> list)
        {
            List<float> input = new List<float>(list);
            foreach(KeyValuePair<int, Neuron> entry in network[0])
            {
                entry.Value.X = input[entry.Key];
                entry.Value.Y = input[entry.Key];
            }
            for (int i = 1; i < network.Count(); i++)
            {
                foreach (KeyValuePair<int, Neuron> entry in network[i])
                {
                    float sum = 0;
                    foreach (KeyValuePair<int, Neuron> entry1 in network[i-1])
                    {
                        sum = sum + (entry1.Value.Y*weights.Get(entry1.Key,entry.Key));
                    }
                    sum -= entry.Value.Threshold;
                    sum *= 100000;
                    sum = (int)sum;
                    sum /= 100000;
                    entry.Value.X = sum;
                    if (entry.Value.AFunc)
                    {
                        entry.Value.Y = Relu(sum);
                    }
                    else
                    {
                        entry.Value.Y = Tanh(sum);
                    }
                }
            }
           
        }
        float backward(List<float> desired, float rate, List<float> list)
        {
            Dictionary<int, Neuron> neurons = network[network.Count() - 1];
            Dictionary<int, Neuron> preneurons = network[network.Count() - 2];
            Dictionary<int, Neuron> postneurons;
            float max = 0f;
            foreach (KeyValuePair<int, Neuron> entry in neurons)
            {
                float er = desired[entry.Value.num] - entry.Value.Y;

                    max += er;


                if (entry.Value.AFunc)
                {
                    entry.Value.perror = DRelu(entry.Value.Y)*er;
                }
                else
                {
                    entry.Value.perror = DTanh(entry.Value.Y) * er;
                }
                entry.Value.perror *= 100000;
                entry.Value.perror = (int)entry.Value.perror;
                entry.Value.perror /= 100000;
                float delta1 = rate * (Threshold) * entry.Value.perror;
                delta1 *= 100000;
                delta1 = (int)delta1;
                delta1 /= 100000;
                entry.Value.Threshold += delta1;
                foreach (KeyValuePair<int, Neuron> entry1 in preneurons)
                {
                    float delta = entry.Value.perror * entry1.Value.Y * rate;
                    string name= entry1.Key.ToString()+ entry.Key.ToString();
                    weights[name] = weights[name] + delta;
                }
            }
            for(int layerNum = 2; layerNum < network.Count(); layerNum++)
            {
                neurons = network[network.Count() - layerNum];
                preneurons = network[network.Count() - (layerNum + 1)];
                postneurons = network[network.Count() - (layerNum - 1)];
                foreach (KeyValuePair<int, Neuron> entry in neurons)
                {
                    float sum = 0;
                    foreach(KeyValuePair<int, Neuron> entry1 in postneurons)
                    {
                        string name = entry.Key.ToString() + entry1.Key.ToString();
                        sum += (entry1.Value.perror * weights[name]);
                    }
                    if (entry.Value.AFunc)
                    {
                        entry.Value.perror = DRelu(entry.Value.Y) * sum;
                    }
                    else
                    {
                        entry.Value.perror = DTanh(entry.Value.Y) * sum;
                    }
                    entry.Value.perror *= 100000;
                    entry.Value.perror = (int)entry.Value.perror;
                    entry.Value.perror /= 100000;
                    float delta1 = rate * (Threshold) * entry.Value.perror;
                    delta1 *= 100000;
                    delta1 = (int)delta1;
                    delta1 /= 100000;
                    entry.Value.Threshold += delta1;
                    foreach (KeyValuePair<int, Neuron> entry1 in preneurons)
                    {
                        float delta = entry.Value.perror * (entry1.Value.X) * rate;
                        string name = entry1.Key.ToString() + entry.Key.ToString();
                        weights[name] = weights[name] + delta;
                    }
                }

            }
            return max;
        }

        public int test(List<float> input)
        {

            forward(input);
            float max = int.MinValue;
            int result=0;
            foreach (KeyValuePair<int, Neuron> entry in network[network.Count()-1])
            {
                float x = entry.Value.Y;
                if (max < x)
                { 
                    max = x;
                    result = entry.Value.num;
                }


            }
            return result;

        }
        void SoftMax(Dictionary<int,Neuron> output)
        {
            double denominator = 0;
            foreach(KeyValuePair<int, Neuron> neuron in output)
            {
                double f = Math.Exp( neuron.Value.X);
                denominator += f;
            }
            foreach (KeyValuePair<int, Neuron> neuron in output)
            {
                double f = Math.Exp(neuron.Value.X);
                neuron.Value.Y = (float)(f / denominator);
                neuron.Value.Y *= 100000;
                neuron.Value.Y = (int)neuron.Value.Y;
                neuron.Value.Y /= 100000;
            }
        }
        float Relu(float x)
        {
            return Math.Max(0, x);
        }
        float Tanh(float x)
        {
            return (float)Math.Tanh(x);
        }
        float DRelu(float x)
        {
            if (x > 0)
            {
                return 1;
            }
            return 0;
        }
        float DTanh(float x)
        {
            return (float)(1 - Math.Pow(Tanh(x), 2));
        }

    }










    class Neuron 
    {
        public float Threshold;
        public bool AFunc;
        public bool input;
        public bool output;
        public int num;
        public float X;
        public float Y;
        public float perror;
    }
    class Mydict : Dictionary<string,float>
    {
        public int x, y;
        public string name;
        public void Add(int x,int y,float value)
        {
            this.Add(x.ToString() + y.ToString(), value);
            this.x = x;
            this.y = y;
            this.name = x.ToString() + y.ToString();
        }
        public float Get(int x,int y)
        {
            return this[x.ToString() + y.ToString()];
        }
    }


}
