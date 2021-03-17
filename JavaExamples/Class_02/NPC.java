/*
 *
 * @author Vincent Aliquo
 * 3/17/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */
enum PersonalityType {
    Sarcastic,
    Joyful,
    Angry
}

public class NPC {

    private String characterName;                                               // Holds the value of the NPC's name
    public int characterAge;                                                    // Holds the value of the NPC's age
    private PersonalityType npcPersonality;                                     // Holds the vlaue of the NPC's personality type (enum)
    
    /**
     * This just initializes the class. For initialization, no parameters are
     * required.
     */
    public NPC() {
    }
    
    /**
     * When called, this sets the value of characterName to newName.
     * Ex:  NPC yourNPC = new NPC();
     *      yourNPC.setName("Bobbie");
     *      // characterName inside the NPC class for yourNPC will be "Bobbie".
     * @param newName 
     */
    public void setName(String newName) {
        this.characterName = newName;
    }
    
    /**
     * When called, this sets the value of characterAge to newAge.
     * Ex:  NPC yourNPC = new NPC();
     *      yourNPC.setAge(25);
     *      // characterAge inside the NPC class for yourNPC will be 25.
     * @param newAge 
     */
    public void setAge(int newAge) {
        this.characterAge = newAge;
    }
    
    /**
     * This will define what enumerator value npcPersonality will be.
     * npcPersonality can be the following values set by the enum variable
     * PersonalityType:
     *      Sarcastic, Joyful, Angry
     * Ex:  NPC yourNPC = new NPC();
     *      yourNPC.setPersonality(PersonalityType.Sarcastic);
     *      // characterPersonality inside the NPC class for yourNPC will be
     *      // npcPersonality.Sarcastic.
     * @param newPersonality 
     */
    public void setPersonality(PersonalityType newPersonality) {
        this.npcPersonality = newPersonality;
    }
    
    /**
     * 
     * @return String value of npcPersonality
     */
    public String getPersonality() {
        // Instead of using an if statement to determine what enum the npcPersonality
        // is set at, it is common to use a switch statement.
        switch (npcPersonality) {
            case Sarcastic:                                                     // Equivilant to saying "if npcPersonality = Sarcastic"
                System.out.println("Sarcastic character");
                break;                                                          // "Breaks" out of the switch statement
            case Joyful:
                System.out.println("Joyful character");
                break;
            case Angry:
                System.out.println("Angry character");
                break;
        }
        //toString() converts the enum value of npcPersonality to a String.
        // Ex:
        //      int a = 4;
        //      System.out.println(a)
        //      output >> 4
        //      String b = a.toString();
        //      System.out.println(b)
        //      output >> "4"
        return npcPersonality.toString();
    }
    
    /**
     * Returns the String value of characterName
     * @return 
     */
    public String getName() {
        return characterName;
    }
    
    /**
     * Returns the int value of characterAge
     * @return 
     */
    public int getAge() {
        return characterAge;
    }
    
    /**
     * An example of a function that doesn't return anything
     */
    public void yellIntoTheVoid() {
        System.out.println("Arghhhhhh");
    }
}
