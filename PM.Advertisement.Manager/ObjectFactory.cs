namespace PM.Advertisement.Manager
{
    public class ObjectFactory
    {
        public static AdTrackingManager CreateAdTrackingManagerInstance()
        {
            return new AdTrackingManager(
                Engine.ObjectFactory.CreateDuplicateDetectorEngineInstance(),
                Adevertisement.Access.ObjectFactory.CreateAdvertisersFileAccessInstance());
        }
    }
}