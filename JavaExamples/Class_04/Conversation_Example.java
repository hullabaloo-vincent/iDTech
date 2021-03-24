/*
 *
 * @author Vincent Aliquo
 * 3/24/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */
public class Conversation_Example{

    public static void main(String[] args) {
        //String user_input = "Sup, what's your NAME?";
        String user_input = "Your name now is Purple Unicorn The Third";
        String npc_name = "GOLDDIGGER";
        boolean asking_question = false;
        if (user_input.contains("?")){
            asking_question = true;
        }
        
        if (    
                asking_question && 
                user_input.toLowerCase().contains("name")&&
                user_input.toLowerCase().contains("your")
            ){
            System.out.println("My name is " + npc_name);
        }
        if (    
                !asking_question && 
                user_input.toLowerCase().contains("my")&&
                user_input.toLowerCase().contains("name")&&
                user_input.toLowerCase().contains("is")
            ){
            String user_name = user_input.substring(user_input.lastIndexOf("is") + 3);
            System.out.println("Hi, " + user_name);
        }
        if (    
                !asking_question && 
                user_input.toLowerCase().contains("your")&&
                user_input.toLowerCase().contains("name")&&
                user_input.toLowerCase().contains("is")
            ){
            npc_name = user_input.substring(user_input.lastIndexOf("is") + 3);
            System.out.println("My name is now " + npc_name);
        }
    }
}
