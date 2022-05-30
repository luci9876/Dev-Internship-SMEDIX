namespace Smedix.RecruitmentFunnel.Exceptions
{
    [Serializable]
    public class CandidateFileNotFoundException : Exception
    {
        public CandidateFileNotFoundException() { }

        public CandidateFileNotFoundException(string message)
            : base(message) { }

        public CandidateFileNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
