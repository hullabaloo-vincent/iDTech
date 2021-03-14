/*
 *
 * @author Vincent Aliquo
 * 3/14/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */

public class HelloWorld{
    public static void main(String[] args){
        System.out.println("Number of args: " + args.length);
        /*
        PYTHON EQUIVILANT
        for b in args:
            print(b)
        */
        for (String b : args){
            System.out.println(b);
        }
    }
}