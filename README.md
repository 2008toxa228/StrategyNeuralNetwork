# StrategyNeuralNetwork
## About
There is presented neural network architecture based on strategy pattern, that makes it flexible and extensible.
## Structure
Main part of this solution is interfaces that are implemented by oter classes to performa specific functions:
* INeuron
* ILayer
* INetwork

INeuron includes:
* fields
  * Value (contains value before activation function processing)
  * Output (contains value after activation function processing)
  * Error (uses for training)
* methods
  * Initialize (initializes the current neuron with an input array of INeuron and returns a reference to an instance of the class)
  * PushInputs (sums the values of the inputs multiplied by their weights)
  * PassError (passes the Error to the previous layer)
  * CorrectWeigths (correct input weights with Error using learnRate as parametук)
  
ILayer includes:
* Neurons (array of INeuron without set property)

INetwork includes:
* fields
  * CountInLayers (integer array that contains count of neurons in different layers)
* methods
  * SetInputs (using to set input layer values by double array as parameter)
  * ProcessData (using to processing input data)
  * GetOutputs (returns double array of output layer)
  * Train (training network with DataSet using learnRate)
  * GetSquareError (returns square different of current output and expected)

## Testing
### Creating simple perceptron
To test this arcitecture a simple perceptron network was created.
At the beginning was created a diffrent neuron types, what perform specific function:
* InputNeuron (uses in first layer to get input value)
* RegularNeuron (uses in intermediate layer to process data between input and output layers)
* OutputNeuron (uses in last layer to get result of data processing by network)
* BiasNeuron (can be used in all layers excluding output layer, always retern one as value)

After was created RegularLayer class that implements ILayer interface and uses in all layers of network.

At the and was created Perceptron class that implements INetwork interface.
This interface gives opportunity to use different types of network in the same place of code whenever it needs.
At example it can be used to train different networks in the same place in code, that makes it reusable.

### Training
To chek working ability of network was choosen Fisher's iris data set.

#### Perceptron with 4 inputs, 8 neurons in hidden layer and 3 outputs
Training results:
* 131 correct answers
* 19 incorrect answers

Square error graph with learn rate coefficient equals to 0.05
<img src="https://github.com/gibaldev/Imagies/blob/master/StrategyNeuralNetwork/4-8-3gens1000_lr0%2C05.txt.png">

#### Perceptron with 4 inputs, 12 and 6 neurons in hidden layers and 3 outputs
Training results:
* 146 correct answers
* 4 incorrect answers

Square error graph with learn rate coefficient equals to 0.01
<img src="https://github.com/gibaldev/Imagies/blob/master/StrategyNeuralNetwork/4-12-6-3gens1000_lr0%2C01.txt.png">

## Result
In conclusin this neural network arcitecture can be used in some projects, where needs working with different neural networks at the same time.
This arcitecture makes developing or using neural networks simple and understandable, that means it saves programmers time and companies money.
