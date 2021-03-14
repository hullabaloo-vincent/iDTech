# Java Class 01 Overview

# Basics of a Java class
```Java
public class HelloWorld{
    public static void main(String[] args){
      // Write code to execute here
    }
}
```
### What is a class?
A class is a blueprint containing variables and methods that make it unique. You can have multiple classes that reference each other, or have unique instance of the same class. For example, you can have the class *car*, but there can be many different types of variations of that car, all sharing the same blueprints, such as having wheels, color, engine. One car could have a blue coat, while another can have a red coat.

![image](https://user-images.githubusercontent.com/10886243/111084972-88aaad80-84eb-11eb-9e02-6db85966e297.png)


### Breaking down public static void main(String[] args)
| Public | static | void | main( | String[] args) |
| --- | --- | --- | --- | --- |
| This makes the function main() available to the Java Virtual Machine (JVM) to run. | This designates the main() function to this particular class. Note: A static function can be invoked without creating a separate instance of a class | Typically, a function must return something, such as a variable, however, setting any function as void means it does not need to return anything. Example of a function that needs to return something: public int getSpeed(){ return this.speed} | This is the function that gets executed by the JVM | String[] args are variables that you can pass into the app via a command line. For example, lets say you had a java file that writes text documents, and you want to immediately open the app with your a specific document in mind. To execute your java file type java MyTextApp.java, but to pass a text file location in type java MyTextApp.java C:/Users/Desktop/WritingHomework.txt.
# Running code in the terminal
### Running a .java file
In the command line, type the following:
```
java YourAppName.java
```
### Running a .jar file
In the command line, type the following:
```
java -jar YourJarName.jar
```
### Passing parameters into the app
```
java YourAppName.java arg1 arg2...etc
java -jar YourJarName.jar arg1 arg2...etc
```
# Hello World!
```Java
System.out.println("Hello World!");
System.out.println("Hello World!");
```
```
Output >>
Hello World!
Hello World!
```
```Java
System.out.print("Hello World!");
System.out.print("Hello World!");
```
```
Output >>
Hello World!Hello World!
```
# For Loops 
### Java example
```Java
// For loop example #1
for (b : args) {
  System.out.println(b);
}
// For loop example #2
for (int i = 0; i < args.length; i++) {
  System.out.println(args[i]);
}
```
### Python example
```Python
'''
Just for reference, this is what that
same loop would look like in Python
'''
for b in args:
  print(b)
```
