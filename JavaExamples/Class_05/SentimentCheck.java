import edu.stanford.nlp.ling.*;
import edu.stanford.nlp.pipeline.*;
import edu.stanford.nlp.util.*;
import edu.stanford.nlp.sentiment.SentimentCoreAnnotations;
import java.util.*;

/**
 *
 * @author vince
 */
public class SentimentCheck {

    String userSentence;
    String sProperty;
    String sentimentVal;
    Annotation annotation;

    public SentimentCheck(String user_sentence) {
        Properties props = new Properties();
        props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner, parse, sentiment");

        StanfordCoreNLP pipeline = new StanfordCoreNLP(props);

        annotation = new Annotation(user_sentence);

        pipeline.annotate(annotation);
    }

    public ArrayList<String> getToken(String _sProperty) {
        sProperty = _sProperty;
        ArrayList<String> tokenHolder = new ArrayList<String>();
        List<CoreMap> sentences = annotation.get(CoreAnnotations.SentencesAnnotation.class);
        if (sentences != null && !sentences.isEmpty()) {
            CoreMap sentence = sentences.get(0);
            for (CoreMap token : sentence.get(CoreAnnotations.TokensAnnotation.class)) {
                tokenHolder.add(token.toShorterString(_sProperty));
            }
        }
        return tokenHolder;
    }

    public String getSentiment() {
        List<CoreMap> sentences = annotation.get(CoreAnnotations.SentencesAnnotation.class);
        CoreMap sentence = sentences.get(0);
        return sentence.get(SentimentCoreAnnotations.SentimentClass.class);
    }
}