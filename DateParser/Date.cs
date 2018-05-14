namespace DateParser
{
    /// <summary>
    /// Contains all the necessary data used by DateManager object
    /// </summary>
    public class Date
    {
        #region Read-only Properties

        /// <summary>
        /// All three components - day, month, year
        /// </summary>
        public DateComponents DateComponents { get; }

        /// <summary>
        /// DateComponents converted to a string
        /// </summary>
        public DateComponentsAsStrings DateComponentsAsStrings { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs an object by accepting DateComponents object
        /// </summary>
        /// <param name="DateComponents">DateComponents object</param>
        public Date(DateComponents DateComponents)
        {
            this.DateComponents = DateComponents;
            DateComponentsAsStrings = new DateComponentsAsStrings(DateComponents);
        }

        #endregion
    }
}
