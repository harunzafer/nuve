namespace Nuve.Stemming
{
    internal interface IStemmer
    {
        /// <summary>
        /// Returns the stem for the given word.  <br/>
        /// Th stem may be different based on the <br/>
        /// class implementing this interface. 
        /// The word's itself is returned if it can not be stemmed.
        /// </summary>
        string GetStem(string word);

       
    }
}