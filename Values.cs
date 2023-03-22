namespace MO2Helpers
{

    public static class Values
    {
        /// <summary>
        /// Determines whether a int16 number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this short value,
            short start,
            short end)
            =>
            value >= start && value <= end;

        /// <summary>
        /// Determines whether a int32 number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this int value,
            int start,
            int end)
            =>
            value >= start && value <= end;

        /// <summary>
        /// Determines whether a int64 number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this long value,
            long start,
            long end)
            =>
            value >= start && value <= end;

        /// <summary>
        /// Determines whether a float number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this float value,
            float start,
            float end)
            =>
            value >= start && value <= end;

        /// <summary>
        /// Determines whether a double number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this double value,
            double start,
            double end)
            =>
            value >= start && value <= end;

        /// <summary>
        /// Determines whether a decimal number between two numbers.
        /// </summary>
        /// <param name="value">Represents the number to check it.</param>
        /// <param name="start">Start number of the interval "Inclusive".</param>
        /// <param name="end">End number of the interval "Inclusive".</param>
        /// <returns>true if the value founded between start and end; otherwise, false</returns>
        public static bool Between(
            this decimal value,
            decimal start,
            decimal end)
            =>
            value >= start && value <= end;
    }

}
