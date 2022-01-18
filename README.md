# arabic-digit-recognition-feed-forward-neural-network
a multi-layer perceptron network to classify the arabic digits. There are 10 classes and so each target vector could be a 1-in-10 vector. Each digit (whose dimensions are 5×7 pixels) is represented by an array of length 35.
the GUI allow the user to
o Choose how many hidden layers he needs? How many nodes in each layer?
o Enter the learning rate, maximum number of iterations
o Choose the layers activation function. It is dynamic (from the GUI the user can choose: ReLU, or Tanh)
o Show the system performance
o Use back-propagation learning algorithm
o Generates a training data, which consists of 20-30 samples for each digit: one without noise, and rest with noise. Example of noise data show below
o Give an initial random number for all the weights and biases
o Use Gradient Descent as training algorithm
o Use a good performance metric. Show the learning performance in the GUI.
