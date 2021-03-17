/*
 *
 * @author Vincent Aliquo
 * 3/17/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */
public class ID_Tech {

    public static void main(String[] args) {
        NPC Phil = new NPC();                                                   // Create new class instasnce of NPC named "Phil".
        Phil.setName("Phil");                                                   // Sets name of NPC instance "Phil".
        Phil.setAge(27);                                                        // Sets age of NPC instance "Phil".
        Phil.setPersonality(PersonalityType.Sarcastic);                         // Sets the personality type of NPC instance "Phil" to enum type "Sarcastic".
        Bob bob = new Bob();                                                    // Creates new class instance, Bob, which extends the NPC class.
    }
}
