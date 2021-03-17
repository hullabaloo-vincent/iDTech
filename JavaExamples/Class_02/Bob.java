/*
 *
 * @author Vincent Aliquo
 * 3/17/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */
public class Bob extends NPC {                                                  // New class "Bob" will take the class attributes of NPC class

    private String name = "Bob";                                                // Defines preset name, "Bob"
    private int age = 85;                                                       // Defines preset age, 85

    public Bob() {                                                              // When the Bob class is created, it will call on the NPC functions to set the parameters itself.
        super.setName(name);                                                    
        super.setAge(age);
        super.yellIntoTheVoid();
    }
}
