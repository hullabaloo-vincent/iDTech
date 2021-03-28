/*
 *
 * @author Vincent Aliquo
 * 3/28/2021
 * GitHub: https://github.com/hullabaloo-vincent
 * 
 */
public class Main {
    
    public static void main(String[] args) {
        String user_input = "You are a terrible human being.";
        SentimentCheck sc = new SentimentCheck(user_input);
        System.out.println(sc.getSentiment());
        ArrayList<String> tokenRaw = sc.getToken("PartOfSpeech"); //get part of speech from results
        ArrayList<String> tokenText = sc.getToken("Text"); //get individual words from results
        ArrayList<String> tokenSentiment = sc.getToken("SentimentClass"); //get sentiment from results
        System.out.println(tokenRaw);
        System.out.println(tokenText);
        System.out.println(tokenSentiment);
    }
}