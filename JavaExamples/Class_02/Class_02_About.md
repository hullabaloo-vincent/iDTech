# Java Class 02 Overview (UNDER CONSTRUCTION)

# Instances
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
In the two examples above, I created a class called MyClass. It is empty, but it can still be instantiated in my main function in MyApp.java.
# Inheritance
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
```Java
public class MyClass {
  private int size;
  private int weight;
  public MyClass(newSize, newWeight){
    this.size = newSize;
    this.size = newWeight;
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
### Void
```Java
public void SayHello(){
  System.out.println("Hello!);
}
```
### Return
```Java
public String SayHello(){
  return "Hello!";
}
```
### What is super()?
