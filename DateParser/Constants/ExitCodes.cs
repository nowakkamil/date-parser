namespace DateParser
{
    public static class ExitCodes
    {
        public const int Success = 0;

        public const int InvalidNumOfArgsExitCode = 1;

        public const int InvalidNumOfDateComponentsExitCode = 2;

        public const int DateComponentsOrderIndexOutOfRangeExitCode = 3;

        public const int DateComponentsOrderDuplicationExitCode = 4;
    }
}
