using DR.shared;
using System;
using System.Collections.Generic;
using System.Text;
using DR.Data;
using System.Linq;
namespace DR
{
    public class NN
    { 
        const float Throuput = -0.1f;
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
        static List<List<float>> weights;
        static List<List<float>> threshold;
        public NN(float rate, int iteration)
        {
            this.rate = rate;
            this.iteration = iteration;
            initNum();
            initWeights();
            
        }
        private void initNum()
        {
            zero = new List<float>() { 0,0,0,0,0,   0, 0, 0, 0, 0      ,0, 0,1,1,0,     0, 0, 1, 1, 0,     0, 0, 0, 0, 0,    0, 0, 0, 0, 0,    0, 0, 0, 0, 0 };
            one = new List<float>() { 0,0,0,0,0,   0,0,1,0,0,    0, 0, 1, 0, 0,    0, 0, 1, 0, 0,    0, 0, 1, 0, 0,    0, 0, 1, 0, 0,    0,0,0,0,0};
            two = new List<float>() { 0, 0, 0, 0, 0,  1,0,0,1,0   ,1,1,1,0,0   ,1,0,0,0,0,    1, 0, 0, 0, 0,     1, 0, 0, 0, 0,     0, 0, 0, 0, 0, };
            three = new List<float>() { 0, 0, 0, 0, 0,    1,0,1,0,1   ,1,1,0,1,0    ,1,0,0,0,0,     1, 0, 0, 0, 0 ,   1, 0, 0, 0, 0,    0, 0, 0, 0, 0};
            four = new List<float>() { 0, 0, 0, 0, 0,   0,1,1,1,1   ,0,0,1,0,0    ,0,0,0,1,0     ,0,0,1,0,0    ,0,1 ,0,0,0    ,0, 1, 1, 1, 1 };
            five = new List<float>() { 0, 0, 0, 0, 0,   0,0,1,0,0   ,0,1,0,1,0    ,1,0,0,0,1   , 1, 0, 0, 0, 1   ,  1, 0, 0, 0, 1   ,0,1,1,1,0 };
            six = new List<float>() { 0, 0, 0, 0, 0,   0,1,0,0,1   ,0,0,1,1,1,     0, 0, 0, 0, 1,     0, 0, 0, 0, 1,       0, 0, 0, 0, 1,       0, 0, 0, 0, 1 };
            seven = new List<float>() { 0, 0, 0, 0, 0,  1,0,0,0,1   ,1,0,0,1,0   ,1,0,1,0,0    ,1,1,0,0,0    ,1,0,0,0,0   , 0, 0, 0, 0, 0 };
            eight = new List<float>() { 0, 0, 0, 0, 0,   0,0,0,0,1   ,0,0,0,1,1   ,0,0,1,0,1   ,0,1,0,0,1  ,1,0,0,0,1   ,0, 0, 0, 0, 0 };
            nine = new List<float>() { 0, 0, 0, 0, 0   ,0,0,1,1,0   ,0,1,0,0,1  ,0,0,1,1,1    ,0,0,0,0,1,      0, 0, 0, 0, 1 ,   0, 0, 0, 0, 0 };
        }
        void initWeights()
        {
            Random rand = new Random();
            List<float> l1;
            weights = new List<List<float>>();
            int prev = 35;
            foreach (Layer layer in layers.layer)
            {
                 l1 = new List<float>();
                
                for(int i=0;i< (layer.nodes)*prev; i++)
                {
                    float f = rand.Next(-10, 11) * .1f;
                    l1.Add(f);
                }
                prev = layer.nodes;
                weights.Add(new List<float>(l1));
            }
            l1 = new List<float>();
            for (int i = 0; i < 10*prev; i++)
            {
                float f = rand.Next(-10, 11) * .1f;
                l1.Add(f);

            }
            weights.Add(new List<float>(l1));
            threshold = new List<List<float>>();
            foreach (Layer layer in layers.layer)
            {
                l1 = new List<float>();
                for(int i = 0; i < layer.nodes; i++)
                {
                    float f = rand.Next(-10, 11) * .1f;
                    l1.Add(f);
                }
                threshold.Add(l1);
            }

        }
        public void train()
        {
            Random rand = new Random();
            for (int i=0;i<iteration;i++)
            {//zero
                train(zero,new List<float>() { 1,0,0,0,0,0,0,0,0,0});
                for(int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    zero[x] = rand.Next(0, 11) * .1f;
                    train(zero, new List<float>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                }
                //one
                train(one, new List<float>() { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    one[x] = rand.Next(0, 11) * .1f;
                    train(one, new List<float>() { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
                }
                //two
                train(two, new List<float>() { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    two[x] = rand.Next(0, 11) * .1f;
                    train(two, new List<float>() { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
                }
                //three
                train(three, new List<float>() { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    three[x] = rand.Next(0, 11) * .1f;
                    train(three, new List<float>() { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                }
                //four
                train(four, new List<float>() { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    four[x] = rand.Next(0, 11) * .1f;
                    train(four, new List<float>() { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 });
                }
                //five
                train(five, new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    five[x] = rand.Next(0, 11) * .1f;
                    train(five, new List<float>() { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 });
                }
                //six
                train(six, new List<float>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    six[x] = rand.Next(0, 11) * .1f;
                    train(six, new List<float>() { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
                }
                //seven
                train(seven, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    seven[x] = rand.Next(0, 11) * .1f;
                    train(seven, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 });
                }
                //eight
                train(eight, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    eight[x] = rand.Next(0, 11) * .1f;
                    train(eight, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 });
                }
                //nine
                train(nine, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
                for (int j = 0; i < 29; i++)
                {
                    int x = rand.Next(0, 35);
                    nine[x] = rand.Next(0, 11) * .1f;
                    train(nine, new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
                }

            }
        }
        public int test(List<float> input)
        {
           
            List<List<float>> output =forward(input);
            float max = int.MinValue;
            foreach (float x in output.ElementAt(output.Count() - 1))
            {
                if (max < x)
                { max = x; }

                
            }
            int result = output.ElementAt(output.Count() - 1).IndexOf(max);
            return result;

        }
        private void train(List<float> list, List<float> doutput)
        {
            
            List<List<float>> output = new List < List<float> > (forward(list));
            backward(output,doutput,rate,list);
        }
        List<List<float>> forward(List<float> list)
        {

            List<float> current = list;
            List<List<float>> output = new List<List<float>>();
            List<float> temp = new List<float>();
            int count = 0;
            foreach (List<float> layer in weights)
            {
                if(count < layers.layer.Count())
                {

                
                for (int i = 0; i < layers.layer.ElementAt(count).nodes; i++)
                {

                    float sum = 0;
                    for (int j = 0; j < current.Count(); j++)
                    {
                        float result = current.ElementAt(j) * layer.ElementAt(j + (current.Count() * i));
                        sum += result;
                    }
                    sum -= Throuput;
                        sum *= 1000;
                        sum = (int)sum;
                        sum /= 1000;
                    if (layers.layer.ElementAt(count).AFunc)
                    {
                        temp.Add(Relu(sum));

                    }
                    else
                    {
                        temp.Add(Tanh(sum));

                    }
                }
                }
                else
                {


                    for (int i = 0; i < 10; i++)
                    {

                        float sum = 0;
                        for (int j = 0; j < current.Count(); j++)
                        {
                            float result = current.ElementAt(j) * layer.ElementAt(j + (current.Count() * i));
                            sum += result;
                        }
                        sum -= Throuput;
                        sum *= 1000;
                        sum = (int)sum;
                        sum /= 1000;
                        temp.Add(Tanh(sum));


                    }


                }
                output.Add(new List<float>(temp));
                current = new List<float>(temp);
                temp = new List<float>();

                count++;
            }
            return output;
        }

        float Relu(float x)
        {
            return Math.Max(0, x);
        }
        float Tanh(float x)
        {
            return (float)Math.Tanh(x);
        }

        void backward(List<List<float>> output , List<float> desired,float rate , List<float> list)
        {
            List<float> layer = weights.ElementAt(weights.Count() - 1);
            int nodes = layers.layer.ElementAt(layers.layer.Count() - 1).nodes;
            bool func = layers.layer.ElementAt(layers.layer.Count() - 1).AFunc;
            List<float> current = new List<float>();
            for (int i = 0; i < 10; i++)
            {
                float er = desired.ElementAt(i) - (output.ElementAt(output.Count() - 1).ElementAt(i));
                float segma;


                segma = (DTanh((output.ElementAt(output.Count() - 1).ElementAt(i)))) * er;
                current.Add(segma);

                for (int j = 0; j < nodes; j++)
                    {
                    
              
                    
                    

                    float dw = (output.ElementAt(output.Count() - 2).ElementAt(j)) * rate*segma;
                    dw *= 1000;
                    dw = (int)dw;
                    dw /= 1000;
                    


                    layer[(j + (i * nodes))]=layer.ElementAt(j + (i * nodes)) + dw;
                    }
            }


                //

                bool stop=false;
            for(int x=2; x < weights.Count; x++)
            {int cnodes=  layers.layer.ElementAt(layers.layer.Count() - (x-1)).nodes;
                layer = weights.ElementAt(weights.Count() - x);
                if (stop)
                {
                    break;
                }
                if (weights.Count - (x + 1)<0)
                {
                    stop = true;
                    nodes = 35;
                }
                else { nodes = layers.layer.ElementAt(layers.layer.Count() - x).nodes; }


                float sum = 0;
                int count1 = 0;
                foreach (float num in current)
                {
                    float res=0;
                    for (int i = 0; i < nodes; i++)
                    {
                        res=num*weights.ElementAt(weights.Count()-(x-1)).ElementAt(i+(nodes*count1));

                    }
                    

                    sum += res;
                    count1++;
                }

                current.Clear();





                for (int i = 0; i < cnodes; i++)
                {
                    for (int j = 0; j < nodes; j++)
                    {

                        
                        float segma;
                        if (func)
                        {
                            segma = (DRelu((output.ElementAt(output.Count() - (x-1)).ElementAt(i)))) * sum * layer.ElementAt(j + (i * nodes));
                        }
                        else
                        {
                            segma =  (DTanh((output.ElementAt(output.Count() - (x-1)).ElementAt(i)))) * sum * layer.ElementAt(j + (i * nodes));
                        }

                        current.Add(segma);

                        
                       

                       
                    }
                }

                
                for (int i = 0; i < layer.Count(); i++)
                {
                    int prenodes = layer.Count() / nodes;
                    float dw;
                    if (stop) 
                    {
                        float input= list.ElementAt(i % 35);
                        dw = input * rate * current.ElementAt(i);
                    }
                    else 
                    {   float input = (output.ElementAt(output.Count() - (x + 1)).ElementAt(i%prenodes));
                        bool func1 = layers.layer.ElementAt(layers.layer.Count() - x).AFunc;
                        if (func1)
                        {
                            input = 1 / Relu(input);
                        }
                        else
                        {
                            input = 1 / Tanh(input);
                        }
                        input += Throuput;
                        dw =   input * rate * current.ElementAt(i);
                    }
                    
                    
                    dw *= 1000;
                    dw = (int)dw;
                    dw /= 1000;
                    layer[i] = layer.ElementAt(i) + dw;
                }


            }

            
        }
        float DRelu(float x)
        {
            return Math.Max(0, 1);
        }
        float DTanh(float x)
        {
            return (float)(1 - Math.Pow(Tanh(x), 2));
        }
    }
    

}
