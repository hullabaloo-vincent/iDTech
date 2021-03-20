# Java Class 02 Overview

# Instances
Instances are copies of a class, including variables and funtions. Instances can also set and get values that are persistant througout each instance of a class. In the two examples below, I created a class called MyClass. It is empty, but it can still be instantiated in my main function in MyApp.java.
**MyClass.java**
```Java
public class MyClass {
  public MyClass(){
  }
}
```
**MyApp.java**
```Java
public class MyApp {
  public static void main(String[] args){
    MyClass mc = new MyClass()
  }
}
```
# Inheritance
Inheritance means that a class obtains attributes, such as functions and variables, of another class. Consider it as a blueprint for your class. Consider the following: You have a blueprint for a skyscraper, and you want to create a brand-new building related to the skyscraper. To be a skyscraper, your new building needs to follow certain guidelines about what makes a skyscraper a skyscraper, but beyond that, your new building can look different both internally and externally.
```Java
public class MyClass {
  public MyClass(){
  }
}
```
```Java
public class MyNewClass extends MyClass {
  public MyNewClass(){
  }
}
```
________________________________________
The examples below demonstrate the class MyClass, when instantiated, sets the size and weight of the ints. MyNewClass extends MyClass, meaning it has access to its public functions. MyClass requires two parameters for its instantiation: newSize and newWeight. This requires MyNewClass to also require those same parameters on instantiation since it extends MyClass. The term **super** means that you are referring to the parent class, MyClass, stating that you are sending the parameters from MyNewClass to MyClass. To reference a function, such as public void setSize(), from MyNewClass, add a super prefex: super.newSize().
```Java
public class MyClass {
  private int size;
  private int weight;
  public MyClass(newSize, newWeight){
    this.size = newSize;
    this.weight = newWeight;
  }
}
```
```Java
public class MyNewClass extends MyClass {
  public MyNewClass(newSize, newWeight){
    super(newSize, newWeight)
  }
}
```
________________________________________
```Java
public class MyClass {
  private int size;
  private int weight;
  public MyClass(){
  }
  
  public void setSize(newSize){
    this.size = newSize;
  }
}
```
```Java
public class MyNewClass extends MyClass {
  private int customSize = 5;
  public MyNewClass(){
    super.newSize(customSize);
  }
}
```
# Functions
When a function is called, it runs all code within the curley brackets **{}**. All functions require parentheses **()**, where you can pass parameters into the function. When a function has parameters, it means that when you call it, you must submit all those parameters as well. SayHello() has no parameters, so calling it like so will work: SayHello(). SayHello(String words) has one parameter, so calling it will only work if the parameters are satisfied: SayHello(“Hello”). 
### Return
A return function requires a return value of the type the function is declared as.
```Java
<variable type>YourFuctionName(){
	Return <variable type>
}
```
```Java
public String SayHello(){
  return "Hello!";
}
```
### Void
A void function means that it is not required to return a value.
A void 
```Java
public void SayHello(){
  System.out.println("Hello!);
}
```
