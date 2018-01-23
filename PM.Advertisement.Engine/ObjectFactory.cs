namespace PM.Advertisement.Engine
{
    public class ObjectFactory
    {
        public static IDuplicateDetectorEngine CreateDuplicateDetectorEngineInstance()
        {
            return new DuplicateDetectorEngine();
        }
    }
}